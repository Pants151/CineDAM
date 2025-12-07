using iText.IO.Font;           // Para PdfEncodings
using iText.IO.Font.Constants; // Para StandardFonts
using iText.Kernel.Font;       // Para PdfFontFactory
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace CineDAM.Servicios
{
    public class GeneradorTicket
    {
        public static void CrearTicket(string pelicula, string sala, string fechaHora, string butaca, decimal precio, int idVenta)
        {
            try
            {
                // 1. Definir ruta
                string carpeta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tickets");
                if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);
                string archivo = System.IO.Path.Combine(carpeta, $"Ticket_{idVenta}.pdf");

                // 2. Configurar PDF
                PdfWriter writer = new PdfWriter(archivo);
                PdfDocument pdf = new PdfDocument(writer);
                Document documento = new Document(pdf, new PageSize(226, 400));
                documento.SetMargins(10, 10, 10, 10);

                // --- GESTIÓN DE FUENTES SEGURA ---
                PdfFont fontNormal = null;
                PdfFont fontBold = null;

                try
                {
                    // Intentamos cargar Helvetica explícitamente sin incrustar (más ligero y compatible)
                    fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, PdfEncodings.WINANSI);
                    fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD, PdfEncodings.WINANSI);
                }
                catch
                {
                    // Si falla por conflicto de librerías, dejamos las fuentes en null
                    // iText usará la fuente por defecto automáticamente.
                }

                // Función local para aplicar estilo sin romper el programa
                void Estilar(Paragraph p, PdfFont f, float size)
                {
                    p.SetFontSize(size);
                    if (f != null) p.SetFont(f);
                }
                // ----------------------------------

                // 3. CONTENIDO

                // Título
                Paragraph pHeader = new Paragraph("CINE DAM").SetTextAlignment(TextAlignment.CENTER);
                Estilar(pHeader, fontBold, 18);
                documento.Add(pHeader);

                documento.Add(new Paragraph("----------------------------------").SetTextAlignment(TextAlignment.CENTER));

                // Película
                Paragraph pPeli = new Paragraph($"PELÍCULA:\n{pelicula}").SetTextAlignment(TextAlignment.CENTER);
                Estilar(pPeli, fontBold, 12);
                documento.Add(pPeli);

                // Sala y Sesión
                Paragraph pSala = new Paragraph($"\nSALA: {sala}");
                Estilar(pSala, fontNormal, 10);
                documento.Add(pSala);

                Paragraph pSesion = new Paragraph($"SESIÓN: {fechaHora}");
                Estilar(pSesion, fontNormal, 10);
                documento.Add(pSesion);

                // Butaca
                Paragraph pButaca = new Paragraph($"BUTACA: {butaca}").SetTextAlignment(TextAlignment.CENTER);
                Estilar(pButaca, fontBold, 14);
                documento.Add(pButaca);

                documento.Add(new Paragraph("----------------------------------").SetTextAlignment(TextAlignment.CENTER));

                // Precio
                Paragraph pPrecio = new Paragraph($"PRECIO: {precio:C2}").SetTextAlignment(TextAlignment.RIGHT);
                Estilar(pPrecio, fontBold, 12);
                documento.Add(pPrecio);

                // Referencia
                Paragraph pRef = new Paragraph($"Ref: {idVenta}").SetTextAlignment(TextAlignment.LEFT);
                Estilar(pRef, fontNormal, 8);
                documento.Add(pRef);

                // 4. CERRAR DOCUMENTO
                documento.Close();

                // 5. ABRIR EL TICKET
                try
                {
                    var p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo(archivo) { UseShellExecute = true };
                    p.Start();
                }
                catch { /* Ignorar si no se puede abrir el visor */ }

            }
            catch (Exception ex)
            {
                // Si falla la creación del archivo (ej. está abierto por Acrobat), lanzamos el error para verlo en el MessageBox
                throw new Exception("Error generando PDF: " + ex.Message);
            }
        }
    }
}