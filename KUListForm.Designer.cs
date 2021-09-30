
namespace РасчетКУ
{
    partial class KUListForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вводКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поставщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикКУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьГрафикДляВсехToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button7 = new System.Windows.Forms.Button();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.tabPageToExclude = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.BrandM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ProducerM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Attribute2M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute1M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KU_idM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ex_prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageToAdd = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BrandP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ProducerP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Attribute2P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute1P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KU_idP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.tabPageToExclude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPageToAdd.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(272, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(384, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Изменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(503, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(268, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список КУ для поставщиков";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(12, 621);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 26);
            this.button4.TabIndex = 7;
            this.button4.Text = "Добавить все";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(364, 621);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 26);
            this.button5.TabIndex = 8;
            this.button5.Text = "Добавить товар";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(168, 621);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(190, 26);
            this.button6.TabIndex = 9;
            this.button6.Text = "Добавить категорию";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnSelectCategory_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 29);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вводКУToolStripMenuItem,
            this.поставщикиToolStripMenuItem,
            this.графикКУToolStripMenuItem,
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
            this.создатьГрафикToolStripMenuItem,
            this.создатьГрафикДляВсехToolStripMenuItem,
            this.показатьГрафикToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // создатьГрафикToolStripMenuItem
            // 
            this.создатьГрафикToolStripMenuItem.Name = "создатьГрафикToolStripMenuItem";
            this.создатьГрафикToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.создатьГрафикToolStripMenuItem.Text = "Создать график для выбранного КУ";
            this.создатьГрафикToolStripMenuItem.Click += new System.EventHandler(this.создатьГрафикToolStripMenuItem_Click);
            // 
            // создатьГрафикДляВсехToolStripMenuItem
            // 
            this.создатьГрафикДляВсехToolStripMenuItem.Name = "создатьГрафикДляВсехToolStripMenuItem";
            this.создатьГрафикДляВсехToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.создатьГрафикДляВсехToolStripMenuItem.Text = "Создать график для всех КУ";
            this.создатьГрафикДляВсехToolStripMenuItem.Click += new System.EventHandler(this.создатьГрафикДляВсехToolStripMenuItem_Click);
            // 
            // показатьГрафикToolStripMenuItem
            // 
            this.показатьГрафикToolStripMenuItem.Name = "показатьГрафикToolStripMenuItem";
            this.показатьГрафикToolStripMenuItem.Size = new System.Drawing.Size(335, 26);
            this.показатьГрафикToolStripMenuItem.Text = "Показать график";
            this.показатьГрафикToolStripMenuItem.Click += new System.EventHandler(this.показатьГрафикToolStripMenuItem_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(722, 621);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(150, 26);
            this.button7.TabIndex = 11;
            this.button7.Text = "Удалить";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.AllowUserToResizeRows = false;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.DateWithTime = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advancedDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.advancedDataGridView1.Location = new System.Drawing.Point(16, 80);
            this.advancedDataGridView1.MultiSelect = false;
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RowHeadersVisible = false;
            this.advancedDataGridView1.Size = new System.Drawing.Size(852, 203);
            this.advancedDataGridView1.TabIndex = 12;
            this.advancedDataGridView1.TimeFilter = false;
            this.advancedDataGridView1.SortStringChanged += new System.EventHandler(this.advancedDataGridView1_SortStringChanged);
            this.advancedDataGridView1.FilterStringChanged += new System.EventHandler(this.advancedDataGridView1_FilterStringChanged);
            this.advancedDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellClick);
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
            this.dataGridView3.Location = new System.Drawing.Point(6, 6);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(840, 253);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // BrandM
            // 
            this.BrandM.HeaderText = "Торговая марка";
            this.BrandM.Name = "BrandM";
            this.BrandM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BrandM.Width = 160;
            // 
            // ProducerM
            // 
            this.ProducerM.HeaderText = "Производитель";
            this.ProducerM.Name = "ProducerM";
            this.ProducerM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProducerM.Width = 160;
            // 
            // Attribute2M
            // 
            this.Attribute2M.HeaderText = "Атрибут 2";
            this.Attribute2M.Name = "Attribute2M";
            this.Attribute2M.ReadOnly = true;
            this.Attribute2M.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attribute1M
            // 
            this.Attribute1M.HeaderText = "Атрибут 1";
            this.Attribute1M.Name = "Attribute1M";
            this.Attribute1M.ReadOnly = true;
            this.Attribute1M.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TypeM
            // 
            this.TypeM.HeaderText = "Тип";
            this.TypeM.Name = "TypeM";
            this.TypeM.ReadOnly = true;
            this.TypeM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // KU_idM
            // 
            this.KU_idM.HeaderText = "KU_idM";
            this.KU_idM.Name = "KU_idM";
            this.KU_idM.ReadOnly = true;
            this.KU_idM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KU_idM.Visible = false;
            // 
            // Ex_prod_id
            // 
            this.Ex_prod_id.HeaderText = "Ex_prod_id";
            this.Ex_prod_id.Name = "Ex_prod_id";
            this.Ex_prod_id.ReadOnly = true;
            this.Ex_prod_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ex_prod_id.Visible = false;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageToAdd);
            this.tabControl1.Controls.Add(this.tabPageToExclude);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 324);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(860, 291);
            this.tabControl1.TabIndex = 5;
            // 
            // BrandP
            // 
            this.BrandP.HeaderText = "Торговая марка";
            this.BrandP.Name = "BrandP";
            this.BrandP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BrandP.Width = 160;
            // 
            // ProducerP
            // 
            this.ProducerP.HeaderText = "Производитель";
            this.ProducerP.Name = "ProducerP";
            this.ProducerP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProducerP.Width = 160;
            // 
            // Attribute2P
            // 
            this.Attribute2P.HeaderText = "Атрибут 2";
            this.Attribute2P.Name = "Attribute2P";
            this.Attribute2P.ReadOnly = true;
            this.Attribute2P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attribute1P
            // 
            this.Attribute1P.HeaderText = "Атрибут 1";
            this.Attribute1P.Name = "Attribute1P";
            this.Attribute1P.ReadOnly = true;
            this.Attribute1P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TypeP
            // 
            this.TypeP.HeaderText = "Тип";
            this.TypeP.Name = "TypeP";
            this.TypeP.ReadOnly = true;
            this.TypeP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // KU_idP
            // 
            this.KU_idP.HeaderText = "KU_id";
            this.KU_idP.Name = "KU_idP";
            this.KU_idP.ReadOnly = true;
            this.KU_idP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KU_idP.Visible = false;
            // 
            // In_prod_id
            // 
            this.In_prod_id.HeaderText = "In_prod_id";
            this.In_prod_id.Name = "In_prod_id";
            this.In_prod_id.ReadOnly = true;
            this.In_prod_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.In_prod_id.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In_prod_id,
            this.KU_idP,
            this.TypeP,
            this.Attribute1P,
            this.Attribute2P,
            this.ProducerP,
            this.BrandP});
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(840, 253);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // KUListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(238)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(884, 657);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KUListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список КУ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KUListForm_FormClosing);
            this.Load += new System.EventHandler(this.KUListForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KUListForm_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.tabPageToExclude.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPageToAdd.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вводКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поставщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикКУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьГрафикToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьГрафикДляВсехToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьГрафикToolStripMenuItem;
        private System.Windows.Forms.Button button7;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.TabPage tabPageToExclude;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ex_prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn KU_idM;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute1M;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute2M;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProducerM;
        private System.Windows.Forms.DataGridViewComboBoxColumn BrandM;
        private System.Windows.Forms.TabPage tabPageToAdd;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn In_prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn KU_idP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute1P;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute2P;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProducerP;
        private System.Windows.Forms.DataGridViewComboBoxColumn BrandP;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
