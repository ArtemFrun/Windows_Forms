using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Угадай_число
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            int min = 1;
            int max = 2000;
            int num = 0;
            int count = 0;
            var message = MessageBox.Show("Игра Угадайка", "Угадайка", MessageBoxButtons.OK, MessageBoxIcon.Question);
            do
            {
                num = (max + min) / 2;
                message = MessageBox.Show("Загадайте число от 1 до 2000\n\n\nЗагадали?", "Угадайка", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    do
                    {

                        message = MessageBox.Show($"Ваше число {num}?", "Угадайка", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (message == DialogResult.No)
                        {
                            var message1 = MessageBox.Show($"Ваше число менше {num}?", "Угадайка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (message1 == DialogResult.Yes)
                                max = num;
                            if (message1 == DialogResult.No)
                            {
                                message1 = MessageBox.Show($"Ваше число больше {num}?", "Угадайка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (message1 == DialogResult.Yes)
                                    min = num;
                                if (message1 == DialogResult.No)
                                {
                                    message1 = MessageBox.Show($"Вы еще помните свое число?", "Угадайка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (message1 == DialogResult.No)
                                        message = MessageBox.Show($"Конец игры", "Угадайка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                }
                            }
                        }
                        count++;
                        num = (max + min) / 2;
                    } while (message != DialogResult.Yes && message != DialogResult.OK && message != DialogResult.Cancel);
                }

                message = MessageBox.Show($"Произведено запроссов {count}", "Угадайка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (message == DialogResult.OK)
                {
                    message = MessageBox.Show($"Повторить попытку?", "Угадайка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                }
            } while (message != DialogResult.Cancel);
            Close();
        }


    }
}
