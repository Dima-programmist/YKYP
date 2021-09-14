using System;
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
            SqlCommand command = new SqlCommand("SELECT * FROM Vendors", _sqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (DataGridViewRow row = dataGridView1.Rows[e.RowIndex])
            {
                textBox1.Text = row.Cells["Vendor_id"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();

            }
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
