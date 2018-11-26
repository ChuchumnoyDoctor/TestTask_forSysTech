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
            GetWorker(ForeignKey);
            GetPravaDostupa(Person.FK_GroupOfWorker.LevelOfGroup);
        }
        private Worker Person { get; set; }
        private int Key { get; set; }
        private void GetWorker(int PrimaryKey)
        {
            ZaprosVBD zaprosVBD = new ZaprosVBD();
            Person = zaprosVBD.GetWorkerFromBD(PrimaryKey);
        }

        private void GetPravaDostupa(int PrDst)
        {
            if (PrDst >= 1)
            {
                SetPersonalData(Person);
                this.tabPage1.Parent = this.tabControl1; //show
            }
            if (PrDst >= 2)
            {
                SetDataPodchinenih(Person.Id);
                this.tabPage2.Parent = this.tabControl1; //show
            }
            if (PrDst == 5)
            {
                this.tabPage3.Parent = this.tabControl1; //show
                listBox1.SetSelected(0, true);
            }
        }
        
        private void SetDataPodchinenih(int Fk_IdNachalnik)
        {
            List<Worker> data = new List<Worker>();
            data = GetDataPodchinenihFromBD(Fk_IdNachalnik);
            ZaprosRashetaZP zp = new ZaprosRashetaZP();
            dataGridView1.DataSource = zp.CreateNewDataRow(data);
        }
        private List<Worker> GetDataPodchinenihFromBD(int Fk_IdNachalnik)
        {
            ZaprosVBD zaprosVBD = new ZaprosVBD();
            List<Worker> data = new List<Worker>();
            data = zaprosVBD.GetSpisokPodchinenih(Fk_IdNachalnik);
            return data;
        }
        private void SetPersonalData(Worker Person)
        {
            this.textBoxName.Text = Person.Name;
            this.textBoxSecondName.Text = Person.SecondName;
            this.textBoxGroup.Text = Person.FK_GroupOfWorker.NameOfGroup;
            this.textBoxBazStavkaZarPlat.Text = Person.BazovayaStavkaZP + "";
            this.textBoxNachalnik.Text = Person.Nachalnik;
            this.dateTimePickerDataPostup.Text = Person.DataPostupleniyaNaRabotu;
        }

        private void SetPravaDostupa()
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            ZaprosRashetaZP zP = new ZaprosRashetaZP();
            Dictionary<string, string> l = new Dictionary<string, string>();
            l = zP.GetRashetZP(Person.Id, Person.FK_GroupOfWorker, dateTimePicker6.Value + "", dateTimePicker5.Value + "", Person.BazovayaStavkaZP, Person.DataPostupleniyaNaRabotu);
            textBox5.Text = ((double)((int)(double.Parse(l.Keys.First()) * 100)) / 100).ToString(); 
            textBox6.Text = ((double)((int)(double.Parse(l.Values.First()) * 100)) / 100).ToString();
            textBox9.Text = (double.Parse(textBox5.Text) + double.Parse(textBox6.Text)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZaprosVBD zaprosVBD = new ZaprosVBD();

            int i = Int32.Parse(listBox2.SelectedIndex.ToString());
            listBox2.SelectedItem.ToString();
            Key = zaprosVBD.SetWorkerFromBD(textBox4.Text, textBox10.Text, dateTimePicker2.Value + "", listBox1.SelectedItem.ToString(), textBox3.Text, str.ElementAt(i).Key);
            if (Key != 0)
            {
                MessageBox.Show("Сотрудник успешно создан.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Сначало создайте сотрудника.");
            }
            else
            {
                ZaprosVBD zaprosVBD = new ZaprosVBD();
                string str = zaprosVBD.SetZapros(textBox8.Text, textBox7.Text,Key);
                MessageBox.Show(str);
            }
        }
        Dictionary<int, string> str = new Dictionary<int, string>();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZaprosVBD zaprosVBD = new ZaprosVBD();
            str = new Dictionary<int, string>();
            str = zaprosVBD.GetNachalnik(listBox1.SelectedItem.ToString());
            listBox2.Items.Clear();
            foreach(string s in str.Values)
            {
                listBox2.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZaprosRashetaZP zP = new ZaprosRashetaZP();
            Dictionary<string, string> l = new Dictionary<string, string>();
            l = zP.GetRashetZP(Person.Id, Person.FK_GroupOfWorker, dateTimePicker6.Value + "", dateTimePicker5.Value + "", Person.BazovayaStavkaZP, Person.DataPostupleniyaNaRabotu);
            textBox5.Text = ((double)((int)(double.Parse(l.Keys.First()) * 100)) / 100).ToString(); //ограничил двумя знаками после запятой.
            textBox6.Text = ((double)((int)(double.Parse(l.Values.First()) * 100)) / 100).ToString(); //ограничил двумя знаками после запятой.
            textBox9.Text = (double.Parse(textBox5.Text) + double.Parse(textBox6.Text)).ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Worker> lW = new List<Worker>();
            int Shet = 0;
            int numberOfRow = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                numberOfRow++;
                string s = row.Cells[dataGridView1.ColumnCount - 1].EditedFormattedValue.ToString();
                if (s == "True")
                {
                    if (row.Cells[0].Value.ToString() != "")
                    {
                        Worker l = new Worker();
                        l.Name = row.Cells[0].Value.ToString();
                        l.SecondName = row.Cells[1].Value.ToString();
                        l.DataPostupleniyaNaRabotu = row.Cells[2].Value.ToString();
                        GroupOfWorker g = new GroupOfWorker();
                        g.NameOfGroup = row.Cells[3].Value.ToString();
                        l.FK_GroupOfWorker = g;
                        l.BazovayaStavkaZP = double.Parse(row.Cells[4].Value.ToString());
                        l.Nachalnik = row.Cells[5].Value.ToString();
                        lW.Add(l);
                        Shet++;
                    }
                }
                List<Worker> lWAdd = new List<Worker>();
                s = row.Cells[dataGridView1.ColumnCount - 2].EditedFormattedValue.ToString();
                if (s == "True")
                {
                    if (row.Cells[0].Value.ToString() != "")
                    {
                        Worker l = new Worker();
                        l.Name = row.Cells[0].Value.ToString();
                        l.SecondName = row.Cells[1].Value.ToString();
                        l.DataPostupleniyaNaRabotu = row.Cells[2].Value.ToString();
                        GroupOfWorker g = new GroupOfWorker();
                        g.NameOfGroup = row.Cells[3].Value.ToString();
                        l.FK_GroupOfWorker = g;
                        l.BazovayaStavkaZP = double.Parse(row.Cells[4].Value.ToString());
                        l.Nachalnik = row.Cells[5].Value.ToString();
                        ZaprosVBD zaprosVBD = new ZaprosVBD();
                        lWAdd = zaprosVBD.GetSpisokPodchinenih(l.Name, l.SecondName, l.DataPostupleniyaNaRabotu, l.FK_GroupOfWorker.NameOfGroup, l.BazovayaStavkaZP);
                        SetDataPodchinenihAdd(lWAdd, numberOfRow);
                    }
                }
            }
            textBox12.Text = Shet.ToString();
            //при клики на дата грид вью
        }
        private void SetDataPodchinenihAdd(List<Worker> workers, int index)
        {
            ZaprosRashetaZP zp = new ZaprosRashetaZP();
            dataGridView1.DataSource = zp.CreateNewDataRowAddAtIndex(GetDataGridViewAsDataTable(dataGridView1), workers, index);           
        }
        private DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
        {


            if (_DataGridView.ColumnCount == 0) return null;
            DataTable dtSource = new DataTable();
            //////create columns
            foreach (DataGridViewColumn col in _DataGridView.Columns)
            {
                if (col.ValueType == null) dtSource.Columns.Add(col.Name, typeof(string));
                else dtSource.Columns.Add(col.Name, col.ValueType);
                dtSource.Columns[col.Name].Caption = col.HeaderText;
            }
            ///////insert row data
            foreach (DataGridViewRow row in _DataGridView.Rows)
            {
                try
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        /* if (row.Cells[col.ColumnName].Value.ToString() == "null")
                         {
                             break;
                         }*/
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                catch
                {

                }
            }
            return dtSource;
        }
    }
}
