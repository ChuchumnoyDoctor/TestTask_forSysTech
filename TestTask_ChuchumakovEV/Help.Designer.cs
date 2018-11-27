namespace TestTask_ChuchumakovEV
{
    partial class Help
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1125, 68);
            // 
            // textBox1
            // 
            this.textBox1.Size = new System.Drawing.Size(1125, 68);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 483);
            this.panel2.Size = new System.Drawing.Size(1125, 64);
            // 
            // textBox2
            // 
            this.textBox2.Size = new System.Drawing.Size(1125, 64);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(12, 437);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1101, 149);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Реализовано:";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Items.AddRange(new object[] {
            "Группы: Employee, Manager , Salesman. Права в порядке возрастания. Также выше по " +
                "правам добавлены группы: \"Отсутствует\" и \"Супер-пользователь\".",
            "Уровень прав доступа по возрастанию в зависимости от группы: Employee - 1, Manage" +
                "r -2 , Salesman -3, \"Отсутствует\" -4, \"Супер-пользователь\" - 5.",
            "Регистрация: после регистрации, без связанного с ними сотрудника, вход не доступе" +
                "н.",
            "Авторизация: по учетным данным, связанных с сотрудником.",
            "Класс по обработке функций и запросов к БД.",
            "Класс по обработке повторяющих функций в рамках программы.",
            "Классы, как описание экземпляров для следующих объектов: сотрудник, учетные данны" +
                "е, группа сотрудника - класс \"группа сотрудника\" вложен в класс \"сотрудник\".",
            "Форма и реализация по добавлению сотрудника и выдачи ему учетных данных доступна " +
                "пользователю группы \"Супер-пользователь\" в главном меню после авторизации. ",
            "Форма и реализация по просмотру подчиненных и расчету их заработной платы за опре" +
                "деленный период доступна пользователям всех групп, кроме \"Employee\".",
            resources.GetString("listBox1.Items"),
            resources.GetString("listBox1.Items1"),
            resources.GetString("listBox1.Items2"),
            "По средством выбора подчиненных сотрудников и подчиненных подчиненного, можно пос" +
                "читать ЗП всей компании."});
            this.listBox1.Location = new System.Drawing.Point(3, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(1095, 124);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Location = new System.Drawing.Point(12, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1101, 130);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Чтобы ещё добавил:";
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 19;
            this.listBox2.Items.AddRange(new object[] {
            "Всё ещё модули программы имеют повторения в коде. Оптимизировать до их объединени" +
                "я.",
            "Выбор уже существующего сотрудника и назначение ему учетных данных: новых или пом" +
                "енять.",
            "Форма изменения персональных данных для сотрудников, а также и удаление сотрудник" +
                "ов.",
            "Выбор всех сотрудников в связке \"подчиненный-подчиненного\" по одной кнопке, чтобы" +
                " посчитать ЗП всех моментально.",
            "Форма добавления новых групп сотрудников. Назначение дефолтных начальников для оп" +
                "ределенных групп.",
            "И форма удаления групп. (Форма=инструментарий)"});
            this.listBox2.Location = new System.Drawing.Point(3, 22);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(1095, 105);
            this.listBox2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(139, 437);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 36);
            this.button2.TabIndex = 15;
            this.button2.Text = "Указать путь к Базе Данных";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 547);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Help";
            this.Text = "Помощь";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.buttonExit, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        public System.Windows.Forms.Button button2;
    }
}