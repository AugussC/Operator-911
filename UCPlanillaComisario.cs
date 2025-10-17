using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Operador_911.FormLogin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Operador_911
{
    public partial class UCPlanilla : UserControl
    {
        private int idComisaria;
        public UCPlanilla()
        {
            InitializeComponent();
            CargarComboBox();
            CargarPlanilla();
            
           
        }

        private void FormOperador_Load(object sender, EventArgs e)
        {

        }

        private void CargarComboBox()
        {
            CargarComboPatrullas();
            CargarComboPolicias();
            CargarComboHorarios();
            CargarComboDias();
        }

        private void CargarComboPatrullas()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id_patrulla, codigo_patrulla FROM Patrulla";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                patrullaBox.DisplayMember = "codigo_patrulla";
                patrullaBox.ValueMember = "id_patrulla";
                patrullaBox.DataSource = dt;
            }
        }

        private void CargarComboPolicias()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT nro_placa, (apellido + ', ' + nombre) AS NombreCompleto FROM Policia";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                policia1Box.DisplayMember = "NombreCompleto";
                policia1Box.ValueMember = "nro_placa";
                policia1Box.DataSource = dt.Copy();

                policia2Box.DisplayMember = "NombreCompleto";
                policia2Box.ValueMember = "nro_placa";
                policia2Box.DataSource = dt;
            }
        }

        private void CargarComboHorarios()
        {
            horarioBox.Items.Clear();
            horarioBox.Items.Add("06-18");
            horarioBox.Items.Add("18-06");
            horarioBox.SelectedIndex = -1;
        }

        private void CargarComboDias()
        {
            DiaBox.Items.Clear();
            DiaBox.Items.AddRange(new string[]
            {
                "Lunes","Martes","Miércoles","Jueves","Viernes","Sábado","Domingo"
            });
            DiaBox.SelectedIndex = -1;
        }

        private void CargarPlanilla()
        {
            try
            {
                dataGridHorarios.Columns.Clear();
                dataGridHorarios.Rows.Clear();

                // --- Crear columnas de días ---
                string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
                foreach (string dia in dias)
                {
                    dataGridHorarios.Columns.Add(dia, dia);
                }

                dataGridHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridHorarios.RowHeadersWidth = 100;
                dataGridHorarios.AllowUserToAddRows = false;
                dataGridHorarios.AllowUserToResizeRows = false;

                using (SqlConnection conn = Database.GetConnection())
                {

                    // --- Buscar la comisaría del usuario ---
                    string queryComisaria = "SELECT id_comisaria FROM Comisaria WHERE id_usuario_comisario = @idUsuario";
                    SqlCommand cmdComisaria = new SqlCommand(queryComisaria, conn);
                    cmdComisaria.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuario);

                    object result = cmdComisaria.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("No se encontró una comisaría asociada a este usuario.");
                        return;
                    }

                    int idComisaria = Convert.ToInt32(result);

                    // --- Obtener patrullas en servicio de esa comisaría ---
                    string queryPatrullas = @"
                SELECT id_patrulla, codigo_patrulla
                FROM Patrulla
                WHERE estado = 'En servicio' AND id_comisaria = @idComisaria AND activo = 1";

                    SqlCommand cmdPatrullas = new SqlCommand(queryPatrullas, conn);
                    cmdPatrullas.Parameters.AddWithValue("@idComisaria", idComisaria);

                    DataTable dtPatrullas = new DataTable();
                    SqlDataAdapter daP = new SqlDataAdapter(cmdPatrullas);
                    daP.Fill(dtPatrullas);

                    // --- 3️⃣ Obtener datos actuales de la tabla Tiene ---
                    string qTiene = @"
                SELECT T.id_patrulla, T.nro_placa, T.dia_semana, T.turno,
                       (Pol.apellido + ', ' + Pol.nombre) AS Policia
                FROM Tiene T
                INNER JOIN Policia Pol ON T.nro_placa = Pol.nro_placa
                INNER JOIN Patrulla Pa ON T.id_patrulla = Pa.id_patrulla
                WHERE Pa.id_comisaria = @idComisaria AND Pa.estado = 'En servicio'";

                    SqlCommand cmdTiene = new SqlCommand(qTiene, conn);
                    cmdTiene.Parameters.AddWithValue("@idComisaria", idComisaria);

                    DataTable dtTiene = new DataTable();
                    SqlDataAdapter daT = new SqlDataAdapter(cmdTiene);
                    daT.Fill(dtTiene);

                    // --- 4️⃣ Construir la planilla completa ---
                    foreach (DataRow patrulla in dtPatrullas.Rows)
                    {
                        string nombrePatrulla = patrulla["codigo_patrulla"].ToString();
                        int idPatrulla = Convert.ToInt32(patrulla["id_patrulla"]);

                        // Fila título (nombre patrulla)
                        int filaTitulo = dataGridHorarios.Rows.Add();
                        dataGridHorarios.Rows[filaTitulo].DefaultCellStyle.BackColor = Color.LightGray;
                        dataGridHorarios.Rows[filaTitulo].DefaultCellStyle.Font = new Font(dataGridHorarios.Font, FontStyle.Bold);
                        dataGridHorarios.Rows[filaTitulo].HeaderCell.Value = "";
                        dataGridHorarios.Rows[filaTitulo].Cells[0].Value = nombrePatrulla;
                        dataGridHorarios.Rows[filaTitulo].ReadOnly = true;

                        // Fila de turno mañana
                        int filaManiana = dataGridHorarios.Rows.Add();
                        dataGridHorarios.Rows[filaManiana].HeaderCell.Value = "06-18";

                        // Fila de turno noche
                        int filaNoche = dataGridHorarios.Rows.Add();
                        dataGridHorarios.Rows[filaNoche].HeaderCell.Value = "18-06";

                        // Buscar registros de esta patrulla
                        var registros = dtTiene.AsEnumerable()
                            .Where(r => r.Field<int>("id_patrulla") == idPatrulla);

                        foreach (var registro in registros)
                        {
                            string dia = registro.Field<string>("dia_semana");
                            string turno = registro.Field<string>("turno");
                            string policia = registro.Field<string>("Policia");

                            // Determinar fila según turno
                            int fila = (turno == "06-18") ? filaManiana : filaNoche;

                            // Si el día existe como columna
                            if (dataGridHorarios.Columns.Contains(dia))
                            {
                                if (dataGridHorarios[dia, fila].Value != null)
                                    dataGridHorarios[dia, fila].Value += " - " + policia;
                                else
                                    dataGridHorarios[dia, fila].Value = policia;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la planilla: " + ex.Message);
            }
        }

        private bool ValidarAsignacion(int? policia1, int? policia2, string dia, string turno)
        {
            // 🚫 Mismo policía dos veces
            if (policia1.HasValue && policia2.HasValue && policia1 == policia2)
            {
                MessageBox.Show("El mismo policía no puede ser asignado como Policía 1 y Policía 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Lista de días
            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
            int indiceDia = Array.IndexOf(dias, dia);

            string turnoAnterior = (turno == "06-18") ? "18-06" : "06-18";
            string diaAnterior = dia;

            // 🔹 Si el turno actual es de mañana, el anterior es la noche del día anterior
            if (turno == "06-18" && indiceDia > 0)
                diaAnterior = dias[indiceDia - 1];
            else if (turno == "06-18" && indiceDia == 0)
                diaAnterior = null; // Lunes no tiene anterior

            using (SqlConnection conn = Database.GetConnection())
            {
                bool PoliciaTieneTurno(int nroPlaca, string diaBuscar, string turnoBuscar)
                {
                    if (diaBuscar == null) return false; // si no hay día anterior, se salta

                    string q = @"SELECT COUNT(*) FROM Tiene 
                         WHERE nro_placa = @nroPlaca 
                         AND dia_semana = @dia 
                         AND turno = @turno";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@nroPlaca", nroPlaca);
                        cmd.Parameters.AddWithValue("@dia", diaBuscar);
                        cmd.Parameters.AddWithValue("@turno", turnoBuscar);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }

                // 🚫 Validar turno anterior en el mismo día o el anterior
                if (policia1.HasValue && PoliciaTieneTurno(policia1.Value, diaAnterior, turnoAnterior))
                {
                    MessageBox.Show($"El policía {policia1Box.Text} no puede ingresar porque trabajó el turno anterior ({turnoAnterior}) del día {diaAnterior ?? dia}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (policia2.HasValue && PoliciaTieneTurno(policia2.Value, diaAnterior, turnoAnterior))
                {
                    MessageBox.Show($"El policía {policia2Box.Text} no puede ingresar porque trabajó el turno anterior ({turnoAnterior}) del día {diaAnterior ?? dia}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true; // ✅ Todo OK
        }




        private void btnEditarPatrullas_Click(object sender, EventArgs e)
        {
            try
            {
                if (patrullaBox.SelectedValue == null ||
                    horarioBox.SelectedItem == null ||
                    DiaBox.SelectedItem == null ||
                    (policia1Box.SelectedValue == null && policia2Box.SelectedValue == null))
                {
                    MessageBox.Show("Por favor, seleccione patrulla, turno, día y al menos un policía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idPatrulla = Convert.ToInt32(patrullaBox.SelectedValue);
                string turno = horarioBox.SelectedItem.ToString();
                string dia = DiaBox.SelectedItem.ToString();

                int? policia1 = policia1Box.SelectedValue as int?;
                int? policia2 = policia2Box.SelectedValue as int?;

                // ✅ Llamamos a la función de validación
                if (!ValidarAsignacion(policia1, policia2, dia, turno))
                    return; // Si devuelve false, se corta la ejecución

                using (SqlConnection conn = Database.GetConnection())
                {
                    // 🔹 Eliminar registros previos de esa patrulla / día / turno
                    string deleteQuery = @"
                DELETE FROM Tiene
                WHERE id_patrulla = @idPatrulla AND dia_semana = @dia AND turno = @turno";

                    SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn);
                    cmdDelete.Parameters.AddWithValue("@idPatrulla", idPatrulla);
                    cmdDelete.Parameters.AddWithValue("@dia", dia);
                    cmdDelete.Parameters.AddWithValue("@turno", turno);
                    cmdDelete.ExecuteNonQuery();

                    // 🔹 Insertar los nuevos policías
                    string insertQuery = @"
                INSERT INTO Tiene (id_patrulla, nro_placa, dia_semana, turno)
                VALUES (@id_patrulla, @nro_placa, @dia, @turno)";

                    if (policia1.HasValue)
                    {
                        SqlCommand cmdInsert1 = new SqlCommand(insertQuery, conn);
                        cmdInsert1.Parameters.AddWithValue("@id_patrulla", idPatrulla);
                        cmdInsert1.Parameters.AddWithValue("@nro_placa", policia1.Value);
                        cmdInsert1.Parameters.AddWithValue("@dia", dia);
                        cmdInsert1.Parameters.AddWithValue("@turno", turno);
                        cmdInsert1.ExecuteNonQuery();
                    }

                    if (policia2.HasValue && policia2 != policia1)
                    {
                        SqlCommand cmdInsert2 = new SqlCommand(insertQuery, conn);
                        cmdInsert2.Parameters.AddWithValue("@id_patrulla", idPatrulla);
                        cmdInsert2.Parameters.AddWithValue("@nro_placa", policia2.Value);
                        cmdInsert2.Parameters.AddWithValue("@dia", dia);
                        cmdInsert2.Parameters.AddWithValue("@turno", turno);
                        cmdInsert2.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Los policías fueron actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔄 Refrescar la planilla visual
                CargarPlanilla();
                dataGridHorarios.ClearSelection();

                // Deshabilitar botones hasta una nueva selección
                btnEditarPatrullas.Enabled = false;
                btnEliminarPatrullas.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los policías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminarPatrullas_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya una selección válida
                if (patrullaBox.SelectedValue == null ||
                    horarioBox.SelectedItem == null ||
                    DiaBox.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una patrulla, un día y un turno para eliminar.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener valores seleccionados
                int idPatrulla = Convert.ToInt32(patrullaBox.SelectedValue);
                string turno = horarioBox.SelectedItem.ToString();
                string dia = DiaBox.SelectedItem.ToString();

                // Confirmar con el usuario
                DialogResult confirm = MessageBox.Show(
                    $"¿Desea eliminar las asignaciones de la patrulla seleccionada ({patrullaBox.Text}) " +
                    $"para el día {dia} y turno {turno}?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                using (SqlConnection conn = Database.GetConnection())
                {
                    string deleteQuery = @"
                DELETE FROM Tiene
                WHERE id_patrulla = @idPatrulla AND dia_semana = @dia AND turno = @turno";

                    SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn);
                    cmdDelete.Parameters.AddWithValue("@idPatrulla", idPatrulla);
                    cmdDelete.Parameters.AddWithValue("@dia", dia);
                    cmdDelete.Parameters.AddWithValue("@turno", turno);

                    int filasAfectadas = cmdDelete.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                        MessageBox.Show("Las asignaciones fueron eliminadas correctamente.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se encontraron asignaciones para eliminar.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 🔄 Refrescar visualmente la planilla
                CargarPlanilla();
                dataGridHorarios.ClearSelection();

                // 🔒 Deshabilitar botones hasta nueva selección
                btnEditarPatrullas.Enabled = false;
                btnEliminarPatrullas.Enabled = false;

                // Limpiar los combos
                patrullaBox.Enabled = true;
                horarioBox.Enabled = true;
                DiaBox.Enabled = true;
                policia1Box.SelectedIndex = -1;
                policia2Box.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar las asignaciones: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UCPlanilla_Load(object sender, EventArgs e)
        {
            btnEditarPatrullas.Enabled = false;
            btnEliminarPatrullas.Enabled = false;
            dataGridHorarios.ClearSelection();
            dataGridHorarios.SelectionChanged += DataGridHorario_SelectionChanged;
        }

        private void DataGridHorario_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridHorarios.CurrentRow == null)
            {
                btnEditarPatrullas.Enabled = false;
                btnEliminarPatrullas.Enabled = false;
                return;
            }

            DataGridViewRow fila = dataGridHorarios.CurrentRow;

            // Evitar filas "título" (las grises con el nombre de la patrulla)
            if (fila.DefaultCellStyle.BackColor == Color.LightGray || fila.HeaderCell.Value == null)
            {
                btnEditarPatrullas.Enabled = false;
                btnEliminarPatrullas.Enabled = false;
                return;
            }

            // Habilitar los botones si es una fila de turno
            btnEditarPatrullas.Enabled = true;
            btnEliminarPatrullas.Enabled = true;

            // --- Cargar datos en los combos ---
            // Obtener el turno desde el encabezado de la fila
            string turnoSeleccionado = fila.HeaderCell.Value?.ToString();

            // Determinar qué columna (día) se seleccionó
            if (dataGridHorarios.CurrentCell == null)
                return;

            string diaSeleccionado = dataGridHorarios.Columns[dataGridHorarios.CurrentCell.ColumnIndex].HeaderText;
            
            
            // Buscar la patrulla a la que pertenece esta fila
            string patrullaSeleccionada = ObtenerNombrePatrullaDesdeFila(fila.Index);

            // Cargar los valores en los combos
            horarioBox.SelectedItem = turnoSeleccionado;
            horarioBox.Enabled = false;
            DiaBox.SelectedItem = diaSeleccionado;
            DiaBox.Enabled = false;

            // Seleccionar la patrulla correspondiente en el combo
            if (patrullaBox.FindStringExact(patrullaSeleccionada) != -1)
                patrullaBox.SelectedIndex = patrullaBox.FindStringExact(patrullaSeleccionada);
            patrullaBox.Enabled = false;
            // Los policías están en la celda seleccionada (puede haber 1 o 2 separados por “-”)
            string valorCelda = dataGridHorarios.CurrentCell.Value?.ToString();

            if (!string.IsNullOrEmpty(valorCelda))
            {
                string[] policias = valorCelda.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                if (policias.Length > 0)
                {
                    // Seleccionar el primer policía si existe
                    int index1 = policia1Box.FindStringExact(policias[0].Trim());
                    if (index1 != -1)
                        policia1Box.SelectedIndex = index1;
                }

                if (policias.Length > 1)
                {
                    // Seleccionar el segundo policía si existe
                    int index2 = policia2Box.FindStringExact(policias[1].Trim());
                    if (index2 != -1)
                        policia2Box.SelectedIndex = index2;
                }
            }
        }


        private string ObtenerNombrePatrullaDesdeFila(int filaIndex)
        {
            // Recorremos hacia arriba hasta encontrar la fila gris (la del nombre de patrulla)
            for (int i = filaIndex; i >= 0; i--)
            {
                var fila = dataGridHorarios.Rows[i];
                if (fila.DefaultCellStyle.BackColor == Color.LightGray)
                {
                    return fila.Cells[0].Value?.ToString();
                }
            }
            return null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult confirm = MessageBox.Show(
                    "¿Está seguro de que desea eliminar TODOS los registros de la planilla?\n\n" +
                    "Esta acción no se puede deshacer.",
                    "Confirmar limpieza total",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                using (SqlConnection conn = Database.GetConnection())
                {
                    // 🔥 Elimina absolutamente todos los registros
                    string deleteAllQuery = "DELETE FROM Tiene";
                    SqlCommand cmd = new SqlCommand(deleteAllQuery, conn);
                    int filasEliminadas = cmd.ExecuteNonQuery();

                    
                }

                // 🔄 Refrescar la grilla visual
                CargarPlanilla();
                dataGridHorarios.ClearSelection();

                // 🔒 Deshabilitar botones hasta nueva selección
                btnEditarPatrullas.Enabled = false;
                btnEliminarPatrullas.Enabled = false;

                // 🔧 Limpiar combos
                patrullaBox.Enabled = true;
                horarioBox.Enabled = true;
                DiaBox.Enabled = true;
                policia1Box.SelectedIndex = -1;
                policia2Box.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar la planilla: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
