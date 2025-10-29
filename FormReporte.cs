using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Operador_911
{
    public partial class FormReporte : Form
    {
        private int _idAlerta;

        public FormReporte(int idAlerta)
        {
            InitializeComponent();
            _idAlerta = idAlerta;
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            // Mostrar título con el número de alerta
            labelTitulo_Reporte.Text = $"Informe de la Alerta N° {_idAlerta}";

            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT a.id_alerta, a.direccion, a.tipo_incidencia,
                           l.nombre, l.telefono
                    FROM Alerta a
                    LEFT JOIN Llamada l ON a.id_alerta = l.id_alerta
                    WHERE a.id_alerta = @id", con);

                cmd.Parameters.AddWithValue("@id", _idAlerta);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBoxDireccion.Text = dr["direccion"].ToString();
                    textBoxIncidente.Text = dr["tipo_incidencia"].ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string descripcion = textBoxDescripcion.Text.Trim();

            if (string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Debe ingresar una descripción del reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = Database.GetConnection())
            {
                // 1️⃣ Buscar la patrulla asignada a la alerta
                SqlCommand cmdPatrulla = new SqlCommand(@"
            SELECT id_patrulla 
            FROM Alerta 
            WHERE id_alerta = @idAlerta", con);
                cmdPatrulla.Parameters.AddWithValue("@idAlerta", _idAlerta);

                object resultPatrulla = cmdPatrulla.ExecuteScalar();

                if (resultPatrulla == null)
                {
                    MessageBox.Show("No hay una patrulla asignada a esta alerta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idPatrulla = Convert.ToInt32(resultPatrulla);

                // 2️⃣ Obtener el día y turno actuales
                string diaSemana = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("es-ES"));
                int horaActual = DateTime.Now.Hour;
                string turno = (horaActual >= 6 && horaActual < 18) ? "06-18" : "18-06";

                // 3️⃣ Buscar la combinación activa de planilla
                SqlCommand cmdPlanilla = new SqlCommand(@"
            SELECT TOP 1 id_planilla, id_patrulla, nro_placa
            FROM Tiene
            WHERE id_patrulla = @idPatrulla
              AND dia_semana = @diaSemana
              AND turno = @turno
        ", con);

                cmdPlanilla.Parameters.AddWithValue("@idPatrulla", idPatrulla);
                cmdPlanilla.Parameters.AddWithValue("@diaSemana", diaSemana);
                cmdPlanilla.Parameters.AddWithValue("@turno", turno);

                SqlDataReader dr = cmdPlanilla.ExecuteReader();

                if (!dr.Read())
                {
                    dr.Close();
                    MessageBox.Show("No se encontró una planilla activa para esta patrulla en el día y turno actuales.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idPlanilla = Convert.ToInt32(dr["id_planilla"]);
                int nroPlaca = Convert.ToInt32(dr["nro_placa"]);
                dr.Close();

                // 4️⃣ Insertar el reporte
                SqlCommand cmdInsert = new SqlCommand(@"
            INSERT INTO Reporte (descripcion, id_alerta, id_patrulla, nro_placa, id_planilla)
            VALUES (@desc, @idAlerta, @idPatrulla, @nroPlaca, @idPlanilla)
        ", con);

                cmdInsert.Parameters.AddWithValue("@desc", descripcion);
                cmdInsert.Parameters.AddWithValue("@idAlerta", _idAlerta);
                cmdInsert.Parameters.AddWithValue("@idPatrulla", idPatrulla);
                cmdInsert.Parameters.AddWithValue("@nroPlaca", nroPlaca);
                cmdInsert.Parameters.AddWithValue("@idPlanilla", idPlanilla);

                int filas = cmdInsert.ExecuteNonQuery();

                if (filas > 0)
                {
                    // 5️⃣ Actualizar el estado de la alerta a "Atendida" y registrar fecha de cierre
                    SqlCommand cmdUpdate = new SqlCommand(@"
                UPDATE Alerta
                SET estado = 'Atendida',
                    fecha_cierre = GETDATE()
                WHERE id_alerta = @idAlerta
            ", con);
                    cmdUpdate.Parameters.AddWithValue("@idAlerta", _idAlerta);
                    cmdUpdate.ExecuteNonQuery();

                    MessageBox.Show("Reporte guardado y alerta marcada como atendida.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
