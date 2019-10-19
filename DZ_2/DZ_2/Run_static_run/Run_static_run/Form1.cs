using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Run_static_run
{
    public partial class Form1 : Form
    {
        Label label = new Label();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label.Size = new Size(50, 50);
            label.BorderStyle = BorderStyle.Fixed3D;
            label.ForeColor = Color.Green;
            label.BackColor = Color.Yellow;
            label.Text = "STATIC";
            label.AutoSize = false;
            Controls.Add(label);
            label.Left = ClientSize.Width / 2;
            label.Top = ClientSize.Height / 2;
        }

        private void Move_Static (object sender, MouseEventArgs e)
        {
            if((e.X > label.Location.X - 20 && e.X < label.Location.X + label.Width +20) && (e.Y > label.Location.Y - 20 && e.Y < label.Location.Y + label.Height + 20 ))
            {
                if (e.X > label.Location.X - 20 && e.X < label.Location.X)
                {
                    label.Left += 10;
                }
                else if (e.X < label.Location.X + label.Width + 20 && e.X > label.Location.X + label.Width)
                {
                    label.Left -= 10;
                }
                else if (e.Y > label.Location.Y - 20 && e.Y < label.Location.Y)
                {
                    label.Top += 10;
                }
                else if (e.Y < label.Location.Y + label.Height + 20 && e.Y > label.Location.Y + label.Height)
                {
                    label.Top -= 10;
                }
            }
        }
    }
}
