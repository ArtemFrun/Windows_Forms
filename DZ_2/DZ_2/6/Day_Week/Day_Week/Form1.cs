using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day_Week
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Day();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Day();
            }
            else
            {
                MessageBox.Show("Нужно нажаль левой кнопкой мышки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Day()
        {
            if ((textBox1.Text.Length > 2 || textBox1.Text.Length ==0) || (textBox2.Text.Length > 2 || textBox2.Text.Length == 0) || (textBox3.Text.Length > 4 || textBox3.Text.Length == 0))
            {
                MessageBox.Show("Не верно указана дата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int day = int.Parse(textBox1.Text);
                    int mon = int.Parse(textBox2.Text);
                    int year = int.Parse(textBox3.Text);

                    DateTime date = new DateTime(year, mon, day);
                    textBox4.Text = System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(date.DayOfWeek);
                }
                catch(FormatException)
                {
                    MessageBox.Show("Введено не число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
