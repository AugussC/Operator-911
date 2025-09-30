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
    public partial class UCPatrullasComisario : UserControl
    {

        private bool mostrandoEliminadosVehiculos = false;

        public UCPatrullasComisario()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormOperador_Load);

            textNroVehiculo.KeyPress += textNroVehiculo_KeyPress;
        }

        private void FormOperador_Load(object sender, EventArgs e)
        {
            dataGridViewPatrullas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
        }

        private void textNroVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UCPatrullasComisario_Load(object sender, EventArgs e)
        {

            dataGridViewPatrullas.Rows.Add("V-001", "Auto", "En Servicio");
            dataGridViewPatrullas.Rows.Add("V-002", "Auto", "En Servicio");
            dataGridViewPatrullas.Rows.Add("V-003", "Moto", "En Servicio");
            dataGridViewPatrullas.Rows.Add("V-004", "Auto", "En Base");
            dataGridViewPatrullas.Rows.Add("V-005", "Auto", "En Base");
        }

        private void btnAgregarPatrulla_Click(object sender, EventArgs e)
        {
            string nroVehiculo = textNroVehiculo.Text.Trim();
            string tipoVehiculo = TipoVehiculoBox.SelectedItem != null ? TipoVehiculoBox.SelectedItem.ToString() : "";
            string estadoVehiculo = EstadoVehiculoBox.SelectedItem != null ? EstadoVehiculoBox.SelectedItem.ToString() : "";

            if (string.IsNullOrEmpty(nroVehiculo) ||
                string.IsNullOrEmpty(tipoVehiculo) ||
                string.IsNullOrEmpty(estadoVehiculo))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!nroVehiculo.All(char.IsDigit))
            {
                MessageBox.Show("El número de vehículo debe contener solo números.");
                return;
            }

            string[] TipoVehiculoPermitidos = { "Moto", "Auto" };
            if (!TipoVehiculoPermitidos.Contains(tipoVehiculo))
            {
                MessageBox.Show("Seleccione un Tipo de vehículo válido (Moto, Auto).");
                return;
            }

            string[] estadoVehiculoPermitidos = { "En Servicio", "En Base" };
            if (!estadoVehiculoPermitidos.Contains(estadoVehiculo))
            {
                MessageBox.Show("Seleccione estado válido (En Servicio, En Base).");
                return;
            }

            // Generar el código de vehículo
            string codigoVehiculo = "";
            if (tipoVehiculo == "Auto")
                codigoVehiculo = "A-" + nroVehiculo.PadLeft(3, '0'); // ejemplo: A-001
            else if (tipoVehiculo == "Moto")
                codigoVehiculo = "M-" + nroVehiculo.PadLeft(3, '0'); // ejemplo: M-005

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    // Obtener id_comisaria del usuario actual
                    string queryComisaria = "SELECT id_comisaria FROM Usuario WHERE id_usuario = @idUsuario";
                    SqlCommand cmdComisaria = new SqlCommand(queryComisaria, conn);
                    cmdComisaria.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuario);
                    int idComisaria = Convert.ToInt32(cmdComisaria.ExecuteScalar());

                    // Insertar el vehículo asociado a la comisaría
                    string query = "INSERT INTO Vehiculo (codigo, tipo, estado, id_comisaria) VALUES (@codigo, @tipo, @estado, @idComisaria)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codigo", codigoVehiculo);
                    cmd.Parameters.AddWithValue("@tipo", tipoVehiculo);
                    cmd.Parameters.AddWithValue("@estado", estadoVehiculo);
                    cmd.Parameters.AddWithValue("@idComisaria", idComisaria);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vehículo agregado correctamente");
                    CargarVehiculos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Vehículo: " + ex.Message);
            }
        }

        private void CargarVehiculos()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = mostrandoEliminadosVehiculos
                    ? "SELECT id_vehiculo, codigo, tipo, estado, activo FROM Vehiculo WHERE activo = 0"
                    : "SELECT id_vehiculo, codigo, tipo, estado, activo FROM Vehiculo WHERE activo = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewPatrullas.DataSource = dt;
            }

            dataGridViewPatrullas.ClearSelection();
            LimpiarFormularioVehiculos();
        }


        private void LimpiarFormularioVehiculos()
        {

            textNroVehiculo.Text = "";
            TipoVehiculoBox.SelectedIndex = -1;
            EstadoVehiculoBox.SelectedIndex = -1;
            btnEditarPatrulla.Enabled = false;
            btnEliminarPatrulla.Enabled = false;
        }

        private void btnEliminarPatrulla_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatrullas.CurrentRow != null)
            {
                int idVehiculo = Convert.ToInt32(dataGridViewPatrullas.CurrentRow.Cells["id_vehiculo"].Value);

                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este vehículo?",
                                                      "Confirmación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        string query = "UPDATE Vehiculo SET activo = 0 WHERE id_vehiculo = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idVehiculo);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Vehículo eliminado correctamente.");
                    CargarVehiculos();
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

            int idVehiculo = Convert.ToInt32(dataGridViewPatrullas.CurrentRow.Cells["id_vehiculo"].Value);
            string nroVehiculo = textNroVehiculo.Text.Trim();
            string tipoVehiculo = TipoVehiculoBox.SelectedItem != null ? TipoVehiculoBox.SelectedItem.ToString() : "";
            string estadoVehiculo = EstadoVehiculoBox.SelectedItem != null ? EstadoVehiculoBox.SelectedItem.ToString() : "";

            if (string.IsNullOrEmpty(nroVehiculo) ||
                string.IsNullOrEmpty(tipoVehiculo) ||
                string.IsNullOrEmpty(estadoVehiculo))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!nroVehiculo.All(char.IsDigit))
            {
                MessageBox.Show("El número de vehículo debe contener solo números.");
                return;
            }

            string codigoVehiculo = tipoVehiculo == "Auto" ? "A-" + nroVehiculo.PadLeft(3, '0') : "M-" + nroVehiculo.PadLeft(3, '0');

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "UPDATE Vehiculo SET codigo=@codigo, tipo=@tipo, estado=@estado WHERE id_vehiculo=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idVehiculo);
                    cmd.Parameters.AddWithValue("@codigo", codigoVehiculo);
                    cmd.Parameters.AddWithValue("@tipo", tipoVehiculo);
                    cmd.Parameters.AddWithValue("@estado", estadoVehiculo);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Vehículo actualizado correctamente.");
                CargarVehiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar vehículo: " + ex.Message);
            }
        }

        private void btnVehiculosEliminado_Click(object sender, EventArgs e)
        {
            mostrandoEliminadosVehiculos = !mostrandoEliminadosVehiculos;

            if (mostrandoEliminadosVehiculos)
            {
                btnVehiculosEliminado.Text = "Ver Activos";
                btnEliminarPatrulla.Enabled = false;
                btnEditarPatrulla.Enabled = false;
            }
            else
            {
                btnVehiculosEliminado.Text = "Ver Eliminados";
            }

            CargarVehiculos();
        }
    }
}
