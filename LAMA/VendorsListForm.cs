﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace РасчетКУ
{
    public partial class VendorsListForm : Form
    {
        private SqlConnection _sqlConnection;
        private Global_parameters gp = new Global_parameters();
        public VendorsListForm()
        {
            InitializeComponent();
        }

        // Ооткрытие соединения с БД
        private void VendorsListForm_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(gp.getString());
            _sqlConnection.Open();

            showVendorsList();
        }

        private void VendorsListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO [Vendors] (Name) VALUES (N'{textBox2.Text}')", _sqlConnection);
            command.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();

            showVendorsList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE Vendors SET Name = '" + textBox2.Text+ "'WHERE Vendor_id = '" + textBox1.Text+"'", _sqlConnection);
            command.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();

            showVendorsList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Vendors WHERE Vendor_id = '" + textBox1.Text + "' AND Name = '" + textBox2.Text + "'", _sqlConnection);
            command.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();

            showVendorsList();
        }

        // Вывод списка поставщиков
        private void showVendorsList()
        {
            SqlCommand command = new SqlCommand("SELECT Vendor_id, Name As 'Поставщик', (SELECT Name FROM Entities Where Entities.Entity_id = Vendors.Entity_id)" +
                " As 'Юридическое лицо' FROM Vendors", _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(dt);
            advancedDataGridView1.DataSource = dt;
            advancedDataGridView1.Columns["Vendor_id"].Visible = false;
        }

        
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index];
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
        }

        // Открытие формы ввода коммерческих условий
        private void вводКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormInputKU = new InputKUForm();

            FormInputKU.Show();
        }

        //Открытие формы списка КУ с помощью кнопки на верхней панели
        private void списокКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormKUList = new KUListForm();

            FormKUList.Show();

        }

        //Открытие графика КУ с помощью кнопки на верхней панели
        private void графикКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormKUGraph = new KUGraphForm();

            FormKUGraph.Show();
        }


    }
}
