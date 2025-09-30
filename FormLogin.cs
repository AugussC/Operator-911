using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Operador_911
{
    public partial class FormLogin : Form
    {

        public static class Sesion
        {
            public static int IdUsuario { get; set; }
            public static string Nombre { get; set; }
            public static string Rol { get; set; }
        }


        public FormLogin()
        {
            InitializeComponent();
            // Manejo de validación en tiempo de escritura
            textBoxContraseña.KeyPress += textBoxContraseña_KeyPress;
        }

        // Método para limpiar la sesión
        public static void CerrarSesion()
        {
            Sesion.IdUsuario = 0;
            Sesion.Nombre = null;
            Sesion.Rol = null;
        }

        private void textBoxContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se verifica que la letra no sea un espacio en blanco y que tampco sea una tecla de control (como Backspace)
            if (char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// Hashea la contraseña en SHA256.
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

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            string correo = textBoxCorreo.Text.Trim();
            string contraseña = textBoxContraseña.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor ingrese correo y contraseña.");
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "SELECT id_usuario, nombre, contraseña, rol FROM Usuario WHERE correo = @correo AND activo = 1";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@correo", correo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int idUsuarioEncontrado = Convert.ToInt32(reader["id_usuario"]);
                        string nombreUsuario = reader["nombre"].ToString();
                        string contraseñaHash = reader["contraseña"].ToString();
                        string rol = reader["rol"].ToString();

                        // Verificar la contraseña ingresada con la hasheada
                        if (contraseñaHash == HashPassword(contraseña))
                        {
                            MessageBox.Show($"Bienvenido {rol}, ha iniciado sesión correctamente.");

                            // Guardar datos en la clase estática Sesion
                            Sesion.IdUsuario = idUsuarioEncontrado;
                            Sesion.Nombre = nombreUsuario;
                            Sesion.Rol = rol;

                            Form nextForm = null;
                            switch (rol)
                            {
                                case "Jefe Operador":
                                    nextForm = new FormJefeOperador();
                                    break;
                                case "Operador":
                                    nextForm = new FormOperador();
                                    break;
                                case "Comisario":
                                    nextForm = new FormComisario();
                                    break;
                                default:
                                    MessageBox.Show("Rol desconocido.");
                                    return;
                            }

                            // Cuando se cierre el form, limpiar sesión y volver al login
                            nextForm.FormClosed += (s, args) =>
                            {
                                CerrarSesion(); // Limpia los datos
                                this.Show();
                                textBoxContraseña.Clear();
                                textBoxCorreo.Clear();
                            };

                            nextForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Correo no encontrado o usuario inactivo.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxContraseña.UseSystemPasswordChar = !checkBoxContraseña.Checked;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBoxContraseña.UseSystemPasswordChar = true;
        }
    }
}
