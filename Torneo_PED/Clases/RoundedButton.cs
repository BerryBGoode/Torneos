using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torneo_PED
{
   public class RoundedButton : Button
   {
        private int borderSize = 0;
        private int borderRadius = 10;
        private Color borderColor = Color.Transparent;

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        public Color TextColor
        {
            get { return ForeColor; }
            set
            {
                ForeColor = value;
                this.Invalidate();
            }
        }

        public Color DisabledTextColor { get; set; }

        public RoundedButton()
        {
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.FromArgb(50, 48, 48);
            FlatAppearance.BorderSize = 0;
            Margin = new Padding(0);
            Size = new Size(77, 60);
            TextColor = Color.White;
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }

        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2f;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // Validaciones básicas de seguridad
            if (pevent?.Graphics == null) return;

            // Ajustar borderRadius si es necesario
            if (borderRadius > this.Width || borderRadius > this.Height)
                borderRadius = Math.Min(this.Width, this.Height) / 2;

            if (borderRadius < 0) borderRadius = 0;

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;

            // Solo proceder si las dimensiones son válidas
            if (rectSurface.Width > 0 && rectSurface.Height > 0)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius))
                using (Pen penSurface = new Pen(this.Parent?.BackColor ?? Color.Black, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }

            // Llamar al base DESPUÉS de nuestras operaciones personalizadas
            base.OnPaint(pevent);

            // Manejar texto deshabilitado
            if (!Enabled && DisabledTextColor != Color.Empty)
            {
                using (SolidBrush brush = new SolidBrush(DisabledTextColor))
                {
                    StringFormat format = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    pevent.Graphics.DrawString(Text, Font, brush, ClientRectangle, format);
                }
            }
        }

    }
}
