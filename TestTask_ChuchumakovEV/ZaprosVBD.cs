using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_ChuchumakovEV
{
    class ZaprosVBD
    {
        public string GetZapros(string Login, string Password)
        {
            string str = "";
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql;
            sql = "SELECT Login, Password, FK_IdWorker  FROM UchentnieDannie WHERE Login = '" + Login + "' and Password = '" + Password + "'";
            command = new SQLiteCommand(sql, conn);
            object result = command.ExecuteScalar(); // ExecuteScalar fails on null
            reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            if (result == null)
            {
                str = "Неверный логин и/или пароль.";
                reader.Close();
            }
            else
            {
                while (reader.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                }
                FK_IdWorker = data[0][2];
                reader.Close();
            }
            conn.Close();
            return str;
        }
        public string FK_IdWorker { get; set; }
        public string SetZapros(string Login, string Password)
        {
            string login = Login;
            string pass = Password;
            string ret = "Такой пользователь уже существует";
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteCommand comm = new SQLiteCommand("SELECT COUNT (*) FROM UchentnieDannie WHERE Login = '" + login + "' and password = '" + pass + "'", conn);
            object result = comm.ExecuteScalar(); // ExecuteScalar fails on null
            int i = (int)Convert.ToInt32(result);
            if (i == 1)
            {
                ret = "Такой пользователь уже существует!";
            }
            else
                if (result.GetType() != typeof(DBNull))
            {
                comm = new SQLiteCommand("INSERT INTO `UchentnieDannie` (`Login`,`Password`) VALUES ('" + login + "', '" + pass + "')", conn);
                comm.ExecuteNonQuery();
                ret = "Регистрация прошла успешно!";
            }
            else
            {
                ///
            }
            conn.Close();
            return ret;
        }
        public List<Worker> GetSpisokPodchinenih(int Fk_IdNachalnik)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql;
            sql = "SELECT Fk_IdSotrudnik  FROM SvyazSotrudnikNachalnik WHERE Fk_IdNachalnik = '" + Fk_IdNachalnik + "'";
            command = new SQLiteCommand(sql, conn);
            object result = command.ExecuteScalar(); // ExecuteScalar fails on null
            reader = command.ExecuteReader();
            List<Worker> data = new List<Worker>();
            if (result == null)
            {
                ///
                reader.Close();
            }
            else
            {
                while (reader.Read())
                {
                    Worker work = new Worker();
                    work = GetWorkerFromBD(Int32.Parse(reader[0].ToString()));
                    data.Add(work);
                }
                reader.Close();
            }
            conn.Close();
            return data;
        }
        public List<Worker> GetSpisokPodchinenih(string Name, string SecondName, string DataPostupleniyaNaRabotu, string NameOfGroup, double BazovayaStavkaZP)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql;
            sql = "SELECT Id  FROM GroupOfWorker WHERE NameOfGroup = '" + NameOfGroup + "'";
            command = new SQLiteCommand(sql, conn);
            object result = command.ExecuteScalar(); // ExecuteScalar fails on null
            reader = command.ExecuteReader();
            List<Worker> data = new List<Worker>();
            Worker w = new Worker();
            if (result == null)
            {
            }
            else
            {
                while (reader.Read())
                {
                    GroupOfWorker g = new GroupOfWorker();
                    g.Id = Int32.Parse(reader[0].ToString());
                    w.FK_GroupOfWorker = g;
                }
                reader.Close();
            }
            sql = "SELECT Id  FROM Worker WHERE Name = '" + Name + "' And SecondName = '" + SecondName + "' And DataPostupleniyaNaRabotu = '" + DataPostupleniyaNaRabotu + "'  And FK_GroupOfWorker = '" + w.FK_GroupOfWorker.Id + "'  And BazovayaStavkaZP = '" + BazovayaStavkaZP + "'";
            command = new SQLiteCommand(sql, conn);
            result = command.ExecuteScalar(); // ExecuteScalar fails on null
            reader = command.ExecuteReader();
            if (result == null)
            {
            }
            else
            {
                while (reader.Read())
                {
                    data =  GetSpisokPodchinenih(Int32.Parse(reader[0].ToString()));
                }
                reader.Close();
            }
            conn.Close();
            return data;
        }

        public string SetZapros(string Login, string Password, int Key)
        {
            string login = Login;
            string pass = Password;
            string ret = "Такой пользователь уже существует";
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteCommand comm = new SQLiteCommand("SELECT COUNT (*) FROM UchentnieDannie WHERE Login = '" + login + "' and password = '" + pass + "'", conn);
            object result = comm.ExecuteScalar(); // ExecuteScalar fails on null
            conn.Close();
            int i = (int)Convert.ToInt32(result);
            if (i == 1)
            {
                ret = "Такой пользователь уже существует!";
            }
            else
                if (result.GetType() != typeof(DBNull))
            {
                conn.Open();
                comm = new SQLiteCommand("INSERT INTO `UchentnieDannie` (`Login`,`Password`,`FK_IdWorker`) VALUES ('" + login + "', '" + pass + "', '" + Key + "')", conn);

                try
                {
                    comm.ExecuteNonQuery();
                    ret = "Регистрация прошла успешно!";
                }
                catch
                {
                    ret = "База данных не доступна.";
                }
                conn.Close();
            }
            else
            {
                ///
            }
            return ret;
        }
        public int SetWorkerFromBD(string Name, string SecondName, string DataPostupleniyaNaRabotu, string Name_GroupOfWorker, string BazovayaStavkaZP, int Id_Nachalnika)
        {
            ZaprosRashetaZP zP = new ZaprosRashetaZP();
            string[] str = zP.GetDelimiterByPoint(DataPostupleniyaNaRabotu);
            string DataP = str[0] + "." + str[1] + "." + str[2];
            Worker Person = new Worker();
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql;

            sql = "SELECT Id  FROM GroupOfWorker WHERE NameOfGroup = '" + Name_GroupOfWorker + "'";
            command = new SQLiteCommand(sql, conn);
            object result = command.ExecuteScalar(); // ExecuteScalar fails on null
            int id = 0;
            if (result == null)
            {
            }
            else
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Int32.Parse(reader[0].ToString());
                }
                
                reader.Close();
            }
            sql = "INSERT INTO Worker (Name,SecondName, DataPostupleniyaNaRabotu, FK_GroupOfWorker, BazovayaStavkaZP) VALUES('"+ Name  + "', '"+ SecondName + "', '"+ DataP + "', '"+ id + "', '"+BazovayaStavkaZP+"')";
            command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            

            sql = "SELECT Id  FROM Worker WHERE Name = '" + Name + "' And SecondName = '" + SecondName + "' And DataPostupleniyaNaRabotu = '" + DataP + "' And FK_GroupOfWorker = '" + id + "' And BazovayaStavkaZP = '" + BazovayaStavkaZP + "'";
            command = new SQLiteCommand(sql, conn);
            result = command.ExecuteScalar(); // ExecuteScalar fails on null
            int idd = 0;
            if (result == null)
            {
            }
            else
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idd = Int32.Parse(reader[0].ToString());
                }

                reader.Close();
            }

            sql = "INSERT INTO SvyazSotrudnikNachalnik (Fk_IdSotrudnik,Fk_IdNachalnik) VALUES('" + idd + "', '" + Id_Nachalnika + "')";
            command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            return idd;
        }
        public Worker GetWorkerFromBD(int PrimaryKey)
        {
            Worker Person = new Worker();
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql;
            sql = "SELECT *  FROM Worker WHERE Id = '" + PrimaryKey + "'";
            command = new SQLiteCommand(sql, conn);
            object result = command.ExecuteScalar(); // ExecuteScalar fails on null
            reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            if (result == null)
            {
                ///
                reader.Close();
            }
            else
            {
                while (reader.Read())
                {
                    data.Add(new string[6]);

                    Person.Id = Int32.Parse(reader[0].ToString());
                    Person.Name = reader[1].ToString();
                    Person.SecondName = reader[2].ToString();
                    Person.DataPostupleniyaNaRabotu = reader[3].ToString();
                    Person.FK_GroupOfWorker = GetGroupOfWorkerFromBD(Int32.Parse(reader[4].ToString()));
                    Person.BazovayaStavkaZP = Int32.Parse(reader[5].ToString());
                    Person.Nachalnik = GetNachalnik(Person.Id);
                }
                reader.Close();
            }
            conn.Close();
            return Person;
        }
        public string GetNachalnik(int Fk_IdSotrudnik)
        {
            string Person = "";
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql;
            sql = "SELECT Fk_IdNachalnik  FROM SvyazSotrudnikNachalnik WHERE Fk_IdSotrudnik = '" + Fk_IdSotrudnik + "'";
            command = new SQLiteCommand(sql, conn);
            object Fk_IdNachalnik = command.ExecuteScalar(); // ExecuteScalar fails on null

            sql = "SELECT Name, SecondName  FROM Worker WHERE Id = '" + Fk_IdNachalnik + "'";
            command = new SQLiteCommand(sql, conn);
            object result = command.ExecuteScalar(); // ExecuteScalar fails on null

            reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            if (result == null)
            {
                ///
                reader.Close();
            }
            else
            {
                while (reader.Read())
                {
                    data.Add(new string[2]);

                    Person = reader[0].ToString() + " " + reader[1].ToString();
                }
                reader.Close();
            }
            conn.Close();
            return Person;
        }
        public Dictionary<int, string> GetNachalnik(string GroupOfWorker)
        {
            GroupOfWorker groupOfWorker = new GroupOfWorker();
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql;
            sql = "SELECT LevelOfGroup  FROM GroupOfWorker WHERE NameOfGroup = '" + GroupOfWorker + "'";
            command = new SQLiteCommand(sql, conn);
            object result = command.ExecuteScalar(); // ExecuteScalar fails on null
            reader = command.ExecuteReader();
            int LevelOfGroup = 0;
            if (result == null)
            {
                ///
                reader.Close();
            }
            else
            {
                while (reader.Read())
                {
                    LevelOfGroup = Int32.Parse(reader[0].ToString());
                }
                reader.Close();
            }
            conn.Close();
            conn.Open();
            sql = "SELECT Id, NameOfGroup  FROM GroupOfWorker WHERE LevelOfGroup > '" + LevelOfGroup + "' And LevelOfGroup <=4";
            command = new SQLiteCommand(sql, conn);
            result = command.ExecuteScalar(); // ExecuteScalar fails on null
            reader = command.ExecuteReader();
            Dictionary<int, string> ListDict = new Dictionary<int, string>();
            if (result == null)
            {
                ///
                reader.Close();
            }
            else
            {
                while (reader.Read())
                {
                    ListDict.Add(Int32.Parse(reader[0].ToString()), reader[1].ToString());
                }
                reader.Close();
            }
            conn.Close();
            conn.Open();
            
            Dictionary<int, string> lst = new Dictionary<int, string>();
            foreach (int i in ListDict.Keys)
            {
                sql = "SELECT Id,Name, SecondName  FROM Worker WHERE FK_GroupOfWorker = '" + i + "'";
                command = new SQLiteCommand(sql, conn);
                result = command.ExecuteScalar(); // ExecuteScalar fails on null
                reader = command.ExecuteReader();
               
                if (result == null)
                {
                    ///
                    reader.Close();
                }
                else
                {
                    while (reader.Read())
                    {
                        lst.Add(Int32.Parse(reader[0].ToString()), reader[1].ToString() + " " + reader[2].ToString() + ", " + ListDict[i]);
                    }
                    reader.Close();
                }
                
            }
            conn.Close();
            return lst;
        }
        public GroupOfWorker GetGroupOfWorkerFromBD(int PrimaryKey)
        {
            GroupOfWorker groupOfWorker = new GroupOfWorker();
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteDataReader reader;
            SQLiteCommand command;
            string sql;
            sql = "SELECT *  FROM GroupOfWorker WHERE Id = '" + PrimaryKey + "'";
            command = new SQLiteCommand(sql, conn);
            object result = command.ExecuteScalar(); // ExecuteScalar fails on null
            reader = command.ExecuteReader();
            if (result == null)
            {
                ///
                reader.Close();
            }
            else
            {
                while (reader.Read())
                {
                    groupOfWorker.Id = Int32.Parse(reader[0].ToString());
                    groupOfWorker.NameOfGroup = reader[1].ToString();
                    groupOfWorker.ProcentStavkaByYear = Int32.Parse(reader[2].ToString());
                    groupOfWorker.EndProcentStavka = Int32.Parse(reader[3].ToString());
                    groupOfWorker.LevelOfGroup = Int32.Parse(reader[4].ToString());
                    groupOfWorker.ProcentStavkaPodchinennih = Double.Parse(reader[5].ToString());
                }
                reader.Close();
            }
            conn.Close();
            return groupOfWorker;
        }
    }
}
