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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Component component = new Component();
            Form2 form2 = new Form2();
            component = form2.New_component(sender, e, component);
            listBox1.Items.Add(component.name);
        }
    }
}
