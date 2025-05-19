using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;

namespace UI.Reports
{
    public static class Serializer
    {
        public static void ExportDataGridViewToJson(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0 || (dataGridView.Rows.Count == 1 && dataGridView.Rows[0].IsNewRow))
            {
                MessageBox.Show("No hay datos para exportar.", "Exportación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var logsList = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                var logData = new Dictionary<string, object>();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    logData[cell.OwningColumn.Name] = cell.Value ?? string.Empty;
                }

                logsList.Add(logData);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(logsList, options);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json";
                saveFileDialog.Title = "Guardar Reporte en JSON";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, jsonString);
                    MessageBox.Show("Datos exportados a JSON exitosamente.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
