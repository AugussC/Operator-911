using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static Operador_911.FormLogin;

namespace Operador_911
{
    public partial class UCPoliciasComisario : UserControl
    {
        public UCPoliciasComisario()
        {
            InitializeComponent();

            CargarPolicias();
            dataGridViewPolicias.DataBindingComplete += DataGridViewPolicias_DataBindingComplete;
            dataGridViewPolicias.SelectionChanged += DataGridViewPolicias_SelectionChanged;

            textBoxNombre.KeyPress += SoloLetras_KeyPress;
            textBoxApellido.KeyPress += SoloLetras_KeyPress;
            textBoxDNI.KeyPress += SoloNumeros_KeyPress;

            // Cargar opciones de género en el ComboBox
            comboBoxGenero.Items.AddRange(new string[] { "M", "F"});
        }

        private void UCPoliciasComisario_Load(object sender, EventArgs e)
        {
            dataGridViewPolicias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            btnEditarPolicia.Enabled = false;
            btnEliminarPolicia.Enabled = false;
            dataGridViewPolicias.ClearSelection();
        }

        // ================== VALIDACIONES ==================

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // ================== CARGA DE DATOS ==================

        private void CargarPolicias()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
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

                string query = @"
                    SELECT 
                        nro_placa AS 'N° Placa',
                        apellido AS 'Apellido',
                        nombre AS 'Nombre',
                        dni AS 'DNI',
                        genero AS 'Género',
                        activo AS 'Activo'
                    FROM Policia
                    WHERE activo = 1 AND id_comisaria = @idComisaria";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@idComisaria", idComisaria);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewPolicias.DataSource = dt;
            }

            dataGridViewPolicias.ClearSelection();
            LimpiarFormulario();
        }

        private void CargarPoliciasEliminadas()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
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

                string query = @"
                    SELECT 
                        nro_placa AS 'N° Placa',
                        apellido AS 'Apellido',
                        nombre AS 'Nombre',
                        dni AS 'DNI',
                        genero AS 'Género',
                        activo AS 'Activo'
                    FROM Policia
                    WHERE activo = 0 AND id_comisaria = @idComisaria";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@idComisaria", idComisaria);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewPolicias.DataSource = dt;
            }

            dataGridViewPolicias.ClearSelection();
            LimpiarFormulario();
        }

        private void DataGridViewPolicias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewPolicias.ClearSelection();
            LimpiarFormulario();
        }

        // ================== BOTONES ==================

        private void btnAgregarPolicia_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text.Trim();
            string apellido = textBoxApellido.Text.Trim();
            string dni = textBoxDNI.Text.Trim();
            string genero = comboBoxGenero.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(genero))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                string queryComisaria = "SELECT id_comisaria FROM Comisaria WHERE id_usuario_comisario = @idUsuario";
                SqlCommand cmdComisaria = new SqlCommand(queryComisaria, conn);
                cmdComisaria.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuario);
                int idComisaria = Convert.ToInt32(cmdComisaria.ExecuteScalar());

                string query = @"INSERT INTO Policia (apellido, nombre, dni, genero, id_comisaria, activo)
                                 VALUES (@apellido, @nombre, @dni, @genero, @idComisaria, 1);
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@idComisaria", idComisaria);

                int nuevoNroPlaca = Convert.ToInt32(cmd.ExecuteScalar());
                
            }

            CargarPolicias();
        }

        private void btnEliminarPolicia_Click(object sender, EventArgs e)
        {
            if (dataGridViewPolicias.CurrentRow != null)
            {
                int nroPlaca = Convert.ToInt32(dataGridViewPolicias.CurrentRow.Cells["N° Placa"].Value);

                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este policía?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        string query = "UPDATE Policia SET activo = 0 WHERE nro_placa = @placa";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@placa", nroPlaca);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Policía eliminado correctamente.");
                    CargarPolicias();
                }
            }
        }

        private void btnEditarPolicia_Click(object sender, EventArgs e)
        {
            if (dataGridViewPolicias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un policía para editar.");
                return;
            }

            int nroPlaca = Convert.ToInt32(dataGridViewPolicias.CurrentRow.Cells["N° Placa"].Value);
            string nombre = textBoxNombre.Text.Trim();
            string apellido = textBoxApellido.Text.Trim();
            string dni = textBoxDNI.Text.Trim();
            string genero = comboBoxGenero.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(genero))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"UPDATE Policia 
                                 SET apellido=@apellido, nombre=@nombre, dni=@dni, genero=@genero
                                 WHERE nro_placa=@placa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@placa", nroPlaca);
                cmd.Parameters.AddWithValue("@apellido", apellido);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Datos del policía actualizados correctamente.");
            CargarPolicias();
        }

        private void btnPoliciasEliminado_Click(object sender, EventArgs e)
        {
            if (btnPoliciasEliminado.Text == "Ver Eliminados")
            {
                CargarPoliciasEliminadas();
                btnPoliciasEliminado.Text = "Ver Activos";
            }
            else
            {
                CargarPolicias();
                btnPoliciasEliminado.Text = "Ver Eliminados";
            }
        }

        private void DataGridViewPolicias_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPolicias.CurrentRow != null)
            {
                textBoxApellido.Text = dataGridViewPolicias.CurrentRow.Cells["Apellido"].Value.ToString();
                textBoxNombre.Text = dataGridViewPolicias.CurrentRow.Cells["Nombre"].Value.ToString();
                textBoxDNI.Text = dataGridViewPolicias.CurrentRow.Cells["DNI"].Value.ToString();
                comboBoxGenero.Text = dataGridViewPolicias.CurrentRow.Cells["Género"].Value.ToString();

                btnEditarPolicia.Enabled = true;
                btnEliminarPolicia.Enabled = true;
            }
        }

        // ================== AUXILIARES ==================

        private void LimpiarFormulario()
        {
            textBoxApellido.Text = "";
            textBoxNombre.Text = "";
            textBoxDNI.Text = "";
            comboBoxGenero.SelectedIndex = -1;
            btnEditarPolicia.Enabled = false;
            btnEliminarPolicia.Enabled = false;
        }
    }
}
