using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coordinate_window
{
    public partial class Form1 : Form
    {
        bool ctr = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ctr == true)
                    Close();
                if ((e.X < ClientSize.Width - 10 && e.Y < ClientSize.Height - 10) && (e.X > 10 && e.Y > 10))
                    MessageBox.Show("Inside");
                else
                if ((e.X > ClientSize.Width - 10 || e.Y > ClientSize.Height - 10) || (e.X < 10 || e.Y < 10))
                    MessageBox.Show("Outside");
                else
                if (e.X == ClientSize.Width - 10 || e.Y == ClientSize.Height - 10 || e.X == 10 || e.Y == 10)
                    MessageBox.Show("Border");
            }
            if (e.Button == MouseButtons.Right)
            {
                Text = "Width = " + ClientSize.Width + " Height = " + ClientSize.Height;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                ctr = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "X = " + e.X + " Y = " + e.Y;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                ctr = false;
        }
    }
}
