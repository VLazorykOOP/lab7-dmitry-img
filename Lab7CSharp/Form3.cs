using Lab7CSharp.Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form3 : Form
    {
        private List<FigureBase> figures;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            figures = new List<FigureBase>();
        }

        private void SetTextboxesAsZero()
        {
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetTextboxesAsZero();
            groupBox2.Text = "Rounded Rect Settings";
            label2.Text = "Width";
            label3.Text = "Height";
            label4.Text = "Radius";
            
            label3.Visible = true;
            textBox3.Visible = true;
            label4.Visible = true;
            textBox4.Visible = true;
            label5.Visible = false;
            textBox5.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetTextboxesAsZero();
            groupBox2.Text = "Ellipse Settings";
            label2.Text = "Width";
            label3.Text = "Height";
            
            label3.Visible = true;
            textBox3.Visible = true;
            label4.Visible = false;
            textBox4.Visible = false;
            label5.Visible = false;
            textBox5.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SetTextboxesAsZero();
            groupBox2.Text = "Arc Settings";
            label2.Text = "Width";
            label3.Text = "Height";
            label4.Text = "Start Angle";
            label5.Text = "Sweep Angle";

            
            label3.Visible = true;
            textBox3.Visible = true;
            label4.Visible = true;
            textBox4.Visible = true;
            label5.Visible = true;
            textBox5.Visible = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SetTextboxesAsZero();
            groupBox2.Text = "Square Settings";
            label2.Text = "Width";
            
            label3.Visible = false;
            textBox3.Visible = false;
            label4.Visible = false;
            textBox4.Visible = false;
            label5.Visible = false;
            textBox5.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            var selectedRb = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Name;
            FigureBase figureToAdd = default;
            int pbWidth = pictureBox1.Width;
            int pbHeigth = pictureBox1.Height;
            int tb2 = int.Parse(textBox2.Text);
            int tb3 = int.Parse(textBox3.Text);
            int tb4 = int.Parse(textBox4.Text);
            int tb5 = int.Parse(textBox5.Text);
            Pen pen = new Pen(colorDialog1.Color);
            switch (selectedRb)
            {
                case "radioButton1":
                    figureToAdd = new RoundedRectangle(
                        random.Next(pbWidth - tb2), 
                        random.Next(pbHeigth - tb3), 
                        tb2, 
                        tb3, 
                        tb4, 
                        pen
                        );
                    break;
                case "radioButton2":
                    figureToAdd = new Ellipse(
                        random.Next(pbWidth - tb2),
                        random.Next(pbHeigth - tb3),
                        tb2,
                        tb3,
                        pen
                        );
                    break;
                case "radioButton3":
                    figureToAdd = new Arc(
                        random.Next(pbWidth - tb2),
                        random.Next(pbHeigth - tb3),
                        tb2,
                        tb3,
                        tb4,
                        tb5,
                        pen
                        );
                    break;
                case "radioButton4":
                    figureToAdd = new Square(
                        random.Next(pbWidth - tb2),
                        random.Next(pbWidth - tb2),
                        tb2,
                        pen
                        );
                    break;
                default:
                    break;
            }
            figures.Add(figureToAdd);
            textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
        }
        private void DrawImage()
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
            foreach (var figure in figures)
            {
                figure.Draw(graphics);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawImage();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            int step = int.Parse(textBox7.Text);
            int elementId = int.Parse(textBox6.Text);
            figures[elementId].Move(0, -step);
            DrawImage();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            int step = int.Parse(textBox7.Text);
            int elementId = int.Parse(textBox6.Text);
            figures[elementId].Move(0, step);
            DrawImage();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int step = int.Parse(textBox7.Text);
            int elementId = int.Parse(textBox6.Text);
            figures[elementId].Move(step, 0);
            DrawImage();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int step = int.Parse(textBox7.Text);
            int elementId = int.Parse(textBox6.Text);
            figures[elementId].Move(-step, 0);
            DrawImage();
        }
    }
}
