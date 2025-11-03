using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operador_911
{
    public partial class FormReporteGenerado : Form
    {
        public FormReporteGenerado(string textoReporte, string FechaReporte, string NumeroReporte)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            textReporte.Text = textoReporte;
            textFecha.Text = FechaReporte;
            textNumeroReporte.Text = NumeroReporte;
        }

        private void labelTituloReporte_Click(object sender, EventArgs e)
        {

        }

        private void FormReporteGenerado_Load(object sender, EventArgs e)
        {
            textReporte.SelectionLength = 0;
            textReporte.SelectionStart = 0;
        }

        private void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear documento PDF
                Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

                string idReporte = textNumeroReporte.Text.Trim();
                string nombreArchivo = $"ReportePolicial_N{idReporte}.pdf";
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);

                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                // Fuentes
                var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 11);

                // Tabla para encabezado
                PdfPTable encabezado = new PdfPTable(3);
                encabezado.WidthPercentage = 100;
                encabezado.SetWidths(new float[] { 20, 60, 20 });

                // Imagen izquierda
                if (pictureBox1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        iTextSharp.text.Image imgIzq = iTextSharp.text.Image.GetInstance(ms.ToArray());
                        imgIzq.ScaleToFit(70f, 70f);
                        PdfPCell celdaIzq = new PdfPCell(imgIzq)
                        {
                            Border = iTextSharp.text.Rectangle.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_LEFT
                        };
                        encabezado.AddCell(celdaIzq);
                    }
                }
                else
                    encabezado.AddCell(new PdfPCell() { Border = iTextSharp.text.Rectangle.NO_BORDER });

                // Texto central
                PdfPCell celdaCentro = new PdfPCell(
                    new Phrase("República Argentina\nPolicía de la Provincia de Corrientes\n", fuenteTitulo))
                {
                    Border = iTextSharp.text.Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                encabezado.AddCell(celdaCentro);

                // Imagen derecha
                if (pictureBox2.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        iTextSharp.text.Image imgDer = iTextSharp.text.Image.GetInstance(ms.ToArray());
                        imgDer.ScaleToFit(70f, 70f);
                        PdfPCell celdaDer = new PdfPCell(imgDer)
                        {
                            Border = iTextSharp.text.Rectangle.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_RIGHT
                        };
                        encabezado.AddCell(celdaDer);
                    }
                }
                else
                    encabezado.AddCell(new PdfPCell() { Border = iTextSharp.text.Rectangle.NO_BORDER });

                doc.Add(encabezado);
                doc.Add(new Paragraph("\n"));

                // Número de reporte
                Paragraph numero = new Paragraph($"Reporte N° {textNumeroReporte.Text}", fuenteSubtitulo);
                numero.Alignment = Element.ALIGN_CENTER;
                doc.Add(numero);
                doc.Add(new Paragraph("\n"));

                // Texto principal del reporte
                Paragraph cuerpo = new Paragraph(textReporte.Text, fuenteTexto);
                cuerpo.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(cuerpo);

                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph($"Fecha: {textFecha.Text}", fuenteSubtitulo));

                // Imagen de firma si existe
                if (pictureBox3.Image != null)
                {
                    doc.Add(new Paragraph("\n"));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox3.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(ms.ToArray());
                        imgFirma.ScaleToFit(150f, 60f);
                        imgFirma.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(imgFirma);
                    }
                }

                doc.Close();
                MessageBox.Show($"PDF generado correctamente en el escritorio como '{nombreArchivo}'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelPrimeraParte_Click(object sender, EventArgs e)
        {

        }

        private void labelFecha_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
