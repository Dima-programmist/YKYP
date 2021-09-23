namespace РасчетКУ
{
    partial class KUGraphForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.KU_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_calc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraphStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraphSumN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraphSumP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GraphSumS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Graph_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вводКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поставщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вВордToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вЭксельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KU_id,
            this.Vendor_id,
            this.Percent,
            this.Period,
            this.Date_from,
            this.Date_to,
            this.Date_calc,
            this.GraphStatus,
            this.GraphSumN,
            this.GraphSumP,
            this.GraphSumS,
            this.Graph_Id});
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1108, 491);
            this.dataGridView1.TabIndex = 0;
            // 
            // KU_id
            // 
            this.KU_id.HeaderText = "Номер КУ";
            this.KU_id.Name = "KU_id";
            this.KU_id.ReadOnly = true;
            // 
            // Vendor_id
            // 
            this.Vendor_id.HeaderText = "Номер поставщика";
            this.Vendor_id.Name = "Vendor_id";
            this.Vendor_id.ReadOnly = true;
            this.Vendor_id.ToolTipText = "Процент КУ";
            // 
            // Percent
            // 
            this.Percent.HeaderText = "Процент КУ";
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            // 
            // Period
            // 
            this.Period.HeaderText = "Период";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            // 
            // Date_from
            // 
            this.Date_from.HeaderText = "Дата С";
            this.Date_from.Name = "Date_from";
            this.Date_from.ReadOnly = true;
            // 
            // Date_to
            // 
            this.Date_to.HeaderText = "Дата По";
            this.Date_to.Name = "Date_to";
            this.Date_to.ReadOnly = true;
            // 
            // Date_calc
            // 
            this.Date_calc.HeaderText = "Дата расчета";
            this.Date_calc.Name = "Date_calc";
            this.Date_calc.ReadOnly = true;
            // 
            // GraphStatus
            // 
            this.GraphStatus.HeaderText = "Статус";
            this.GraphStatus.Name = "GraphStatus";
            this.GraphStatus.ReadOnly = true;
            this.GraphStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GraphStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GraphSumN
            // 
            this.GraphSumN.HeaderText = "Сумма по накладным";
            this.GraphSumN.Name = "GraphSumN";
            this.GraphSumN.ReadOnly = true;
            // 
            // GraphSumP
            // 
            this.GraphSumP.HeaderText = "Сумма премии";
            this.GraphSumP.Name = "GraphSumP";
            this.GraphSumP.ReadOnly = true;
            // 
            // GraphSumS
            // 
            this.GraphSumS.HeaderText = "Согласованная сумма премии";
            this.GraphSumS.Name = "GraphSumS";
            this.GraphSumS.ReadOnly = true;
            // 
            // Graph_Id
            // 
            this.Graph_Id.HeaderText = "Graph_Id";
            this.Graph_Id.Name = "Graph_Id";
            this.Graph_Id.ReadOnly = true;
            this.Graph_Id.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.действияToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.экспортToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1132, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вводКУToolStripMenuItem,
            this.списокКУToolStripMenuItem,
            this.поставщикиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // вводКУToolStripMenuItem
            // 
            this.вводКУToolStripMenuItem.Name = "вводКУToolStripMenuItem";
            this.вводКУToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.вводКУToolStripMenuItem.Text = "Ввод КУ";
            this.вводКУToolStripMenuItem.Click += new System.EventHandler(this.вводКУToolStripMenuItem_Click);
            // 
            // списокКУToolStripMenuItem
            // 
            this.списокКУToolStripMenuItem.Name = "списокКУToolStripMenuItem";
            this.списокКУToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.списокКУToolStripMenuItem.Text = "Список КУ";
            this.списокКУToolStripMenuItem.Click += new System.EventHandler(this.списокКУToolStripMenuItem_Click);
            // 
            // поставщикиToolStripMenuItem
            // 
            this.поставщикиToolStripMenuItem.Name = "поставщикиToolStripMenuItem";
            this.поставщикиToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.поставщикиToolStripMenuItem.Text = "Поставщики";
            this.поставщикиToolStripMenuItem.Click += new System.EventHandler(this.поставщикиToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.удалитьВсеToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // удалитьВсеToolStripMenuItem
            // 
            this.удалитьВсеToolStripMenuItem.Name = "удалитьВсеToolStripMenuItem";
            this.удалитьВсеToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.удалитьВсеToolStripMenuItem.Text = "Удалить все";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(99, 25);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вВордToolStripMenuItem,
            this.вЭксельToolStripMenuItem});
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(81, 25);
            this.экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // вВордToolStripMenuItem
            // 
            this.вВордToolStripMenuItem.Name = "вВордToolStripMenuItem";
            this.вВордToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.вВордToolStripMenuItem.Text = "Word";
            this.вВордToolStripMenuItem.Click += new System.EventHandler(this.WordToolStripMenuItem_Click);
            // 
            // вЭксельToolStripMenuItem
            // 
            this.вЭксельToolStripMenuItem.Name = "вЭксельToolStripMenuItem";
            this.вЭксельToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.вЭксельToolStripMenuItem.Text = "Excel";
            this.вЭксельToolStripMenuItem.Click += new System.EventHandler(this.ExcelToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(1001, 535);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 38);
            this.button3.TabIndex = 5;
            this.button3.Text = "Согласовать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(742, 535);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 38);
            this.button1.TabIndex = 7;
            this.button1.Text = "Рассчёт ретро-бонуса";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // KUGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(1132, 587);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(809, 510);
            this.Name = "KUGraphForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "График КУ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вводКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поставщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn KU_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_from;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_to;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_calc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraphStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraphSumN;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraphSumP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GraphSumS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Graph_Id;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вВордToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вЭксельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВсеToolStripMenuItem;
    }
}

