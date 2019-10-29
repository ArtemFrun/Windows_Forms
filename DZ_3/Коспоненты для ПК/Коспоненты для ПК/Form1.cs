using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Коспоненты_для_ПК
{
    public partial class Form1 : Form
    {
        public static List<Component> comp = new List<Component>();

        public Form1()
        {
            InitializeComponent();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Component>));
            using (FileStream fs = new FileStream("Components.xml", FileMode.OpenOrCreate))
            {
                comp = (List<Component>)formatter.Deserialize(fs);
            }
            if(comp.Count > 0)
            {
                foreach(var _comp in comp)
                {
                    comboBox1.Items.Add(_comp.name);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Component component = new Component();
            Form2 form2 = new Form2();
            form2.New_component(component);
            if (form2.ShowDialog() == DialogResult.OK)
            {
                comp.Add(component);
                comboBox1.Items.Add(component.name);

                XmlSerializer formatter = new XmlSerializer(typeof(List<Component>));
                using (FileStream fs = new FileStream("Components.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, comp);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Component component = new Component();
            Form2 form2 = new Form2();
            if (comboBox1.SelectedIndex != -1)
            {

                int index = comboBox1.SelectedIndex;
                component = comp.ElementAt(index);
                form2.Chande_component(component);
                if(form2.ShowDialog() == DialogResult.OK)
                {
                    comp.RemoveAt(index);
                    comp.Insert(index, component);

                    XmlSerializer formatter = new XmlSerializer(typeof(List<Component>));
                    using (FileStream fs = new FileStream("Components.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, comp);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не верно выбран товар для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {

            }
        }
    }
}
