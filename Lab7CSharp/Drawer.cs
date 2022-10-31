using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp
{
    class Drawer
    {
        private Graphics _g;
        private Random rnd;
        public Drawer(Graphics g)
        {
            _g = g;
            rnd = new Random();
        }
        public void DrawCircle(int x, int y, int radius)
        {
            Pen p = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            _g.DrawEllipse(p, x, y, radius, radius);
        }
        public void DrawRandomCircle(int x, int y)
        {
            Pen p = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            int radius = rnd.Next(100);
            _g.DrawEllipse(p, x, y, radius, radius);
        }
        public void DrawPoint(int x, int y, int radius)
        {
            SolidBrush myBrush = new SolidBrush(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            _g.FillEllipse(myBrush, new Rectangle(x, y, radius, radius));
        }
        public void DrawRandomPoint(int x, int y)
        {
            SolidBrush myBrush = new SolidBrush(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            int radius = rnd.Next(100);
            _g.FillEllipse(myBrush, new Rectangle(x, y, radius, radius));
        }
        public void DrawSquare(int x, int y, int side)
        {
            Pen p = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            _g.DrawRectangle(p, x, y, side, side);
        }

        public void DrawRandomSquare(int x, int y)
        {
            Pen p = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            int side = rnd.Next(100);
            _g.DrawRectangle(p, x, y, side, side);
        }
    }
}
