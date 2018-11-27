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
    public partial class ShowMessage : FormDesign
    {
        public ShowMessage()
        {
            InitializeComponent();
            StillContinue = false;
        }
        private bool StillContinue { get; set; }
        private void button3_Click(object sender, EventArgs e)
        {
            StillContinue = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StillContinue = false;
            this.Close();
        }
        public bool getContinue()
        {
            return StillContinue;
        }
    }

}
