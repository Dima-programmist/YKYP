
namespace РасчетКУ
{
    partial class InputKUForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.create_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поставщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status_label = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.createNapprove_button = new System.Windows.Forms.Button();
            this.status_textBox = new System.Windows.Forms.TextBox();
            this.close_button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageToAdd = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.In_prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KU_idP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute1P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute2P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProducerP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BrandP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPageToExclude = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Ex_prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KU_idM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute1M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute2M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProducerM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BrandM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageToAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPageToExclude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(543, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ввод коммерческих условий";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(194, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Поставщик:";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(197, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 26);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(194, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Процент от оборота:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(197, 150);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 24);
            this.textBox1.TabIndex = 4;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress_only_float_numbers);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(516, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Период действия коммерческих условий:";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Неделя",
            "Месяц",
            "Квартал",
            "Год"});
            this.comboBox2.Location = new System.Drawing.Point(519, 148);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(157, 26);
            this.comboBox2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(194, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Дата начала:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(516, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Дата окончания:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(197, 210);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(157, 24);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(519, 210);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(157, 24);
            this.dateTimePicker2.TabIndex = 11;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // create_button
            // 
            this.create_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.create_button.Location = new System.Drawing.Point(547, 252);
            this.create_button.Name = "create_button";
            this.create_button.Size = new System.Drawing.Size(87, 27);
            this.create_button.TabIndex = 12;
            this.create_button.Text = "Создать";
            this.create_button.UseVisualStyleBackColor = true;
            this.create_button.Click += new System.EventHandler(this.create_button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(975, 29);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКУToolStripMenuItem,
            this.поставщикиToolStripMenuItem,
            this.графикКУToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(84, 25);
            this.открытьToolStripMenuItem.Text = "Открыть";
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
            // графикКУToolStripMenuItem
            // 
            this.графикКУToolStripMenuItem.Name = "графикКУToolStripMenuItem";
            this.графикКУToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.графикКУToolStripMenuItem.Text = "График КУ";
            this.графикКУToolStripMenuItem.Click += new System.EventHandler(this.графикКУToolStripMenuItem_Click);
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
            this.удалитьToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status_label.Location = new System.Drawing.Point(516, 55);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(60, 18);
            this.status_label.TabIndex = 16;
            this.status_label.Text = "Статус:";
            this.status_label.Visible = false;
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_button.Location = new System.Drawing.Point(197, 252);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(87, 27);
            this.cancel_button.TabIndex = 17;
            this.cancel_button.Text = "Отмена";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Visible = false;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // createNapprove_button
            // 
            this.createNapprove_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createNapprove_button.Location = new System.Drawing.Point(642, 252);
            this.createNapprove_button.Name = "createNapprove_button";
            this.createNapprove_button.Size = new System.Drawing.Size(174, 27);
            this.createNapprove_button.TabIndex = 18;
            this.createNapprove_button.Text = "Создать и утвердить";
            this.createNapprove_button.UseVisualStyleBackColor = true;
            this.createNapprove_button.Click += new System.EventHandler(this.createNapprove_button_Click);
            // 
            // status_textBox
            // 
            this.status_textBox.Enabled = false;
            this.status_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status_textBox.Location = new System.Drawing.Point(519, 78);
            this.status_textBox.Name = "status_textBox";
            this.status_textBox.Size = new System.Drawing.Size(157, 24);
            this.status_textBox.TabIndex = 19;
            this.status_textBox.Visible = false;
            // 
            // close_button
            // 
            this.close_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close_button.Location = new System.Drawing.Point(454, 252);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(87, 27);
            this.close_button.TabIndex = 20;
            this.close_button.Text = "Закрыть";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Visible = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageToAdd);
            this.tabControl1.Controls.Add(this.tabPageToExclude);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(28, 285);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 291);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPageToAdd
            // 
            this.tabPageToAdd.Controls.Add(this.dataGridView2);
            this.tabPageToAdd.Location = new System.Drawing.Point(4, 25);
            this.tabPageToAdd.Name = "tabPageToAdd";
            this.tabPageToAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageToAdd.Size = new System.Drawing.Size(852, 262);
            this.tabPageToAdd.TabIndex = 0;
            this.tabPageToAdd.Text = "Добавить в расчёт";
            this.tabPageToAdd.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In_prod_id,
            this.KU_idP,
            this.TypeP,
            this.Attribute1P,
            this.Attribute2P,
            this.ProducerP,
            this.BrandP});
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(840, 253);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellEndEdit);
            // 
            // In_prod_id
            // 
            this.In_prod_id.HeaderText = "In_prod_id";
            this.In_prod_id.Name = "In_prod_id";
            this.In_prod_id.ReadOnly = true;
            this.In_prod_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.In_prod_id.Visible = false;
            // 
            // KU_idP
            // 
            this.KU_idP.HeaderText = "KU_id";
            this.KU_idP.Name = "KU_idP";
            this.KU_idP.ReadOnly = true;
            this.KU_idP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KU_idP.Visible = false;
            // 
            // TypeP
            // 
            this.TypeP.HeaderText = "Тип";
            this.TypeP.Name = "TypeP";
            this.TypeP.ReadOnly = true;
            this.TypeP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TypeP.Width = 39;
            // 
            // Attribute1P
            // 
            this.Attribute1P.HeaderText = "Атрибут 1";
            this.Attribute1P.Name = "Attribute1P";
            this.Attribute1P.ReadOnly = true;
            this.Attribute1P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Attribute1P.Width = 71;
            // 
            // Attribute2P
            // 
            this.Attribute2P.HeaderText = "Атрибут 2";
            this.Attribute2P.Name = "Attribute2P";
            this.Attribute2P.ReadOnly = true;
            this.Attribute2P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Attribute2P.Width = 71;
            // 
            // ProducerP
            // 
            this.ProducerP.HeaderText = "Производитель";
            this.ProducerP.Name = "ProducerP";
            this.ProducerP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProducerP.Width = 118;
            // 
            // BrandP
            // 
            this.BrandP.HeaderText = "Торговая марка";
            this.BrandP.Name = "BrandP";
            this.BrandP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BrandP.Width = 107;
            // 
            // tabPageToExclude
            // 
            this.tabPageToExclude.Controls.Add(this.dataGridView3);
            this.tabPageToExclude.Location = new System.Drawing.Point(4, 25);
            this.tabPageToExclude.Name = "tabPageToExclude";
            this.tabPageToExclude.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageToExclude.Size = new System.Drawing.Size(852, 262);
            this.tabPageToExclude.TabIndex = 1;
            this.tabPageToExclude.Text = "Исключить из расчёта";
            this.tabPageToExclude.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ex_prod_id,
            this.KU_idM,
            this.TypeM,
            this.Attribute1M,
            this.Attribute2M,
            this.ProducerM,
            this.BrandM});
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(840, 253);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellEndEdit);
            // 
            // Ex_prod_id
            // 
            this.Ex_prod_id.HeaderText = "Ex_prod_id";
            this.Ex_prod_id.Name = "Ex_prod_id";
            this.Ex_prod_id.ReadOnly = true;
            this.Ex_prod_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ex_prod_id.Visible = false;
            // 
            // KU_idM
            // 
            this.KU_idM.HeaderText = "KU_idM";
            this.KU_idM.Name = "KU_idM";
            this.KU_idM.ReadOnly = true;
            this.KU_idM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KU_idM.Visible = false;
            // 
            // TypeM
            // 
            this.TypeM.HeaderText = "Тип";
            this.TypeM.Name = "TypeM";
            this.TypeM.ReadOnly = true;
            this.TypeM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attribute1M
            // 
            this.Attribute1M.HeaderText = "Атрибут 1";
            this.Attribute1M.Name = "Attribute1M";
            this.Attribute1M.ReadOnly = true;
            this.Attribute1M.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attribute2M
            // 
            this.Attribute2M.HeaderText = "Атрибут 2";
            this.Attribute2M.Name = "Attribute2M";
            this.Attribute2M.ReadOnly = true;
            this.Attribute2M.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProducerM
            // 
            this.ProducerM.HeaderText = "Производитель";
            this.ProducerM.Name = "ProducerM";
            this.ProducerM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProducerM.Width = 160;
            // 
            // BrandM
            // 
            this.BrandM.HeaderText = "Торговая марка";
            this.BrandM.Name = "BrandM";
            this.BrandM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BrandM.Width = 160;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(731, 582);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(150, 26);
            this.button7.TabIndex = 25;
            this.button7.Text = "Удалить";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(177, 582);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(190, 26);
            this.button6.TabIndex = 24;
            this.button6.Text = "Добавить категорию";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnSelectCategory_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(373, 582);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 26);
            this.button5.TabIndex = 23;
            this.button5.Text = "Добавить товар";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(21, 582);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 26);
            this.button4.TabIndex = 22;
            this.button4.Text = "Добавить все";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // InputKUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(975, 622);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.status_textBox);
            this.Controls.Add(this.createNapprove_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.create_button);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "InputKUForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввести коммерческое условие";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputKUForm_FormClosing);
            this.Load += new System.EventHandler(this.InputKUForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKUForm_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageToAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPageToExclude.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button create_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поставщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Label status_label;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button createNapprove_button;
        private System.Windows.Forms.TextBox status_textBox;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageToAdd;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn In_prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn KU_idP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute1P;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute2P;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProducerP;
        private System.Windows.Forms.DataGridViewComboBoxColumn BrandP;
        private System.Windows.Forms.TabPage tabPageToExclude;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ex_prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn KU_idM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute1M;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute2M;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProducerM;
        private System.Windows.Forms.DataGridViewComboBoxColumn BrandM;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
    }
}