using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask_ChuchumakovEV
{
    public partial class Help : FormDesign
    {
        public Help()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.ShowDialog();
            string filename = opf.FileName;
            string[] splitpath = filename.Split('\\');
            string name = "";
            for (int i = 0; i < splitpath.Length - 1; i++)
            {
                name = name + "\\" + splitpath[i];
            }
            setPathDefault(name);
        }
    }
}
