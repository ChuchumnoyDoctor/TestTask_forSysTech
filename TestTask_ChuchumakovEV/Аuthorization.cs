using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask_ChuchumakovEV
{
    public partial class Аuthorization : FormDesign
    {
        public Аuthorization()
        {
            InitializeComponent();
        }

        private void panel3_Resize(object sender, EventArgs e)
        {
            this.groupBox1.Location = new Point(this.panel3.Location.X + this.panel3.Size.Width / 2 - this.groupBox1.Size.Width / 2, this.panel3.Location.Y - this.panel3.Size.Height / 2 + this.groupBox1.Size.Height / 2);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Registration f = new Registration();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Login = textBoxName.Text;
            string Password = textBoxPassword.Text;
            string str = "";
            string fk;
            ZaprosVBD ZaprosPodkucheniya = new ZaprosVBD();
            str = ZaprosPodkucheniya.GetZapros(Login, Password);

            if (str == "Неверный логин и/или пароль.")
            {
                MessageBox.Show("Неверный пароль и/или логин");
            }
            else
            {
                fk = ZaprosPodkucheniya.FK_IdWorker;
                int x = 0;
                bool IsFK;
                try
                {
                    x = Int32.Parse(fk);
                    IsFK = true;
                }
                catch
                {
                    IsFK = false;
                    MessageBox.Show("Отсутствуют права доступа. Попробуйте позже или свяжитесь с администратором.");
                }
                if (IsFK) {
                    MainForm f = new MainForm(x);
                    this.Hide();
                    f.ShowDialog();
                    textBoxPassword.Text = "";
                    this.Show();
                }
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help f = new Help();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
