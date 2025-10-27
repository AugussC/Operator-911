using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Operador_911
{
    public partial class FormReporte : Form
    {
        private int _idAlerta;

        public FormReporte(int idAlerta)
        {
            InitializeComponent();
            _idAlerta = idAlerta;
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT a.id_alerta, a.direccion, a.tipo_incidencia, 
                     l.nombre, l.telefono
              FROM Alerta a
              LEFT JOIN Llamada l ON a.id_alerta = l.id_alerta
              WHERE a.id_alerta = @id", con);

                cmd.Parameters.AddWithValue("@id", _idAlerta);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBoxDireccion.Text = dr["direccion"].ToString();
                    textBoxIncidente.Text = dr["tipo_incidencia"].ToString();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

