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
            sql = "SELECT Fk_IdNachalnik  FROM SvyazSotrudnikNachalnik WHERE Id = '" + Fk_IdSotrudnik + "'";
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
