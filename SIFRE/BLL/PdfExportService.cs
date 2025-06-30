using BE.DTO;
using QuestPDF.Fluent;

namespace BLL
{


    public class PdfExportService
    {
        public byte[] CrearReportePDF(List<TransactionDTO> transactions)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            return QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("ID").SemiBold();
                            header.Cell().Text("Usuario").SemiBold();
                            header.Cell().Text("Producto").SemiBold();
                            header.Cell().Text("Puntos").SemiBold();
                            header.Cell().Text("Fecha").SemiBold();
                        });

                        foreach (var tx in transactions)
                        {
                            table.Cell().Text(tx.Id.ToString());
                            table.Cell().Text(tx.User);
                            table.Cell().Text(tx.Product);
                            table.Cell().Text(tx.Points.ToString());
                            table.Cell().Text(tx.TransactionDate.ToString("dd/MM/yyyy"));
                        }
                    });
                });
            }).GeneratePdf();
        }
    }

}
