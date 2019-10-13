using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Move_Window
{
    public partial class Form1 : Form
    {
        int posX = 0;
        int posY = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (posX >= 1920)
            {
                posX = 0;
                posY += 100;
            }
            if (posY >= 1080)
            {
                posX = 0;
                posY = 0;
            }
            Location = new Point(posX, posY);
            posX += 100;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer1.Enabled = true;
                timer1.Interval = 100;
            }
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Enabled = false;
                //timer1.Interval = 0;
            }
        }
    }
}
