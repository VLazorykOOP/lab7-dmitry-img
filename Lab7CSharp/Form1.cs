using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        private Drawer drawer;
        private Action<int, int, int> drawFigure;
        private Action<int, int> drawRandomFigure;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            drawer = new Drawer(pictureBox1.CreateGraphics());
        }
        
        private void UpdateFiguresToDraw()
        {
            if (checkBox1.Checked)
            {
                drawRandomFigure = (Action<int, int>)drawer.GetType().GetMethod("DrawRandom" + comboBox1.SelectedItem).CreateDelegate(typeof(Action<int, int>), drawer);
            }
            else
            {
                drawFigure = (Action<int, int, int>)drawer.GetType().GetMethod("Draw" + comboBox1.SelectedItem).CreateDelegate(typeof(Action<int, int, int>), drawer);
            }
        }
        
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFiguresToDraw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = !checkBox1.Checked;
            if(comboBox1.SelectedIndex != -1)
            {
                UpdateFiguresToDraw();
            }
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (checkBox1.Checked)
                {
                    drawRandomFigure(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                }
                else
                {
                    drawFigure(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y, int.Parse(textBox1.Text));
                }
            }
        
        }
    }
    
}
