using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Create_menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool menu = true;

            foreach (var name in listBox1.Items)
            {
                if (name.ToString() == textBox1.Text)
                {
                    menu = false;
                    break;
                }
            }
            if (menu == true)
            {
                menuStrip1.Items.Add(textBox1.Text);
                listBox1.Items.Add(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Такой пункт меню уже существует", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool menu = true;
            ToolStripMenuItem dop_menu = new ToolStripMenuItem();
            if (listBox1.SelectedIndex != -1)
            {
                foreach (ToolStripMenuItem _item in menuStrip1.Items)
                {
                    if (_item.Text == listBox1.SelectedItem.ToString())
                    {
                        dop_menu = _item;
                        break;
                    }
                }

                foreach (ToolStripMenuItem name in dop_menu.DropDownItems)
                {
                    if (name.ToString() == textBox2.Text)
                    {
                        menu = false;
                        break;
                    }
                    
                }
                if (menu == true)
                {
                    
                    dop_menu.DropDownItems.Add(textBox2.Text);
                }
                else
                {
                    MessageBox.Show("Такой пункт подменю уже существует", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Не выбран пунг головного меню", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
