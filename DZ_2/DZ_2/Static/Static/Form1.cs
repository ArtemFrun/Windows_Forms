using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Static
{
    public partial class Form1 : Form
    {
        int X = 0;
        int Y = 0;
        int name_static = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                X = e.X;
                Y = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Label label = new Label();
            label.BorderStyle = BorderStyle.Fixed3D;
            label.ForeColor = Color.Green;
            label.BackColor = Color.Yellow;
            if (e.Button == MouseButtons.Left)
            {

                if (e.X > X && e.Y > Y)
                {
                    label.Location = new Point(X, Y);
                }
                else if (e.X > X && e.Y < Y)
                {
                    label.Location = new Point(X, e.Y);
                }
                else if (e.X < X && e.Y < Y)
                {
                    label.Location = new Point(e.X, e.Y);
                }
                else
                {
                    label.Location = new Point(e.X, Y);
                }
                if (Math.Abs(e.X - X) <= 10 || Math.Abs(e.Y - Y) <= 10)
                {
                    MessageBox.Show("Минимальный размер 10х10", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    label.Size = new Size(Math.Abs(e.X - X), Math.Abs(e.Y - Y));
                    label.Text = name_static.ToString();
                    Controls.Add(label);
                    label.MouseClick += Information_static;
                    label.MouseDoubleClick += Delete_static;
                    name_static++;
                }
            }
            else
            {
                MessageBox.Show("Не та кнопка мышки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Information_static(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                foreach(Label l in Controls)
                {
                    Point local = l.PointToScreen(Point.Empty);
                    if(MousePosition.X > local.X && MousePosition.X < local.X+l.Width && MousePosition.Y > local.Y && MousePosition.Y < local.Y+l.Height)
                    {
                        Text = "static №" + l.Text + " площа = " + l.Width * l.Height + " Координаты Х = " + l.Location.X + " Y = " + l.Location.Y;
                    }
                }
            }
        }

        private void Delete_static (object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Label l in Controls)
                {
                    Point location = l.PointToScreen(Point.Empty);
                    if (MousePosition.X > location.X && MousePosition.X < location.X + l.Width && MousePosition.Y > location.Y && MousePosition.Y < location.Y + l.Height)
                    {
                        if (name_static > Convert.ToInt32(l.Text))
                        {
                            name_static = Convert.ToInt32(l.Text);
                        }
                    }
                }
                foreach (Label l in Controls)
                {
                    if (name_static == Convert.ToInt32(l.Text))
                    {
                        Text = $"«Статик» с номер №{l.Text} удалён!";
                        Controls.Remove(l);
                        l.MouseClick -= Information_static;
                        l.MouseDoubleClick -= Delete_static;
                    }
                }
            }
        }
    }
}
