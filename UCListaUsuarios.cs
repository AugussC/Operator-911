using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Operador_911
{
    public partial class UCListaUsuarios : UserControl
    {
        public UCListaUsuarios()
        {
            InitializeComponent();

            textBoxNombre.KeyPress += textBoxNombre_KeyPress;
            textBoxApellido.KeyPress += textBoxApellido_KeyPress;
            textBoxDNI.KeyPress += textBoxDNI_KeyPress;
            textBoxContraseña.KeyPress += textBoxContraseña_KeyPress;
            CargarUsuarios();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void labelCodigo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void UCListaUsuarios_Load(object sender, EventArgs e)
        {
            dataGridUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        // validacion

        // Nombre: solo letras y espacio
        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Apellido: igual que nombre
        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // DNI: solo números
        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Contraseña: podés elegir reglas (ej: letras y números, sin espacios)
        private void textBoxContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ejemplo: no permitir espacios
            if (char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text.Trim();
            string apellido = textBoxApellido.Text.Trim();
            string dni = textBoxDNI.Text.Trim();
            string correo = textBoxCorreo.Text.Trim();
            string contraseña = textBoxContraseña.Text.Trim();
            string confirmarContraseña = textBoxConfirmarContraseña.Text.Trim();
            string rol = comboBoxRol.SelectedItem != null ? comboBoxRol.SelectedItem.ToString() : "";

            // 🔹 Validaciones
            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(dni) ||
                string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(contraseña) ||
                string.IsNullOrEmpty(confirmarContraseña) ||
                string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            // Validar DNI solo números
            if (!dni.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe contener solo números.");
                return;
            }

            // Validar confirmación de contraseña
            if (contraseña != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            // Validar rol permitido
            string[] rolesPermitidos = { "Jefe Operador", "Operador", "Comisario" };
            if (!rolesPermitidos.Contains(rol))
            {
                MessageBox.Show("Seleccione un rol válido (Jefe Operador, Operador o Comisario).");
                return;
            }

            // 🔹 Hashear la contraseña
            string contraseñaHash = HashPassword(contraseña);

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "INSERT INTO Usuario (nombre, apellido, dni, correo, contraseña, rol, activo) " +
                                   "VALUES (@nombre, @apellido, @dni, @correo, @contraseña, @rol, 1)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contraseña", contraseñaHash);
                    cmd.Parameters.AddWithValue("@rol", rol);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario agregado correctamente ✅");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message);
            }
        }


        private void CargarUsuarios()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id_usuario, nombre, apellido, DNI, correo, rol, activo FROM Usuario WHERE activo = 1";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridUsuarios.DataSource = dt;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMostrarContraseña_Click(object sender, EventArgs e)
        {
            // Cambia entre mostrar y ocultar
            if (textBoxContraseña.UseSystemPasswordChar)
            {
                textBoxContraseña.UseSystemPasswordChar = false; // Mostrar
                btnMostrarContraseña.Text = "🙈"; // Cambia el icono
            }
            else
            {
                textBoxContraseña.UseSystemPasswordChar = true; // Ocultar
                btnMostrarContraseña.Text = "👁"; // Cambia el icono
            }
        }

        private void btnMostrarConfirmarContraseña_Click(object sender, EventArgs e)
        {
            // Cambia entre mostrar y ocultar
            if (textBoxConfirmarContraseña.UseSystemPasswordChar)
            {
                textBoxConfirmarContraseña.UseSystemPasswordChar = false; // Mostrar
                btnMostrarConfirmarContraseña.Text = "🙈"; // Cambia el icono
            }
            else
            {
                textBoxConfirmarContraseña.UseSystemPasswordChar = true; // Ocultar
                btnMostrarConfirmarContraseña.Text = "👁"; // Cambia el icono
            }
        }
        private void CargarUsuariosEliminados()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id_usuario, nombre, apellido, DNI, correo, rol, activo FROM Usuario WHERE activo = 0";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridUsuarios.DataSource = dt;
            }
        }
        private void btnUsuarioEliminado_Click(object sender, EventArgs e)
        {
            if (btnUsuarioEliminado.Text == "Ver Usuarios Eliminados")
            {
                CargarUsuariosEliminados();
                btnUsuarioEliminado.Text = "Ver Usuarios Activos";
            }
            else
            {
                CargarUsuarios();
                btnUsuarioEliminado.Text = "Ver Usuarios Eliminados";
            }
            
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridUsuarios.CurrentRow != null)
            {
                int idUsuario = Convert.ToInt32(dataGridUsuarios.CurrentRow.Cells["id_usuario"].Value);

                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este usuario?",
                                                      "Confirmación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = Database.GetConnection())
                    {
                        string query = "UPDATE Usuario SET activo = 0 WHERE id_usuario = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuario desactivado correctamente.");
                    CargarUsuarios(); // refresca la grilla con solo activos
                }
            }
        }

        private void dataGridUsuarios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridUsuarios.Columns["activo"].Index && e.RowIndex >= 0)
            {
                int idUsuario = Convert.ToInt32(dataGridUsuarios.Rows[e.RowIndex].Cells["id_usuario"].Value);
                bool nuevoEstado = Convert.ToBoolean(dataGridUsuarios.Rows[e.RowIndex].Cells["activo"].Value);

                if (nuevoEstado)
                    ActivarUsuario(idUsuario, e.RowIndex);
                else
                    DesactivarUsuario(idUsuario, e.RowIndex);
            }
        }

        private void ActivarUsuario(int idUsuario, int rowIndex)
        {
            DialogResult result = MessageBox.Show(
                "¿Desea activar este usuario?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = Database.GetConnection()) // conexión ya abierta
                {
                    string query = "UPDATE Usuario SET activo = 1 WHERE id_usuario = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario activado correctamente.");
                CargarUsuariosEliminados();
            }
            else
            {
                // Restaurar valor anterior si cancela
                dataGridUsuarios.CellValueChanged -= dataGridUsuarios_CellValueChanged;
                dataGridUsuarios.Rows[rowIndex].Cells["activo"].Value = false;
                dataGridUsuarios.CellValueChanged += dataGridUsuarios_CellValueChanged;
            }
        }



        private void DesactivarUsuario(int idUsuario, int rowIndex)
        {
            DialogResult result = MessageBox.Show(
                "¿Desea desactivar este usuario?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = Database.GetConnection()) // conexión ya abierta
                {
                    string query = "UPDATE Usuario SET activo = 0 WHERE id_usuario = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario desactivado correctamente.");
                CargarUsuarios();
            }
            else
            {
                // Restaurar valor anterior si cancela
                dataGridUsuarios.CellValueChanged -= dataGridUsuarios_CellValueChanged;
                dataGridUsuarios.Rows[rowIndex].Cells["activo"].Value = true;
                dataGridUsuarios.CellValueChanged += dataGridUsuarios_CellValueChanged;
            }
        }



        private void dataGridUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridUsuarios.CurrentRow != null)
            {
                textBoxNombre.Text = dataGridUsuarios.CurrentRow.Cells["nombre"].Value.ToString();
                textBoxApellido.Text = dataGridUsuarios.CurrentRow.Cells["apellido"].Value.ToString();
                textBoxDNI.Text = dataGridUsuarios.CurrentRow.Cells["DNI"].Value.ToString();
                textBoxCorreo.Text = dataGridUsuarios.CurrentRow.Cells["correo"].Value.ToString();
                comboBoxRol.Text = dataGridUsuarios.CurrentRow.Cells["rol"].Value.ToString();
            }
        }

        private void dataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // para que no tome el header
            {
                DataGridViewRow fila = dataGridUsuarios.Rows[e.RowIndex];

                textBoxNombre.Text = fila.Cells["nombre"].Value.ToString();
                textBoxApellido.Text = fila.Cells["apellido"].Value.ToString();
                textBoxDNI.Text = fila.Cells["DNI"].Value.ToString();
                textBoxCorreo.Text = fila.Cells["correo"].Value.ToString();
                comboBoxRol.Text = fila.Cells["rol"].Value.ToString();
            }
        }

        private void dataGridUsuarios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridUsuarios.IsCurrentCellDirty)
            {
                dataGridUsuarios.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }
    }
}
