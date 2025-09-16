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
            dataGridUsuarios.DataBindingComplete += DataGridUsuarios_DataBindingComplete;

        }

        private void DataGridUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridUsuarios.ClearSelection(); // Quita la selección inicial
            LimpiarFormulario(); // Limpiar formulario y desactivar editar
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
            textBoxContraseña.UseSystemPasswordChar = true;
            textBoxConfirmarContraseña.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxContraseña.UseSystemPasswordChar = !checkBoxContraseña1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxConfirmarContraseña.UseSystemPasswordChar = !checkBoxContraseña2.Checked;
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
            dataGridUsuarios.ClearSelection(); // Evita que se seleccione la primera fila
            LimpiarFormulario(); // Limpia los TextBox y desactiva editar

        }

        private void LimpiarFormulario()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxDNI.Text = "";
            textBoxCorreo.Text = "";
            comboBoxRol.SelectedIndex = -1;
            textBoxContraseña.Text = "";
            textBoxConfirmarContraseña.Text = "";
            btnEditarUsuario.Enabled = false;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            dataGridUsuarios.ClearSelection(); // Evita que se seleccione la primera fila
            LimpiarFormulario(); // Limpia los TextBox y desactiva editar

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
            if (e.RowIndex >= 0) // Solo si es fila de datos, no encabezado
            {
                DataGridViewRow fila = dataGridUsuarios.Rows[e.RowIndex];

                textBoxNombre.Text = fila.Cells["nombre"].Value.ToString();
                textBoxApellido.Text = fila.Cells["apellido"].Value.ToString();
                textBoxDNI.Text = fila.Cells["DNI"].Value.ToString();
                textBoxCorreo.Text = fila.Cells["correo"].Value.ToString();
                comboBoxRol.Text = fila.Cells["rol"].Value.ToString();

                btnEditarUsuario.Enabled = true; // Activar editar solo si hay selección
            }
        }


        private void dataGridUsuarios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridUsuarios.IsCurrentCellDirty)
            {
                dataGridUsuarios.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            // Validar selección
            if (dataGridUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para editar.");
                return;
            }

            int idUsuario = Convert.ToInt32(dataGridUsuarios.CurrentRow.Cells["id_usuario"].Value);

            // Obtener datos de los TextBox
            string nombre = textBoxNombre.Text.Trim();
            string apellido = textBoxApellido.Text.Trim();
            string dni = textBoxDNI.Text.Trim();
            string correo = textBoxCorreo.Text.Trim();
            string rol = comboBoxRol.SelectedItem != null ? comboBoxRol.SelectedItem.ToString() : "";

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(dni) ||
                string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("Todos los campos obligatorios deben estar completos.");
                return;
            }

            // Validar DNI solo números
            if (!dni.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe contener solo números.");
                return;
            }

            // Validar rol permitido
            string[] rolesPermitidos = { "Jefe Operador", "Operador", "Comisario" };
            if (!rolesPermitidos.Contains(rol))
            {
                MessageBox.Show("Seleccione un rol válido (Jefe Operador, Operador o Comisario).");
                return;
            }

            // Contraseña opcional: solo se actualiza si el usuario la completa
            string contraseña = textBoxContraseña.Text.Trim();
            string confirmarContraseña = textBoxConfirmarContraseña.Text.Trim();
            string contraseñaHash = null;

            if (!string.IsNullOrEmpty(contraseña) || !string.IsNullOrEmpty(confirmarContraseña))
            {
                if (contraseña != confirmarContraseña)
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                    return;
                }
                contraseñaHash = HashPassword(contraseña);
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query;

                    if (contraseñaHash != null)
                    {
                        query = "UPDATE Usuario SET nombre=@nombre, apellido=@apellido, dni=@dni, correo=@correo, rol=@rol, contraseña=@contraseña WHERE id_usuario=@id";
                    }
                    else
                    {
                        query = "UPDATE Usuario SET nombre=@nombre, apellido=@apellido, dni=@dni, correo=@correo, rol=@rol WHERE id_usuario=@id";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@dni", dni);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@rol", rol);

                        if (contraseñaHash != null)
                            cmd.Parameters.AddWithValue("@contraseña", contraseñaHash);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario actualizado correctamente ✅");

                // Refrescar grilla
                CargarUsuarios();

                // Limpiar campos de contraseña
                textBoxContraseña.Text = "";
                textBoxConfirmarContraseña.Text = "";
                LimpiarFormulario();
                dataGridUsuarios.ClearSelection();

                if (btnUsuarioEliminado.Text == "Ver Usuarios Eliminados")
                {
                    CargarUsuarios();
                }
                else
                {
                    
                    CargarUsuariosEliminados();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBuscado = textBoxBuscar.Text.Trim();
            string query = ""; // Declaramos fuera del if

            using (SqlConnection conn = Database.GetConnection())
            {
                if (btnUsuarioEliminado.Text == "Ver Usuarios Eliminados")
                {
                    
                    query = @"SELECT id_usuario, nombre, apellido, DNI, correo, rol, activo
                      FROM Usuario
                      WHERE activo = 1 
                      AND (nombre LIKE @texto 
                           OR correo LIKE @texto 
                           OR DNI LIKE @texto)";
                }
                else
                {
                    
                    query = @"SELECT id_usuario, nombre, apellido, DNI, correo, rol, activo
                      FROM Usuario
                      WHERE activo = 0 
                      AND (nombre LIKE @texto 
                           OR correo LIKE @texto 
                           OR DNI LIKE @texto)";
                }

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@texto", "%" + textoBuscado + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridUsuarios.DataSource = dt;
            }

            dataGridUsuarios.ClearSelection();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }
    }

}

