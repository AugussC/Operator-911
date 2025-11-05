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
    public partial class FormContraseña : Form
    {
        public bool ContraseñaValida { get; private set; } = false;

        public FormContraseña()
        {
            InitializeComponent();
            textContraseña.UseSystemPasswordChar = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string contraseñaIngresada = textContraseña.Text.Trim();
            if (string.IsNullOrEmpty(contraseñaIngresada))
            {
                MessageBox.Show("Ingrese su contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "SELECT contraseña FROM Usuario WHERE id_usuario = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", FormLogin.Sesion.IdUsuario);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string contraseñaHashBDD = result.ToString();
                        string contraseñaHashIngresada = HashPassword(contraseñaIngresada);

                        if (contraseñaHashBDD == contraseñaHashIngresada)
                        {
                            ContraseñaValida = true;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textContraseña.Clear();
                            textContraseña.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Mismo método de hash que en el login
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

        
    }
}
