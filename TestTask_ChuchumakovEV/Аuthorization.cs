﻿using System;
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
            SQLiteConnection conn = new SQLiteConnection("Data Source=DBforTestTask.db;");
            conn.Open();
            SQLiteCommand command;
           //command = new SQLiteCommand();
           
            string sql = "SELECT * FROM GroupOfWorker";
            command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
           /* SQLiteDataAdapter ad = new SQLiteDataAdapter(command);
            DataSet data = new DataSet();
            data.Reset();
            ad.Fill(data);*/
            reader.Read();
            string table = reader.GetString(0);
            MessageBox.Show(table);
            /*
            string baseName = "DBforTestTask.db";
            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName + "Version = 3; New =; Compress = True;";
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"select * from GroupOfWorker;";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }*/
            /*string login = textBox1.Text;
            string pass = textBox2.Text;
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source = Борей.accdb");
            conn.Open();
            OleDbCommand comm = new OleDbCommand("SELECT COUNT (*) FROM users WHERE login = '" + login + "' and password = '" + pass + "'", conn);


            if ((int)(comm.ExecuteScalar()) == 1)
            {*/
            MainForm f = new MainForm();
                this.Hide();
                f.ShowDialog();
                this.Show();/*
            }
            else {MessageBox.Show("Неверный пароль и/или логин");}     */
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
