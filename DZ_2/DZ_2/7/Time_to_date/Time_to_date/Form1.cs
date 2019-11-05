using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_to_date
{
    public partial class Form1 : Form
    {
        DateTime date;
        DateTime left;
        int day = 0;
        int mon = 0;
        int year = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Time();
                groupBox1_Enter(sender, e);
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Time();
                groupBox1_Enter(sender, e);
            }
            else
            {
                MessageBox.Show("Нужно нажаль левой кнопкой мышки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Time()
        {
            if ((textBox1.Text.Length > 2 || textBox1.Text.Length == 0) || (textBox2.Text.Length > 2 || textBox2.Text.Length == 0) || (textBox3.Text.Length > 4 || textBox3.Text.Length == 0))
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

                    date = new DateTime(year, mon, day);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Не верно указана дата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            try
            {
                
                if (radioButton1.Checked == true)
                {
                    left = new DateTime(date.Subtract(now).Ticks);
                    day = left.Day;
                    mon = left.Month - 1;
                    year = left.Year - 1;
                   
                    textBox4.Text = year.ToString() + " год " + mon.ToString() + " мес. " + day.ToString() + " дней";
                    textBox5.Text = "";
                }
                if (radioButton2.Checked == true)
                {
                    left = new DateTime(date.Subtract(now).Ticks);
                    day = left.Day;
                    mon = left.Month - 1;
                    year = left.Year - 1;
                    
                    textBox5.Text = year.ToString() + " год " + mon.ToString() + " мес. " + day.ToString() + " дней " + left.Hour.ToString() + ":" + left.Minute.ToString() + ":" + left.Second.ToString();
                    textBox4.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Введенная дата меньше сегодняшней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
