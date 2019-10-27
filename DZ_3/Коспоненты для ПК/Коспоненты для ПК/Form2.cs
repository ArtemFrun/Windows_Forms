using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Коспоненты_для_ПК
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        public Component New_component(object sender, EventArgs e, Component pc)
        {
            Show();
            return button1_Click(sender, e);
        }
        private Component button1_Click(object sender, EventArgs e)
        {
            Component newcomp = new Component();
            newcomp.name = textBox1.Text;
            newcomp.properties = textBox2.Text;
            newcomp.description = textBox3.Text;
            newcomp.price = textBox4.Text;
            Close();
            return newcomp;
        }
    }
}
