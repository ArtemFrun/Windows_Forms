using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Список_пользователей
{
    public partial class Form1 : Form
    {
        int index = 0;
        
        public Form1()
        {
            InitializeComponent();
            button8.Visible = false;
            button9.Visible = false;
        }

        private void Button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List_Add();
            }
        }

        private void Button1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                List_Add();
            }
        }

        private void List_Add()
        {
            listBox1.Items.Add($"Имя: {textBox1.Text}, Фамилия: {textBox2.Text}, e-mail: {textBox3.Text}, телефон: {textBox4.Text}");
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
        }

        private void Button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Change_User();
            }
        }

        private void Button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Change_User();
            }
        }

        private void Change_User()
        {
            if (listBox1.SelectedIndex != -1)
            {
                bool name = false;
                bool surname = false;
                bool mail = false;
                bool phone = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = true;
                button9.Visible = true;
                string user = listBox1.SelectedItem.ToString();
                index = listBox1.SelectedIndex;
                foreach (string component in user.Split(' ', ',', ':'))
                {
                    if (component != "")
                    {
                        if (name == true)
                        {
                            name = false;
                            textBox1.Text = component;
                        }
                        if (component == "Имя")
                            name = true;
                        if (surname == true)
                        {
                            surname = false;
                            textBox2.Text = component;
                        }
                        if (component == "Фамилия")
                            surname = true;
                        if (mail == true)
                        {
                            mail = false;
                            textBox3.Text = component;
                        }
                        if (component == "e-mail")
                            mail = true;
                        if (phone == true)
                        {
                            phone = false;
                            textBox4.Text = component;
                        }
                        if (component == "телефон")
                            phone = true;
                    }
                }
            }
        }

        private void Button9_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Save_chande();
            }
        }

        private void Button9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save_chande();
            }
        }

        private void Save_chande()
        {
            listBox1.Items[index] = $"Имя: {textBox1.Text}, Фамилия: {textBox2.Text}, e-mail: {textBox3.Text}, телефон: {textBox4.Text}";
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = false;
            button9.Visible = false;
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
        }

        private void Button8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cancel_chande();
            }
        }

        private void Button8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cancel_chande();
            }
        }

        private void Cancel_chande()
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = false;
            button9.Visible = false;
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
        }

        private void Button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Delete_User();
            }
        }

        private void Button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Delete_User();
            }
        }

        private void Delete_User()
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void Button4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listBox1.Items.Count == 0)
                {
                    Import_with_txt();
                }
                else
                {
                    var message = MessageBox.Show("Список не пуст. Заменить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (message == DialogResult.Yes)
                        Import_with_txt();
                }
            }
        }

        private void Button4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.Items.Count == 0)
                {
                    Import_with_txt();
                }
                else
                {
                    var message = MessageBox.Show("Список не пуст. Заменить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (message == DialogResult.Yes)
                        Import_with_txt();
                }
            }
        }

        private void Import_with_txt()
        {
            listBox1.Items.Clear();
            try
            {
                using (StreamReader sr = new StreamReader("Users.txt", System.Text.Encoding.Default))
                {
                    string text = "";
                    while ((text = sr.ReadLine()) != null)
                    {
                        listBox1.Items.Add(text);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.Items.Count != 0)
                {
                    Save_to_txt();
                }
                else
                {
                    MessageBox.Show("Список пуст.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Button7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listBox1.Items.Count != 0)
                {
                    Save_to_txt();
                }
                else
                {
                    MessageBox.Show("Список пуст.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }

        private void Save_to_txt()
        {
            listBox1.Items.Clear();
            try
            {
                using (StreamWriter sw = new StreamWriter("Users.txt", false, System.Text.Encoding.Default))
                {
                    for(int i = 0; i<listBox1.Items.Count; i++)
                    {
                        sw.WriteLine(listBox1.Items[i].ToString());
                    }
                }
                MessageBox.Show("Сохранено в файл txt", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Файл занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listBox1.Items.Count == 0)
                {
                    Import_with_xml();
                }
                else
                {
                    var message = MessageBox.Show("Список не пуст. Заменить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (message == DialogResult.Yes)
                        Import_with_xml();
                }
            }
        }

        private void Button5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.Items.Count == 0)
                {
                    Import_with_xml();
                }
                else
                {
                    var message = MessageBox.Show("Список не пуст. Заменить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (message == DialogResult.Yes)
                        Import_with_xml();
                }
            }
        }

        private void Import_with_xml()
        {
            listBox1.Items.Clear();
            try
            {
               
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listBox1.Items.Count != 0)
                {
                    Save_to_xml();
                }
                else
                {
                    MessageBox.Show("Список пуст.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void Button6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.Items.Count != 0)
                {
                    Save_to_xml();
                }
                else
                {
                    MessageBox.Show("Список пуст.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Save_to_xml()
        {
            listBox1.Items.Clear();
            try
            {
                var doc = new XmlDocument();
                var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-16", null);
                doc.AppendChild(xmlDeclaration);
                var root = doc.CreateElement("Список Users");
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    var UserNode = doc.CreateElement("Users");
                    var attribute = doc.CreateAttribute("N");
                    attribute.InnerText = $"{i + 1}";
                    var information = doc.CreateElement("Informatiom");
                    information.InnerText = listBox1.Items[i].ToString();
                    UserNode.AppendChild(information);
                }
                doc.Save("Users.xml");
            }
            catch (Exception)
            {
                MessageBox.Show("Файл занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
