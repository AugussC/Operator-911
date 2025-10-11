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
            
           dataGridHorarios.SelectionChanged += dataGridHorarios_SelectionChanged;
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
                dataGridHorarios.RowHeadersWidth = 150;
                dataGridHorarios.AllowUserToAddRows = false;
                dataGridHorarios.AllowUserToResizeRows = false;

                using (SqlConnection conn = Database.GetConnection())
                {

                    // --- 1️⃣ Buscar la comisaría del usuario ---
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

                    // --- 2️⃣ Obtener patrullas en servicio de esa comisaría ---
                    string queryPatrullas = @"
                SELECT id_patrulla, codigo_patrulla
                FROM Patrulla
                WHERE estado = 'En servicio' AND id_comisaria = @idComisaria";

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

        private void btnEditarPatrullas_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarPatrullas_Click(object sender, EventArgs e)
        {

        }
    }
}
