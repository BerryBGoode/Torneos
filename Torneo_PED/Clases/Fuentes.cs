using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED
{
    public class Fuentes : IDisposable
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private readonly List<IntPtr> _fontMemoryHandles = new List<IntPtr>();
        private readonly PrivateFontCollection _fontCollection = new PrivateFontCollection();
        private bool _disposed = false;
        private readonly object _lock = new object();

        public FontFamily CargarFuente(byte[] fontData)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(Fuentes));

            if (fontData == null || fontData.Length == 0)
                throw new ArgumentNullException(nameof(fontData));

            lock (_lock)
            {
                try
                {
                    IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                    Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                    uint dummy = 0;
                    IntPtr fontResource = AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);

                    if (fontResource == IntPtr.Zero)
                    {
                        Marshal.FreeCoTaskMem(fontPtr);
                        throw new Exception("Failed to add font resource");
                    }

                    _fontCollection.AddMemoryFont(fontPtr, fontData.Length);
                    _fontMemoryHandles.Add(fontPtr);

                    // Verificar que la fuente se cargó correctamente
                    if (_fontCollection.Families.Length == 0)
                        throw new Exception("No font families loaded");

                    var lastFamily = _fontCollection.Families[_fontCollection.Families.Length - 1];

                    if (!lastFamily.IsStyleAvailable(FontStyle.Regular))
                        throw new Exception("Font does not support regular style");

                    return lastFamily;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading font: {ex.Message}");
                    throw new FontLoadException("Failed to load font", ex);
                }
            }
        }

        public Font CrearFont(FontFamily family, float emSize, FontStyle style = FontStyle.Regular)
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(Fuentes));

            if (family == null)
                throw new ArgumentNullException(nameof(family));

            try
            {
                if (!family.IsStyleAvailable(style))
                    style = FontStyle.Regular;

                return new Font(family, emSize, style, GraphicsUnit.Pixel);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error creating font: {ex.Message}");
                return SystemFonts.DefaultFont;
            }
        }

        public void Dispose()
        {
            lock (_lock)
            {
                if (_disposed) return;

                foreach (var handle in _fontMemoryHandles)
                {
                    try
                    {
                        Marshal.FreeCoTaskMem(handle);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error freeing font memory: {ex.Message}");
                    }
                }

                _fontMemoryHandles.Clear();

                try
                {
                    _fontCollection.Dispose();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error disposing font collection: {ex.Message}");
                }

                _disposed = true;
            }
        }

        ~Fuentes()
        {
            Dispose();
        }
    }

    public class FontLoadException : Exception
    {
        public FontLoadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
