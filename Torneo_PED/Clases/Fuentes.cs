using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED
{
    public class Fuentes
    {
        [DllImport("gdi32.dll")]

        //Función de la DLL externa
        private static extern IntPtr AddFontMemResourceEx(IntPtr pFileView, uint cjSize, IntPtr pvResrved,[In] ref uint pNumFonts);

        public FontFamily CargarFuente(byte[] fuente)
        {
            FontFamily fuentenueva;

            //asignar memoria y copiar bytes
            IntPtr data = Marshal.AllocCoTaskMem(fuente.Length);
            Marshal.Copy(fuente, 0, data, fuente.Length);

            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fuente.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection fontcollection = new PrivateFontCollection();
            //Pasar fuente a PrivateFontCollection
            fontcollection.AddMemoryFont(data, fuente.Length);

            //Liberar memoria
            Marshal.FreeCoTaskMem(data);

            fuentenueva = fontcollection.Families[0];

            return fuentenueva;
        }
    }
}
