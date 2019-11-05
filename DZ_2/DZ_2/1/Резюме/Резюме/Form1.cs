using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Резюме
{
    public partial class Form1 : Form
    {
        string FIO = "Фамилия Имя Очество";
        string birthday = "day";
        string work = "work here";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int symbol = 0;
            int tmp = FIO.Length + birthday.Length + work.Length;
            symbol = tmp / FIO.Length;
            Text = symbol.ToString();
            var message = MessageBox.Show(FIO, Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
            if(message == DialogResult.OK)
            {
                symbol = tmp / birthday.Length;
                Text = symbol.ToString();
                message = MessageBox.Show(birthday, Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
                if(message == DialogResult.OK)
                {
                    symbol = tmp / work.Length;
                    Text = symbol.ToString();
                    message = MessageBox.Show(work, Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

      
    }
}
