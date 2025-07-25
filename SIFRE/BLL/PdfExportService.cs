using BE.DTO;
using BE.Entities;
using QuestPDF.Fluent;

namespace BLL
{
    public static class PdfExportService
    {
        public static byte[] CrearReportePDF(List<TransactionDTO> transactions)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            return QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Content().Column(column =>
                    {
                        column.Item().Text("Reporte de Transacciones").FontSize(20).SemiBold();
                        column.Item().PaddingVertical(10);
                        
                        column.Item().Table(table =>
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
                });
            }).GeneratePdf();
        }

        public static byte[] CrearReportePDF(List<LogDTO> logs)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            return QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Content().Column(column =>
                    {
                        column.Item().Text("Bitácora de Eventos").FontSize(20).SemiBold();
                        column.Item().PaddingVertical(10);
                        
                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(3);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("ID").SemiBold();
                                header.Cell().Text("Fecha").SemiBold();
                                header.Cell().Text("Usuario").SemiBold();
                                header.Cell().Text("Módulo").SemiBold();
                                header.Cell().Text("Tipo").SemiBold();
                                header.Cell().Text("Mensaje").SemiBold();
                            });

                            foreach (var log in logs)
                            {
                                table.Cell().Text(log.Id.ToString());
                                table.Cell().Text(log.CreatedAt.ToString("dd/MM/yyyy HH:mm"));
                                table.Cell().Text(log.CreatedBy ?? "");
                                table.Cell().Text(log.Module ?? "");
                                table.Cell().Text(log.Type.ToString());
                                table.Cell().Text(log.Message ?? "");
                            }
                        });
                    });
                });
            }).GeneratePdf();
        }

        public static byte[] CrearReportePDF(List<ProductLog> productLogs)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            return QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Content().Column(column =>
                    {
                        column.Item().Text("Bitácora de Productos").FontSize(20).SemiBold();
                        column.Item().PaddingVertical(10);
                        
                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("ID").SemiBold();
                                header.Cell().Text("Producto").SemiBold();
                                header.Cell().Text("Descripción").SemiBold();
                                header.Cell().Text("Puntos").SemiBold();
                                header.Cell().Text("Categoría").SemiBold();
                                header.Cell().Text("Fecha").SemiBold();
                                header.Cell().Text("Estado").SemiBold();
                            });

                            foreach (var log in productLogs)
                            {
                                table.Cell().Text(log.Id.ToString());
                                table.Cell().Text(log.ProductName ?? "");
                                table.Cell().Text(log.Description ?? "");
                                table.Cell().Text(log.Points.ToString());
                                table.Cell().Text(log.Category ?? "");
                                table.Cell().Text(log.StartDate.ToString("dd/MM/yyyy"));
                                table.Cell().Text(log.IsBlocked ? "Bloqueado" : "Activo");
                            }
                        });
                    });
                });
            }).GeneratePdf();
        }

        // Método genérico para otros tipos que puedan agregarse en el futuro
        public static byte[] CrearReportePDF(List<object> items)
        {
            // Detectar el tipo y delegar al método específico
            if (items.Any())
            {
                var firstItem = items.First();
                return firstItem switch
                {
                    TransactionDTO => CrearReportePDF(items.Cast<TransactionDTO>().ToList()),
                    LogDTO => CrearReportePDF(items.Cast<LogDTO>().ToList()),
                    ProductLog => CrearReportePDF(items.Cast<ProductLog>().ToList()),
                    _ => throw new NotSupportedException($"Tipo {firstItem.GetType().Name} no soportado para exportación PDF")
                };
            }

            throw new ArgumentException("Lista vacía para exportación PDF");
        }
    }
}
