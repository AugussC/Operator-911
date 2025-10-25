using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Operador_911.FormLogin;
using Excel = Microsoft.Office.Interop.Excel;


namespace Operador_911
{
    public partial class FormPlanilla : Form
    {
        public FormPlanilla()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
        }

        private void FormPlanilla_Load(object sender, EventArgs e)
        {
            CargarPlanilla();
        }
        private void CargarPlanilla()
        {
            try
            {
                dataGridHorarios.Columns.Clear();
                dataGridHorarios.Rows.Clear();

                // Crear columnas de días
                string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
                foreach (string dia in dias)
                {
                    dataGridHorarios.Columns.Add(dia, dia);
                }

                dataGridHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridHorarios.RowHeadersWidth = 100;
                dataGridHorarios.AllowUserToAddRows = false;
                dataGridHorarios.AllowUserToResizeRows = false;

                using (SqlConnection conn = Database.GetConnection())
                {
                    // Buscar la comisaría del usuario
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

                    // Obtener patrullas
                    string queryPatrullas = @"
                        SELECT id_patrulla, codigo_patrulla
                        FROM Patrulla
                        WHERE estado = 'En servicio' AND id_comisaria = @idComisaria AND activo = 1";
                    SqlCommand cmdPatrullas = new SqlCommand(queryPatrullas, conn);
                    cmdPatrullas.Parameters.AddWithValue("@idComisaria", idComisaria);

                    DataTable dtPatrullas = new DataTable();
                    new SqlDataAdapter(cmdPatrullas).Fill(dtPatrullas);

                    // Obtener asignaciones (Tiene)
                    string qTiene = @"
                        SELECT T.id_patrulla, T.nro_placa, T.dia_semana, T.turno,
                               (Pol.apellido + ', ' + Pol.nombre) AS Policia
                        FROM Tiene T
                        INNER JOIN Policia Pol ON T.nro_placa = Pol.nro_placa
                        INNER JOIN Patrulla Pa ON T.id_patrulla = Pa.id_patrulla
                        WHERE Pa.id_comisaria = @idComisaria AND Pa.estado = 'En servicio'";
                    SqlCommand cmdTiene = new SqlCommand(qTiene, conn);
                    cmdTiene.Parameters.AddWithValue("@idComisaria", idComisaria);

                    DataTable dtTiene = new DataTable();
                    new SqlDataAdapter(cmdTiene).Fill(dtTiene);

                    // Construir planilla
                    foreach (DataRow patrulla in dtPatrullas.Rows)
                    {
                        string nombrePatrulla = patrulla["codigo_patrulla"].ToString();
                        int idPatrulla = Convert.ToInt32(patrulla["id_patrulla"]);

                        // Fila título
                        int filaTitulo = dataGridHorarios.Rows.Add();
                        dataGridHorarios.Rows[filaTitulo].DefaultCellStyle.BackColor = Color.LightGray;
                        dataGridHorarios.Rows[filaTitulo].DefaultCellStyle.Font =
                            new Font(dataGridHorarios.Font, FontStyle.Bold);
                        dataGridHorarios.Rows[filaTitulo].HeaderCell.Value = "";
                        dataGridHorarios.Rows[filaTitulo].Cells[0].Value = nombrePatrulla;
                        dataGridHorarios.Rows[filaTitulo].ReadOnly = true;

                        // Turnos
                        int filaManiana = dataGridHorarios.Rows.Add();
                        dataGridHorarios.Rows[filaManiana].HeaderCell.Value = "06-18";

                        int filaNoche = dataGridHorarios.Rows.Add();
                        dataGridHorarios.Rows[filaNoche].HeaderCell.Value = "18-06";

                        var registros = dtTiene.AsEnumerable()
                            .Where(r => r.Field<int>("id_patrulla") == idPatrulla);

                        foreach (var registro in registros)
                        {
                            string dia = registro.Field<string>("dia_semana");
                            string turno = registro.Field<string>("turno");
                            string policia = registro.Field<string>("Policia");

                            int fila = (turno == "06-18") ? filaManiana : filaNoche;

                            if (dataGridHorarios.Columns.Contains(dia))
                            {
                                if (dataGridHorarios[dia, fila].Value != null)
                                    dataGridHorarios[dia, fila].Value += " - " + policia;
                                else
                                    dataGridHorarios[dia, fila].Value = policia;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la planilla: " + ex.Message);
            }
        }

        private void btnExportarPlanilla_Click(object sender, EventArgs e)
        {
            if (dataGridHorarios.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel._Worksheet hoja = null;

            try
            {
                // Obtener nombre comisaría
                string nombreComisaria;
                using (SqlConnection conn = Database.GetConnection())
                {
                    string queryComisaria = "SELECT nombre FROM Comisaria WHERE id_usuario_comisario = @idUsuario";
                    using (SqlCommand cmd = new SqlCommand(queryComisaria, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuario);
                        object result = cmd.ExecuteScalar();
                        nombreComisaria = result?.ToString() ?? "Desconocida";
                    }
                }

                // Iniciar Excel
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                hoja = (Excel._Worksheet)workbook.ActiveSheet;

                int totalCols = dataGridHorarios.Columns.Count;
                int filaExcel = 1;

                // === TÍTULO ===
                string titulo = $"PLANILLA DE HORARIOS - {nombreComisaria.ToUpper()}";
                hoja.Cells[filaExcel, 1] = titulo;
                Excel.Range rangoTitulo = hoja.Range[hoja.Cells[filaExcel, 1], hoja.Cells[filaExcel, totalCols + 1]];
                rangoTitulo.Merge();
                rangoTitulo.Font.Bold = true;
                rangoTitulo.Font.Size = 16;
                rangoTitulo.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rangoTitulo.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(153, 187, 232));
                filaExcel++;

                // === ENCABEZADOS (TURNOS + DÍAS) ===
                hoja.Cells[filaExcel, 1] = "TURNOS";
                for (int c = 0; c < totalCols; c++)
                {
                    hoja.Cells[filaExcel, c + 2] = dataGridHorarios.Columns[c].HeaderText;
                }

                Excel.Range headerRange = hoja.Range[hoja.Cells[filaExcel, 1], hoja.Cells[filaExcel, totalCols + 1]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(189, 215, 238));
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                filaExcel++;

                // === RECORRER GRILLA ===
                for (int r = 0; r < dataGridHorarios.Rows.Count; r++)
                {
                    // Detectar fila de patrulla (fondo gris y texto en la primera celda)
                    var row = dataGridHorarios.Rows[r];
                    if (row.DefaultCellStyle.BackColor == Color.LightGray)
                    {
                        string nombrePatrulla = Convert.ToString(row.Cells[0].Value)?.Trim();
                        if (string.IsNullOrEmpty(nombrePatrulla)) continue;

                        // --- Fila azul: nombre patrulla
                        hoja.Cells[filaExcel, 1] = nombrePatrulla;
                        Excel.Range rangoPatrulla = hoja.Range[hoja.Cells[filaExcel, 1], hoja.Cells[filaExcel, totalCols + 1]];
                        rangoPatrulla.Merge();
                        rangoPatrulla.Font.Bold = true;
                        rangoPatrulla.Font.Color = ColorTranslator.ToOle(Color.White);
                        rangoPatrulla.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(0, 112, 192));
                        rangoPatrulla.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        filaExcel++;

                        // --- Fila turno diurno
                        hoja.Cells[filaExcel, 1] = "6:00 a 18:00";
                        hoja.Cells[filaExcel, 1].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(255, 250, 205));

                        if (r + 1 < dataGridHorarios.Rows.Count)
                        {
                            var filaManiana = dataGridHorarios.Rows[r + 1];
                            for (int c = 0; c < totalCols; c++)
                            {
                                string val = Convert.ToString(filaManiana.Cells[c].Value);
                                hoja.Cells[filaExcel, c + 2] = val;
                                if (!string.IsNullOrWhiteSpace(val))
                                    hoja.Cells[filaExcel, c + 2].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(226, 239, 218));
                                hoja.Cells[filaExcel, c + 2].WrapText = true;
                            }
                        }
                        filaExcel++;

                        // --- Fila turno nocturno
                        hoja.Cells[filaExcel, 1] = "18:00 a 6:00";
                        hoja.Cells[filaExcel, 1].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(255, 250, 205));

                        if (r + 2 < dataGridHorarios.Rows.Count)
                        {
                            var filaNoche = dataGridHorarios.Rows[r + 2];
                            for (int c = 0; c < totalCols; c++)
                            {
                                string val = Convert.ToString(filaNoche.Cells[c].Value);
                                hoja.Cells[filaExcel, c + 2] = val;
                                if (!string.IsNullOrWhiteSpace(val))
                                    hoja.Cells[filaExcel, c + 2].Interior.Color = ColorTranslator.ToOle(Color.FromArgb(226, 239, 218));
                                hoja.Cells[filaExcel, c + 2].WrapText = true;
                            }
                        }
                        filaExcel++;

                        // Saltar las dos filas de turnos
                        r += 2;
                    }
                }

                // === FORMATO FINAL ===
                Excel.Range usedRange = hoja.Range[hoja.Cells[1, 1], hoja.Cells[filaExcel - 1, totalCols + 1]];
                usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                usedRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                usedRange.Columns.AutoFit();



                hoja.Columns[1].ColumnWidth = 20; // Columna TURNOS

                // Desde la columna 2 hasta la última (días)
                for (int c = 2; c <= totalCols + 1; c++)
                {
                    hoja.Columns[c].ColumnWidth = 25;
                }

                // Título (fila 1)
                hoja.Rows[1].RowHeight = 25;

                // Encabezados (fila 2)
                hoja.Rows[2].RowHeight = 20;

                // Resto de filas (3 en adelante)
                for (int r = 3; r <= filaExcel; r++)
                {
                    hoja.Rows[r].RowHeight = 15;
                }

                // === GUARDAR ===
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string baseName = $"Planilla_Horarios_{SanitizeFileName(nombreComisaria)}.xlsx";
                string path = Path.Combine(desktop, baseName);
                int count = 0;
                while (File.Exists(path))
                {
                    count++;
                    string nameOnly = Path.GetFileNameWithoutExtension(baseName);
                    string ext = Path.GetExtension(baseName);
                    path = Path.Combine(desktop, $"{nameOnly} ({count}){ext}");
                }

                workbook.SaveAs(path);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show($"Archivo exportado correctamente en:\n{path}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message);
            }
            finally
            {
                if (hoja != null) Marshal.ReleaseComObject(hoja);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }



        // helper para limpiar caracteres no válidos en el nombre de archivo
        private string SanitizeFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }

    }
}
