using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp.Figures
{
    public abstract class FigureBase
    {
        protected int x;
        protected int y;
        public Pen pen;

        protected FigureBase(int x, int y, Pen pen)
        {
            this.x = x;
            this.y = y;
            this.pen = pen;
        }
        public abstract void Draw(Graphics graphics);
        public virtual void Move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }
    }
}