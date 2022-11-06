using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp.Figures
{
    public class Ellipse : FigureBase
    {
        private int width;
        private int height;
        public Ellipse(int x, int y, int width, int height, Pen pen) : base(x, y, pen)
        {
            this.width = width;
            this.height = height;
        }
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(pen, x, y, width, height);
        }
    }
}