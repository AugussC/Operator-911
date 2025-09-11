using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
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
                    string query = "SELECT correo, contraseña, rol FROM Usuario WHERE correo = @correo AND contraseña = @contraseña AND activo = 1";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // Si encontró un usuario
                    {
                        string rol = reader["rol"].ToString();

                        MessageBox.Show($"Bienvenido, su rol es: {rol}");

                        // Abrir formulario según el rol
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

                        // Evento: cuando se cierra el formulario abierto, se cierra también el login oculto
                        nextForm.FormClosed += (s, args) => this.Close();

                        this.Hide();      // Oculta el formulario de login
                        nextForm.Show();  // Muestra el formulario correspondiente
                    }
                    else
                    {
                        MessageBox.Show("Correo o contraseña incorrectos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message);
            }
        }

    }
}
