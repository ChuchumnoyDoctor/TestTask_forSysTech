using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask_ChuchumakovEV
{
    public partial class Registration : FormDesign
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registration_Resize(object sender, EventArgs e)
        {
            this.groupBox1.Location = new Point(this.panel3.Location.X + this.panel3.Size.Width / 2 - this.groupBox1.Size.Width / 2, this.panel3.Location.Y - this.panel3.Size.Height / 2 + this.groupBox1.Size.Height / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox4.Text;
            string pass = textBox3.Text;
            ZaprosVBD ZaprosPodklucheniya = new ZaprosVBD();
            bool Next = false;
            string str = "";
            try
            {
                str = ZaprosPodklucheniya.SetZapros(login, pass, path);
                Next = true;
            }
            catch
            {
                MessageBox.Show("Не доступа к БД или она не найдена. Попробуйте указать путь через меню, что сразу под кнопкой авторизации.");
                Next = false;
            }
            if (Next)
            {
                MessageBox.Show(str);
                if (str == "Регистрация прошла успешно!")
                {
                    this.Close();
                }
            }
        }
    }
}
