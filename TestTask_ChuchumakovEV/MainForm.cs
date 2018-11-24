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
    public partial class MainForm : FormDesign
    {
        public MainForm(int ForeignKey)
        {
            InitializeComponent();
            SetPravaDostupa();
            Worker Sotrudnik = GetWorker(ForeignKey);
            int PravaDostupa;
            PravaDostupa = Sotrudnik.FK_GroupOfWorker.LevelOfGroup;
            GetPravaDostupa(PravaDostupa);
            SetPersonalData(Sotrudnik);
        }

        public Worker GetWorker(int PrimaryKey)
        {
            Worker Person = new Worker();
            ZaprosVBD zaprosVBD = new ZaprosVBD();
            Person = zaprosVBD.GetWorkerFromBD(PrimaryKey);
            return Person;
        }

        public void GetPravaDostupa(int PrDst)
        {
            if(PrDst >=1)
            this.tabPage1.Parent = this.tabControl1; //show
            if (PrDst >= 2)
                this.tabPage2.Parent = this.tabControl1; //show
            if (PrDst == 5)
                this.tabPage3.Parent = this.tabControl1; //show
        }
        public void SetPersonalData(Worker Person)
        {
            
        }


        public void SetPravaDostupa()
        {
            this.tabPage1.Parent = null; // hide    
            this.tabPage2.Parent = null; // hide    
            this.tabPage3.Parent = null; // hide    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddWorker f = new AddWorker();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
