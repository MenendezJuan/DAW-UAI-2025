using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Reports
{
    public static class PdfExporter
    {
        public static void ExportDataGridViewToPdf(DataGridView dataGridView, string titleText, string subtitleText, bool isVerticalPage = true)
        {
            // Validar si el DataGridView está vacío
            if (dataGridView.Rows.Count == 0 || (dataGridView.Rows.Count == 1 && dataGridView.Rows[0].IsNewRow))
            {
                MessageBox.Show("No hay datos para exportar.", "Exportación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear el PDF en memoria
            using (MemoryStream ms = new MemoryStream())
            using (PdfWriter writer = new PdfWriter(ms))
            using (PdfDocument pdfDoc = new PdfDocument(writer))
            {
                // Crear un documento de iText
                var document = new Document(pdfDoc);

                if(!isVerticalPage)
                {
                    // Rotar la página a horizontal
                    pdfDoc.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
                }
                
                // Encabezado
                var title = new Paragraph(titleText)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20)
                    .SetBold()
                    .SetFontColor(ColorConstants.DARK_GRAY);
                document.Add(title);

                var subtitle = new Paragraph(subtitleText)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(12)
                    .SetFontColor(ColorConstants.GRAY);
                document.Add(subtitle);

                // Espacio después del encabezado
                document.Add(new Paragraph("\n"));

                // Crear la tabla y agregar encabezados
                int columnCount = dataGridView.ColumnCount;
                var table = new Table(columnCount).UseAllAvailableWidth();

                // Agregar encabezados de columna con estilo
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    var headerCell = new Cell()
                        .Add(new Paragraph(column.HeaderText))
                        .SetBackgroundColor(ColorConstants.BLACK)
                        .SetFontColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5)
                        .SetBorder(Border.NO_BORDER);
                    table.AddHeaderCell(headerCell);
                }

                // Agregar filas de datos con filas alternadas en color
                bool alternateRow = false;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.IsNewRow) continue;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        var pdfCell = new Cell()
                            .Add(new Paragraph(cell.Value?.ToString() ?? string.Empty))
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetPadding(5)
                            .SetBorder(new SolidBorder(ColorConstants.LIGHT_GRAY, 0.5f));

                        // Alternar color de fondo para filas
                        if (alternateRow)
                        {
                            pdfCell.SetBackgroundColor(new DeviceRgb(240, 240, 240));  // Color gris claro
                        }
                        table.AddCell(pdfCell);
                    }
                    alternateRow = !alternateRow;  // Cambia el color en cada fila
                }

                // Agregar la tabla al documento
                document.Add(table);

                // Pie de página
                var footer = new Paragraph($"Generado por SIFRE - Sistema de Reportes\nFecha de generación: {DateTime.Now}")
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontSize(8)
                    .SetFontColor(ColorConstants.GRAY);
                document.Add(footer);

                // Cerrar el documento
                document.Close();

                // Mostrar el cuadro de diálogo para guardar el archivo
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Guardar Reporte PDF";

                    // Si el usuario selecciona una ubicación, guarda el archivo desde la memoria
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, ms.ToArray());
                        MessageBox.Show("PDF guardado exitosamente.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
