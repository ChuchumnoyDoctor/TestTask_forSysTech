using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_ChuchumakovEV
{
    class ConnectionString
    {/*
        static void Main(string[] args)
        {
            string baseName = "DBforTestTask.db";
            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"CREATE TABLE [workers] (
                    [id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [name] char(100) NOT NULL,
                    [family] char(100) NOT NULL,
                    [age] int NOT NULL,
                    [profession] char(100) NOT NULL
                    );";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
        *//*
        SQLiteConnection connection = new SQLiteConnection();

        connection.ConnectionString = "Data Source = " + baseName;
             connection.Open(); 
            
                using ()   //Создание экземпляра класса SQLiteConnection
           {
            

             using (SQLiteCommand command = new SQLiteCommand(connection))
             {
              command.CommandText = @"CREATE TABLE [workers] (
                            [id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                            [name] char(100) NOT NULL,
                            [family] char(100) NOT NULL,
                            [age] int NOT NULL,
                            [profession] char(100) NOT NULL
                            );";
              command.CommandType = CommandType.Text;
              command.ExecuteNonQuery();
             }
           }*/
         /*
                 string login = textBox1.Text;
                 string pass = textBox2.Text;
                 OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source = Борей.accdb");
                 conn.Open();
                     OleDbCommand comm = new OleDbCommand("SELECT COUNT (*) FROM users WHERE login = '" + login + "' and password = '" + pass + "'", conn);


                     if ((int)(comm.ExecuteScalar()) == 1)
                     {
                         MainBD f = new MainBD();
                         this.Hide();
                 f.ShowDialog();
                         this.Show();
             }
                     else {MessageBox.Show("Неверный пароль и/или логин");}
         */

        //    SQLiteConnection conn = new SQLiteConnection();
        /* try
         {
         db->ConnectionString = "Data Source=\"" + fileName + "\"";
         db->Open();

             db->Close();
         }
     finally
     {
         delete(IDisposable^)db;
     }
         }-*/
        // SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
        /*
               public int fileDBexist(string FileData) //возвращает "0" если файл БД существовал, "1" - вновь создан, "-1" - исключение
       {
           int n = 0;
           try
           {
               using (SQLiteConnection con = new SQLiteConnection())   //Создание экземпляра класса SQLiteConnection
               {
                   if (!File.Exists(FileData))
                   {
                       con.ConnectionString = @"Data Source=" + FileData + ";New=True;Version=3"; //строка соединения c БД (фактически создания), где FileData путь к файлу.
                       con.Open();     //создание файла БД и соединение с ним
                       con.Close();    //закрытие соединения
                       n = 1;
                   }
               }
           }
           catch (Exception ex)
           {
               n = -1;
           }
           return n;
       }
       */
    }
}
