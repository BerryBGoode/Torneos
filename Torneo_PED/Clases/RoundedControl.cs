using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torneo_PED
{
    public class RoundedControl : Component
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeft, int nTop, int nRight, int nBottom, int width, int height);

        [DllImport("Gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        private Control control;
        private int cornerRadius = 25;
        private EventHandler handler;

        public Control TargetControl
        {
            get => control;
            set
            {
                if (control != null && handler != null)
                    control.SizeChanged -= handler;

                control = value;

                handler = (s, e) => ApplyRoundedRegion();
                control.SizeChanged += handler;

                ApplyRoundedRegion();
            }
        }

        public int CornerRadius
        {
            get => cornerRadius;
            set
            {
                cornerRadius = value;
                ApplyRoundedRegion();
            }
        }

        private void ApplyRoundedRegion()
        {
            if (control == null || control.IsDisposed || control.Width <= 0 || control.Height <= 0)
                return;

            IntPtr ptr = CreateRoundRectRgn(0, 0, control.Width, control.Height, cornerRadius, cornerRadius);
            control.Region = Region.FromHrgn(ptr);
            DeleteObject(ptr); // evita fuga de memoria
        }
    }
}
