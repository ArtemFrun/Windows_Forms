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
        Component _comp;
        public Form2()
        {
            InitializeComponent();
            
        }

        public void New_component(Component pc)
        {
            _comp = pc;
        }

        public void Chande_component(Component pc)
        {
            _comp = pc;
            textBox1.Text = _comp.name;
            textBox2.Text = _comp.properties;
            textBox3.Text = _comp.description;
            textBox4.Text = _comp.price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Заполнены не все поля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    _comp.name = textBox1.Text;
                    _comp.properties = textBox2.Text;
                    _comp.description = textBox3.Text;
                    _comp.price = double.Parse(textBox4.Text);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch(FormatException)
                {
                    MessageBox.Show("Цена указане не цыфрой", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
