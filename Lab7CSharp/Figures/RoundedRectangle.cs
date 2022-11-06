using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp.Figures
{
    public class RoundedRectangle : FigureBase
    {

        private int width;
        private int height;
        private int radius;
        public RoundedRectangle(int x, int y, int width, int height, int radius, Pen pen) : base(x, y, pen)
        {
            this.width = width;
            this.height = height;
            this.radius = radius;
        }

        public override void Draw(Graphics g)
        {
            int diameter = radius * 2;

            g.DrawLine(pen, x + radius, y, x + width - radius + 1, y);
            g.DrawArc(pen, x + width - diameter, y, diameter, diameter, 270, 90);

            g.DrawLine(pen, x + width, y + radius - 1, x + width, y + height - radius + 1);
            g.DrawArc(pen, x + width - diameter, y + height - diameter, diameter, diameter, 0, 90);

            g.DrawLine(pen, x + width - radius + 1, y + height, x + radius - 1, y + height);
            g.DrawArc(pen, x, y + height - diameter, diameter, diameter, 90, 90);

            g.DrawLine(pen, x, y + height - radius + 1, x, y + radius - 1);
            g.DrawArc(pen, x, y, diameter, diameter, 180, 90);
        }

    }
}