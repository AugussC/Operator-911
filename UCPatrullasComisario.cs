using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Operador_911.FormLogin;

namespace Operador_911
{
    public partial class UCPatrullasComisario : UserControl
    {
        public UCPatrullasComisario()
        {
            InitializeComponent();

            textNroVehiculo.KeyPress += textNroVehiculo_KeyPress;

            CargarPatrullas();

            dataGridViewPatrullas.DataBindingComplete += DataGridViewPatrullas_DataBindingComplete;
        }

        private void DataGridViewPatrullas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewPatrullas.ClearSelection();
            LimpiarFormulario();
        }

        private void UCPatrullasComisario_Load(object sender, EventArgs e)
        {
            dataGridViewPatrullas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            btnEditarPatrulla.Enabled = false;
            btnEliminarPatrulla.Enabled = false;
            dataGridViewPatrullas.ClearSelection();
            dataGridViewPatrullas.SelectionChanged += DataGridViewPatrullas_SelectionChanged;
        }

        private void textNroVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAgregarPatrulla_Click(object sender, EventArgs e)
        {
            string nroPatrulla = textNroVehiculo.Text.Trim();
            string tipoPatrulla = TipoVehiculoBox.SelectedItem != null ? TipoVehiculoBox.SelectedItem.ToString() : "";
            string estadoPatrulla = EstadoVehiculoBox.SelectedItem != null ? EstadoVehiculoBox.SelectedItem.ToString() : "";

            if (string.IsNullOrEmpty(nroPatrulla) ||
                string.IsNullOrEmpty(tipoPatrulla) ||
                string.IsNullOrEmpty(estadoPatrulla))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!nroPatrulla.All(char.IsDigit))
            {
                MessageBox.Show("El número de vehículo debe contener solo números.");
                return;
            }

            string[] TipoPatrullaPermitidos = { "Moto", "Auto" };
            if (!TipoPatrullaPermitidos.Contains(tipoPatrulla))
            {
                MessageBox.Show("Seleccione un Tipo de vehículo válido (Moto, Auto).");
                return;
            }

            string[] estadoPatrullaPermitidos = { "En Servicio", "En Base" };
            if (!estadoPatrullaPermitidos.Contains(estadoPatrulla))
            {
                MessageBox.Show("Seleccione estado válido (En Servicio, En Base).");
                return;
            }

            // Generar el código de vehículo
            string codigoPatrulla = tipoPatrulla == "Auto"
                ? "A-" + nroPatrulla.PadLeft(3, '0')
                : "M-" + nroPatrulla.PadLeft(3, '0');

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string queryComisaria = "SELECT id_comisaria FROM Comisaria WHERE id_usuario_comisario = @idUsuario";
                    SqlCommand cmdComisaria = new SqlCommand(queryComisaria, conn);
                    cmdComisaria.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuario);
                    int idComisaria = Convert.ToInt32(cmdComisaria.ExecuteScalar());

                    string query = "INSERT INTO Patrulla (codigo_patrulla, tipo, estado, id_comisaria, activo) " +
                                   "VALUES(@codigo, @tipo, @estado, @idComisaria, 1)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codigo", codigoPatrulla);
                    cmd.Parameters.AddWithValue("@tipo", tipoPatrulla);
                    cmd.Parameters.AddWithValue("@estado", estadoPatrulla);
                    cmd.Parameters.AddWithValue("@idComisaria", idComisaria);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vehículo agregado correctamente");
                    CargarPatrullas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Vehículo: " + ex.Message);
            }
        }

        private void CargarPatrullas()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id_patrulla, codigo_patrulla, tipo, estado, activo FROM Patrulla WHERE activo = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewPatrullas.DataSource = dt;
            }

            dataGridViewPatrullas.ClearSelection();
            LimpiarFormulario();
        }


        private void CargarPatrullasEliminadas()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id_patrulla, codigo_patrulla, tipo, estado, activo FROM Patrulla WHERE activo = 0";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewPatrullas.DataSource = dt;
            }
            dataGridViewPatrullas.ClearSelection();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            textNroVehiculo.Text = "";
            TipoVehiculoBox.SelectedIndex = -1;
            EstadoVehiculoBox.SelectedIndex = -1;
            btnEditarPatrulla.Enabled = false;
            btnEliminarPatrulla.Enabled = false;
        }

        private void btnVehiculosEliminado_Click(object sender, EventArgs e)
        {
            if (btnVehiculosEliminado.Text == "Ver Eliminados")
            {
                CargarPatrullasEliminadas();
                btnVehiculosEliminado.Text = "Ver Activos";
            }
            else
            {
                CargarPatrullas();
                btnVehiculosEliminado.Text = "Ver Eliminados";
            }
        }

        private void btnEliminarPatrulla_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatrullas.CurrentRow != null)
            {
                int idPatrulla = Convert.ToInt32(dataGridViewPatrullas.CurrentRow.Cells["id_patrulla"].Value);

                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este vehículo?",
                                                      "Confirmación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        string query = "UPDATE Patrulla SET activo = 0 WHERE id_patrulla = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idPatrulla);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Vehículo eliminado correctamente.");
                    CargarPatrullas();
                }
            }
        }

        private void btnEditarPatrulla_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatrullas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un vehículo para editar.");
                return;
            }

            int idPatrulla = Convert.ToInt32(dataGridViewPatrullas.CurrentRow.Cells["id_patrulla"].Value);
            string nroPatrulla = textNroVehiculo.Text.Trim();
            string tipoPatrulla = TipoVehiculoBox.SelectedItem != null ? TipoVehiculoBox.SelectedItem.ToString() : "";
            string estadoPatrulla = EstadoVehiculoBox.SelectedItem != null ? EstadoVehiculoBox.SelectedItem.ToString() : "";

            if (string.IsNullOrEmpty(nroPatrulla) ||
                string.IsNullOrEmpty(tipoPatrulla) ||
                string.IsNullOrEmpty(estadoPatrulla))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!nroPatrulla.All(char.IsDigit))
            {
                MessageBox.Show("El número de vehículo debe contener solo números.");
                return;
            }

            string codigoPatrulla = tipoPatrulla == "Auto"
                ? "A-" + nroPatrulla.PadLeft(3, '0')
                : "M-" + nroPatrulla.PadLeft(3, '0');

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "UPDATE Patrulla SET codigo_patrulla=@codigo, tipo=@tipo, estado=@estado WHERE id_patrulla=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idPatrulla);
                    cmd.Parameters.AddWithValue("@codigo", codigoPatrulla);
                    cmd.Parameters.AddWithValue("@tipo", tipoPatrulla);
                    cmd.Parameters.AddWithValue("@estado", estadoPatrulla);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Vehículo actualizado correctamente.");
                CargarPatrullas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar vehículo: " + ex.Message);
            }
        }

        private void DataGridViewPatrullas_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPatrullas.CurrentRow != null)
            {
                string codigo = dataGridViewPatrullas.CurrentRow.Cells["codigo_patrulla"].Value.ToString();
                textNroVehiculo.Text = codigo.Substring(2); // quitar prefijo A- o M-
                TipoVehiculoBox.Text = dataGridViewPatrullas.CurrentRow.Cells["tipo"].Value.ToString();
                EstadoVehiculoBox.Text = dataGridViewPatrullas.CurrentRow.Cells["estado"].Value.ToString();

                btnEditarPatrulla.Enabled = true;
                btnEliminarPatrulla.Enabled = true;
            }
        }
    }
}
