using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form2 : Form
    {
        private Pen pen;
        private Font font;
        private SolidBrush solidBrush;
        private Graphics graphics;
        public Form2()
        {
            InitializeComponent();
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            radioButton7.Checked = true;
            radioButton10.Checked = true;
            radioButton13.Checked = true;
            graphics = pictureBox1.CreateGraphics();
        }

        private string GetTextCheckedRadioButton(GroupBox groupBox)
        {
            return groupBox.Controls.OfType<RadioButton>()
                          .FirstOrDefault(n => n.Checked).Text;
        }
        
        private void UpdateStyles()
        {
            string selectedFontColor = GetTextCheckedRadioButton(groupBox1);
            int selectedFontSize = int.Parse(GetTextCheckedRadioButton(groupBox2));
            string selectedFontFamily = GetTextCheckedRadioButton(groupBox3);
            
            string selectedAxisColor = GetTextCheckedRadioButton(groupBox6);
            int selectedAxisThickness = int.Parse(GetTextCheckedRadioButton(groupBox7));

            Color fontColor = (Color)typeof(Color).GetProperty(selectedFontColor).GetValue(null, null);
            Color axisColor = (Color)typeof(Color).GetProperty(selectedAxisColor).GetValue(null, null);

            pen = new Pen(axisColor, selectedAxisThickness);
            font = new Font(selectedFontFamily, selectedFontSize);
            solidBrush = new SolidBrush(fontColor);

        }

        private void DrawAxis(Graphics graphics)
        {
            graphics.DrawLine(pen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            graphics.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
            graphics.DrawString("0", font, solidBrush, pictureBox1.Width / 2, pictureBox1.Height / 2);
            graphics.DrawString("X", font, solidBrush, pictureBox1.Width - 20, pictureBox1.Height / 2);
            graphics.DrawString("Y", font, solidBrush, pictureBox1.Width / 2, 10);
        }
        
        private static double Funtion(double x) => (1 - x * x) * (x - 2);
        

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateStyles();
            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
            DrawAxis(graphics);
            ResetVariables();
            timer1.Start();
        }
        static double x = -2;
        static double y = Funtion(x);
        double x1 = x;
        double y1 = y;

        private void ResetVariables()
        {
            x = -2;
            y = Funtion(x);
            x1 = x;
            y1 = y;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 0.1;
            y = Funtion(x);
            DrawFunction();
            x1 = x;
            y1 = y;
            if (x >= 2)
            {
                timer1.Stop();
            }
        }
        private void DrawFunction()
        { 
            graphics.DrawLine(pen, (float)(x1 * 50 + pictureBox1.Width / 2), (float)(pictureBox1.Height / 2 - y1 * 50), (float)(x * 50 + pictureBox1.Width / 2), (float)(pictureBox1.Height / 2 - y * 50));
        }
    }
}
