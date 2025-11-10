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
            catch (SqlException ex)
            {
                // Manejo específico de errores de SQL
                switch (ex.Number)
                {
                    case 2627: // violación de clave única
                        MessageBox.Show("Ya existe un vehículo con ese código.");
                        break;
                    case -1: // servidor no encontrado
                        MessageBox.Show("No se pudo conectar al servidor de base de datos.");
                        break;
                    default:
                        MessageBox.Show("Error de base de datos: " + ex.Message);
                        break;
                }
            }
        }

        private void CargarPatrullas()
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

                // ⚠️ Incluimos id_patrulla (necesario para editar/eliminar) pero lo ocultamos después
                string query = @"
            SELECT 
                id_patrulla,
                codigo_patrulla AS 'Código Patrulla',
                tipo AS 'Tipo de Vehículo',
                estado AS 'Estado',
                activo AS 'Activo'
            FROM Patrulla 
            WHERE activo = 1 AND id_comisaria = @idComisaria";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@idComisaria", idComisaria);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewPatrullas.DataSource = dt;
            }

            // Ocultamos la columna id_patrulla
            if (dataGridViewPatrullas.Columns.Contains("id_patrulla"))
                dataGridViewPatrullas.Columns["id_patrulla"].Visible = false;

            dataGridViewPatrullas.ClearSelection();
            LimpiarFormulario();
        }

        private void CargarPatrullasEliminadas()
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
                id_patrulla,
                codigo_patrulla AS 'Código Patrulla',
                tipo AS 'Tipo de Vehículo',
                estado AS 'Estado',
                activo AS 'Activo'
            FROM Patrulla 
            WHERE activo = 0 AND id_comisaria = @idComisaria";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@idComisaria", idComisaria);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewPatrullas.DataSource = dt;
            }

            // Ocultamos la columna id_patrulla
            if (dataGridViewPatrullas.Columns.Contains("id_patrulla"))
                dataGridViewPatrullas.Columns["id_patrulla"].Visible = false;

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
                LimpiarFormulario();
                dataGridViewPatrullas.ClearSelection();

                if (btnVehiculosEliminado.Text == "Ver Eliminados")
                {

                    CargarPatrullas();

                }
                else
                {
                    CargarPatrullasEliminadas();
                }

            }
            catch (SqlException ex)
            {
                // Manejo específico de errores de SQL
                switch (ex.Number)
                {
                    case 2627: // violación de clave única
                        MessageBox.Show("Ya existe un vehículo con ese código.");
                        break;
                    case -1: // servidor no encontrado
                        MessageBox.Show("No se pudo conectar al servidor de base de datos.");
                        break;
                    default:
                        MessageBox.Show("Error de base de datos: " + ex.Message);
                        break;
                }
            }
        }

        private void DataGridViewPatrullas_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPatrullas.CurrentRow != null)
            {
                string codigo = dataGridViewPatrullas.CurrentRow.Cells["Código Patrulla"].Value.ToString();
                textNroVehiculo.Text = codigo.Substring(2); // quitar prefijo A- o M-
                TipoVehiculoBox.Text = dataGridViewPatrullas.CurrentRow.Cells["Tipo de Vehículo"].Value.ToString();
                EstadoVehiculoBox.Text = dataGridViewPatrullas.CurrentRow.Cells["Estado"].Value.ToString();

                btnEditarPatrulla.Enabled = true;
                btnEliminarPatrulla.Enabled = true;
            }

            if (dataGridViewPatrullas.CurrentRow == null)
            {
                btnEditarPatrulla.Enabled = false;
                btnEliminarPatrulla.Enabled = false;
            }
            

        }

        private void dataGridViewPatrullas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPatrullas.Columns["activo"].Index && e.RowIndex >= 0)
            {
                int idPatrulla = Convert.ToInt32(dataGridViewPatrullas.Rows[e.RowIndex].Cells["id_patrulla"].Value);
                bool nuevoEstado = Convert.ToBoolean(dataGridViewPatrullas.Rows[e.RowIndex].Cells["activo"].Value);

                if (nuevoEstado)
                    ActivarPatrulla(idPatrulla, e.RowIndex);
                else
                    DesactivarPatrulla(idPatrulla, e.RowIndex);
            }
        }

        private void ActivarPatrulla(int idPatrulla, int rowIndex)
        {
            DialogResult result = MessageBox.Show(
                "¿Desea activar esta patrulla?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "UPDATE Patrulla SET activo = 1 WHERE id_patrulla = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idPatrulla);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Patrulla activada correctamente.");
                CargarPatrullasEliminadas(); // igual que en tu lógica original
            }
            else
            {
                dataGridViewPatrullas.CellValueChanged -= dataGridViewPatrullas_CellValueChanged;
                dataGridViewPatrullas.Rows[rowIndex].Cells["activo"].Value = false;
                dataGridViewPatrullas.CellValueChanged += dataGridViewPatrullas_CellValueChanged;
            }
        }

        private void DesactivarPatrulla(int idPatrulla, int rowIndex)
        {
            DialogResult result = MessageBox.Show(
                "¿Desea desactivar esta patrulla?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "UPDATE Patrulla SET activo = 0 WHERE id_patrulla = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idPatrulla);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Patrulla desactivada correctamente.");
                CargarPatrullas();
            }
            else
            {
                dataGridViewPatrullas.CellValueChanged -= dataGridViewPatrullas_CellValueChanged;
                dataGridViewPatrullas.Rows[rowIndex].Cells["activo"].Value = true;
                dataGridViewPatrullas.CellValueChanged += dataGridViewPatrullas_CellValueChanged;
            }
        }

        private void dataGridUsuarios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewPatrullas.IsCurrentCellDirty)
            {
                dataGridViewPatrullas.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBuscado = textBoxBuscar.Text.Trim();

            using (SqlConnection conn = Database.GetConnection())
            {
                // Obtener la comisaría del usuario logueado
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

                // Definir el query según si se están viendo activos o eliminados
                string query;
                if (btnVehiculosEliminado.Text == "Ver Eliminados")
                {
                    // Mostrando activos
                    query = @"SELECT id_patrulla, codigo_patrulla, tipo, estado, activo 
                      FROM Patrulla 
                      WHERE activo = 1 AND id_comisaria = @idComisaria
                      AND (codigo_patrulla LIKE @texto OR tipo LIKE @texto OR estado LIKE @texto)";
                }
                else
                {
                    // Mostrando eliminados
                    query = @"SELECT id_patrulla, codigo_patrulla, tipo, estado, activo 
                      FROM Patrulla 
                      WHERE activo = 0 AND id_comisaria = @idComisaria
                      AND (codigo_patrulla LIKE @texto OR tipo LIKE @texto OR estado LIKE @texto)";
                }

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@texto", "%" + textoBuscado + "%");
                da.SelectCommand.Parameters.AddWithValue("@idComisaria", idComisaria);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewPatrullas.DataSource = dt;
            }

            dataGridViewPatrullas.ClearSelection();
        }



        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }
    }

}

