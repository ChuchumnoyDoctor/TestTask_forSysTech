using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_ChuchumakovEV
{
    class ZaprosRashetaZP
    {
        public DataTable CreateNewDataRow(List<Worker> data)
        {
            // Use the MakeTable function below to create a new table.
            DataTable table;
            table = MakeNamesTable();

            // Once a table has been created, use the 
            // NewRow to create a DataRow.
            DataRow row;
            foreach (Worker a in data)
            {
                row = table.NewRow();

                // Then add the new row to the collection.
                row["Имя"] = a.Name;
                row["Фамилия"] = a.SecondName;
                row["Дата поступления на работу"] = a.DataPostupleniyaNaRabotu;
                row["Группа"] = a.FK_GroupOfWorker.NameOfGroup;
                row["Базовая ставка"] = a.BazovayaStavkaZP;
                row["Начальник"] = a.Nachalnik;
                row["Отобразить подчиненных выбранного сотрудника"] = false;
                row["Выбрать для расчёта ЗП"] = false;
                table.Rows.Add(row);
            }
            //dataGridView1.DataSource = table;
            /*
            BindingSource _bindingSource = new BindingSource();
            dataGridView1.DataSource = _bindingSource;
            _bindingSource.DataSource = SpisokVibrannih;
            */
            return table;
        }
        public DataTable CreateNewDataRowAddAtIndex(DataTable data, List<Worker> dataAdd, int index)
        {
            // Use the MakeTable function below to create a new table.
            DataTable table;
            table = MakeNamesTable();
            // Once a table has been created, use the 
            // NewRow to create a DataRow.
            DataRow row;
            for(int i = 0; i < index; i++)
            {
                row = table.NewRow();
                row["Имя"] = data.Rows[i][0];
                row["Фамилия"] = data.Rows[i][1];
                row["Дата поступления на работу"] = data.Rows[i][2];
                row["Группа"] = data.Rows[i][3];
                row["Базовая ставка"] = data.Rows[i][4];
                row["Начальник"] = data.Rows[i][5];
                if(i == index - 1)
                {
                    if ((bool)data.Rows[i][6])
                    {
                        row["Отобразить подчиненных выбранного сотрудника"] = false;
                    }
                    else
                    {
                        row["Отобразить подчиненных выбранного сотрудника"] = true;
                    }
                }
                else
                {
                    row["Выбрать для расчёта ЗП"] = data.Rows[i][6];
                }
                row["Выбрать для расчёта ЗП"] = data.Rows[i][7];
                table.Rows.Add(row);
            }
            foreach (Worker a in dataAdd)
            {
                row = table.NewRow();

                // Then add the new row to the collection.
                row["Имя"] = a.Name;
                row["Фамилия"] = a.SecondName;
                row["Дата поступления на работу"] = a.DataPostupleniyaNaRabotu;
                row["Группа"] = a.FK_GroupOfWorker.NameOfGroup;
                row["Базовая ставка"] = a.BazovayaStavkaZP;
                row["Начальник"] = a.Nachalnik;
                row["Отобразить подчиненных выбранного сотрудника"] = false;
                row["Выбрать для расчёта ЗП"] = false;
                table.Rows.Add(row);
            }
            for (int i = index+1; i < data.Rows.Count; i++)
            {
                row = table.NewRow();
                row["Имя"] = data.Rows[i][0];
                row["Фамилия"] = data.Rows[i][1];
                row["Дата поступления на работу"] = data.Rows[i][2];
                row["Группа"] = data.Rows[i][3];
                row["Базовая ставка"] = data.Rows[i][4];
                row["Начальник"] = data.Rows[i][5];
                row["Отобразить подчиненных выбранного сотрудника"] = data.Rows[i][6];
                row["Выбрать для расчёта ЗП"] = data.Rows[i][7];
                table.Rows.Add(row);
            }
            //dataGridView1.DataSource = table;
            /*
            BindingSource _bindingSource = new BindingSource();
            dataGridView1.DataSource = _bindingSource;
            _bindingSource.DataSource = SpisokVibrannih;
            */
            return table;
        }

        private DataTable MakeNamesTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable namesTable = new DataTable("Podchnennie");

            DataColumn fNameColumn = new DataColumn();
            fNameColumn.DataType = System.Type.GetType("System.String");
            fNameColumn.ColumnName = "Имя";
            namesTable.Columns.Add(fNameColumn);

            DataColumn SecondNameColumn = new DataColumn();
            SecondNameColumn.DataType = System.Type.GetType("System.String");
            SecondNameColumn.ColumnName = "Фамилия";
            namesTable.Columns.Add(SecondNameColumn);

            DataColumn DPNameColumn = new DataColumn();
            DPNameColumn.DataType = System.Type.GetType("System.String");
            DPNameColumn.ColumnName = "Дата поступления на работу";
            namesTable.Columns.Add(DPNameColumn);

            DataColumn GNameColumn = new DataColumn();
            GNameColumn.DataType = System.Type.GetType("System.String");
            GNameColumn.ColumnName = "Группа";
            namesTable.Columns.Add(GNameColumn);

            DataColumn BSNameColumn = new DataColumn();
            BSNameColumn.DataType = System.Type.GetType("System.Double");
            BSNameColumn.ColumnName = "Базовая ставка";
            namesTable.Columns.Add(BSNameColumn);

            DataColumn NCHNameColumn = new DataColumn();
            NCHNameColumn.DataType = System.Type.GetType("System.String");
            NCHNameColumn.ColumnName = "Начальник";
            namesTable.Columns.Add(NCHNameColumn);

            DataColumn SelectNameColumn = new DataColumn();
            SelectNameColumn.DataType = System.Type.GetType("System.Boolean");
            SelectNameColumn.ColumnName = "Отобразить подчиненных выбранного сотрудника";
            namesTable.Columns.Add(SelectNameColumn);

            DataColumn BoolNameColumn = new DataColumn();
            BoolNameColumn.DataType = System.Type.GetType("System.Boolean");
            BoolNameColumn.ColumnName = "Выбрать для расчёта ЗП";
            namesTable.Columns.Add(BoolNameColumn);

            // Return the new DataTable.
            return namesTable;
        }
        public Dictionary<string,string> GetRashetZP(int Id, GroupOfWorker groupOfWorker, string DataStart, string DataEnd, double BaseStavka, string DataPostup)
        {
            double ItogovayaZP = 0;
            GroupOfWorker gr = groupOfWorker;

            ZaprosVBD zaprosVBD = new ZaprosVBD();
            List<Worker> data = new List<Worker>();
            data = zaprosVBD.GetSpisokPodchinenih(Id);
            string pod = "";
            double ar = 0;
            double arr = 0;
            if (data != null)
            {
                foreach (Worker w in data)
                {
                    Dictionary<string, string> r = GetRashetZP(w.Id, w.FK_GroupOfWorker, DataStart, DataEnd, w.BazovayaStavkaZP, w.DataPostupleniyaNaRabotu);
                    ar = double.Parse(r.Keys.First()) + double.Parse(r.Values.First());
                    arr = arr + ar;
                }
            }
            arr = arr * groupOfWorker.ProcentStavkaPodchinennih / 100;
            pod = arr + "";
            //  Зарплата = Зарплата за год / Дней в среднем
            //    не високосный год - не кратный 4 либо кратный 100 и не кратный 400
            int DayPostup = Int32.Parse(GetDelimiterByPoint(DataPostup + "")[0]);
            int MonthPostup = Int32.Parse(GetDelimiterByPoint(DataPostup + "")[1]);
            int YearPostup = Int32.Parse(GetDelimiterByPoint(DataPostup + "")[2]);

            int DayStart = Int32.Parse(GetDelimiterByPoint(DataStart + "")[0]);
            int MonthStart = Int32.Parse(GetDelimiterByPoint(DataStart + "")[1]);
            int YearStart = Int32.Parse(GetDelimiterByPoint(DataStart + "")[2]);

            int DayEnd = Int32.Parse(GetDelimiterByPoint(DataEnd + "")[0]);
            int MonthEnd = Int32.Parse(GetDelimiterByPoint(DataEnd + "")[1]);
            int YearEnd = Int32.Parse(GetDelimiterByPoint(DataEnd + "")[2]);

            List<int> year = new List<int>();//количество дней в году и месяце
            // ,31,28,31,30,31,30,31,31,30,31,30,31)
            year.Add(31);//январь
            year.Add(28);//февраль
            year.Add(31);//март
            year.Add(30);//апрель
            year.Add(31);//май
            year.Add(30);//июнь
            year.Add(31);//июль
            year.Add(31);//август
            year.Add(30);//сентябрь
            year.Add(31);//октябрь
            year.Add(30);//ноябрь
            year.Add(31);//декабрь
            int SredneeKolVODney = 0;
            foreach (int i in year)
            {
                SredneeKolVODney = SredneeKolVODney + i;
            }
            SredneeKolVODney = SredneeKolVODney / 12;
            double RashetOplatiDnya = BaseStavka / SredneeKolVODney;//расчет среднестатистической оплаты дня, работающего в этот день или нет

            int ThisMonth = MonthStart;
            int ThisDay = DayStart;
            double StajYear = YearStart - YearPostup - (float)MonthPostup / 12  + (float)MonthStart /12;//Стаж работы
            double ProcentByStaj = 0;
            /////////////////////////
            ProcentByStaj = ProverkaStaja(StajYear,gr.ProcentStavkaByYear,gr.EndProcentStavka);
            for (int i = YearStart; i<=YearEnd; i++)
            {
                int ThisEnd = 0;
                if(YearStart == YearEnd)
                {
                    ThisEnd = MonthEnd;
                }
                else
                {
                    ThisEnd = 12;
                }
                for (int j = ThisMonth; j <= ThisEnd; j++)
                {
                    if (j == MonthStart)
                    {
                        ThisDay = SredneeKolVODney - DayStart+1;
                    }
                    else
                        if (j == MonthEnd)
                        {
                            ThisDay = DayEnd;
                        }
                        else
                        {
                            ThisDay = SredneeKolVODney;
                        }
                    //расчет зп
                    //ItogovayaZP =
                    if (YearPostup == i)
                    {
                        if (MonthPostup < j)
                        {
                            float f = (float)ThisDay / SredneeKolVODney;
                            f = (float)f / 12;
                            StajYear = StajYear + f;
                            ProcentByStaj = ProverkaStaja(StajYear, gr.ProcentStavkaByYear, gr.EndProcentStavka);
                            ItogovayaZP = ItogovayaZP + BaseStavka + BaseStavka * (float)ProcentByStaj / 100;
                        }
                        else
                        {
                            if (MonthPostup == j)
                            {
                                int sum = SredneeKolVODney - DayPostup + 1;
                                float f = (float) sum/ SredneeKolVODney;
                                f = (float)f / 12;
                                StajYear = StajYear + f;//стаж отработанных дней в месяце поступления
                                ProcentByStaj = ProverkaStaja(StajYear, gr.ProcentStavkaByYear, gr.EndProcentStavka);
                                ItogovayaZP = ItogovayaZP + BaseStavka + BaseStavka * (float)ProcentByStaj / 100;
                            }
                        }
                    }
                    else
                    {
                        if (YearPostup < i)
                        {
                            float f = (float)ThisDay / SredneeKolVODney;
                            f = (float)f / 12;
                            StajYear = StajYear + f;
                            ProcentByStaj = ProverkaStaja(StajYear, gr.ProcentStavkaByYear, gr.EndProcentStavka);
                            ItogovayaZP = ItogovayaZP + BaseStavka + BaseStavka * (float)ProcentByStaj / 100;
                        }
                    }
                }
                ThisMonth = 0;
            }
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add(ItogovayaZP.ToString(), pod);
            return d;
        }
        public string[] GetDelimiterByPoint(string strr)
        {
            string[] words = strr.Split('.');
           // string[] w = words[2].Split(' ');
            words[2] = words[2].Split(' ')[0];
            return words;
        }
        public int ProverkaStaja(double Staj, int ProcentStavkaByYear, int EndProcentStavka)
        {
            int i = 0;
            int ProcentByStaj = 0;
            for (i = 0; i < (int)Staj; i++)
            {
                if (EndProcentStavka > ProcentByStaj)
                    ProcentByStaj = ProcentByStaj + ProcentStavkaByYear;
            }
            return ProcentByStaj;
        }
    }
}
