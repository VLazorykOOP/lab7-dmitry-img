using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp.Figures
{
    internal class Square : FigureBase
    {
        private int width;
        public Square(int x, int y, int width, Pen pen) : base(x, y, pen)
        {
            this.width = width;
        }
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(pen, x, y, width, width);
        }
    }
}
