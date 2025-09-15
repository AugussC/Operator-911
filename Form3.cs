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

namespace Operador_911
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBoxContraseña.KeyPress += textBoxContraseña_KeyPress;
        }

        


        // validacion

        

        // Contraseña: podés elegir reglas (ej: letras y números, sin espacios)
        private void textBoxContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ejemplo: no permitir espacios
            if (char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
                    string query = "SELECT contraseña, rol FROM Usuario WHERE correo = @correo AND activo = 1";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@correo", correo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string contraseñaHash = reader["contraseña"].ToString();
                        string rol = reader["rol"].ToString();

                        // Verificar la contraseña ingresada con la hasheada
                        if (contraseñaHash == HashPassword(contraseña))
                        {
                            MessageBox.Show($"Bienvenido, su rol es: {rol}");

                            Form nextForm = null;
                            switch (rol)
                            {
                                case "Jefe Operador":
                                    nextForm = new Form2();
                                    break;
                                case "Operador":
                                    nextForm = new Form1();
                                    break;
                                case "Comisario":
                                    nextForm = new Form4();
                                    break;
                                default:
                                    MessageBox.Show("Rol desconocido.");
                                    return;
                            }

                            nextForm.FormClosed += (s, args) => this.Close();
                            this.Hide();
                            nextForm.Show();
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

        private void labelCorreo_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labelContraseña_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxContraseña_TextChanged(object sender, EventArgs e)
        {
            
        }

        

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
