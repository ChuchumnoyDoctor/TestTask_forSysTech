using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask_ChuchumakovEV
{
    public partial class FormDesign : Form
    {
        public FormDesign()
        {
            InitializeComponent();
            
        }
        private string locationlocation { get; set; }
        public string path { get; set; }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void setPathDefault(string path)
        {
            this.path = path;
        }
        public void setPathDefault()
        {
            locationlocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
            path = System.IO.Path.GetDirectoryName(locationlocation);
        }
    }
}
