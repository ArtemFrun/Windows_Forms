using System;
using System.Windows.Forms;
using System.IO;

namespace User_Information
{
    public partial class Form1 : Form
    {
        string name;
        string surname;
        string patronymic;
        string sex;
        DateTime birthday;
        string Family_status;
        string dop_info;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("муж.");
            comboBox1.Items.Add("жен.");
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Information();
            }
            else
            {
                MessageBox.Show("Нужно нажать левой кнопкой мышки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Information();
            }
        }

        private void Information()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" &&
                textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" &&
                comboBox1.Text != "")
            {
                try
                {
                    int day = int.Parse(textBox4.Text);
                    int mon = int.Parse(textBox5.Text);
                    int year = int.Parse(textBox6.Text);
                    birthday = new DateTime(year, mon, day);
                    if (birthday > DateTime.Now)
                        MessageBox.Show("Не верно указано дату рождения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        using (StreamWriter sw = new StreamWriter("User_Information.txt", true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine($"ФИО: {textBox1.Text} {textBox2.Text} {textBox3.Text}, Пол: {comboBox1.Text}, Дата рождени: {birthday.ToString("D")}, " +
                                $"Семейный статус: {textBox7.Text}, Доп. информация: {textBox8.Text}");
                        }
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Не верно указано дату рождения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
