using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace РасчетКУ
{
    public partial class InputKUForm : Form
    {
        private SqlConnection _sqlConnection;
        private bool _showKU = false, _approved = false;
        private Int64 _KU_id;
        private Global_parameters gp = new Global_parameters();

        public InputKUForm()
        {
            InitializeComponent();
        }
        // Конструктор для изменения выбранного КУ в форме списка КУ
        public InputKUForm(Int64 KUId)
        {
            InitializeComponent();
            _KU_id = KUId;
            _showKU = true;

            create_button.Text = "Изменить";
            createNapprove_button.Text = "Изменить и утвердить";
            comboBox1.Enabled = false;
            status_textBox.Visible = true;
            status_label.Visible = true;
            cancel_button.Visible = true;
        }

        // Подключение к БД при открытии формы
        private void InputKUForm_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(gp.getString());

            _sqlConnection.Open();

            //Загрузка данных о поставщиках в комбобокс
            SqlCommand command = new SqlCommand("SELECT Name FROM Vendors", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            
            while(reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
            reader.Close();

            // Настройка дат
            dateTimePicker2.MinDate = DateTime.Today.AddDays(1);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.CustomFormat = " ";

            if (_showKU)
                showSelectedKU();
        }

        // Отображение КУ, выбранного из формы списка КУ
        private void showSelectedKU()
        {
            SqlCommand command = new SqlCommand($"SELECT Vendors.Name, [Percent], Period, Date_from, Date_to, Status FROM KU, Vendors WHERE KU.Vendor_id = Vendors.Vendor_id AND KU_id = {_KU_id}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            comboBox1.SelectedItem = reader[0].ToString();
            textBox1.Text = (Convert.ToDouble(reader[1]) / 10).ToString();
            comboBox2.SelectedItem = reader[2].ToString();
            dateTimePicker1.Format = DateTimePickerFormat.Long;
            dateTimePicker2.Format = DateTimePickerFormat.Long;
            dateTimePicker1.Value = Convert.ToDateTime(reader[3]);
            dateTimePicker2.Value = Convert.ToDateTime(reader[4]);
            status_textBox.Text = reader[5].ToString();
            reader.Close();

            if (status_textBox.Text == "Утверждено")
                _approved = true;

            // Если КУ в статусе "Утверждено"
            if (_approved)
            {
                create_button.Visible = false;
                createNapprove_button.Visible = false;
                close_button.Visible = true;
                comboBox1.Enabled = false;
                textBox1.Enabled = false;
                comboBox2.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                status_textBox.Enabled = false;
            }
            showExInProducts(_KU_id);
        }

        // Добавление или изменение данных о КУ
        private void create_button_Click(object sender, EventArgs e)
        {
            nullCheck();

            // Добавление или изменение информаци о коммерческих условиях
            if (create_button.Text == "Создать")
            {
                addKU("Создано");
            }
            else
            {
                updateKU("Создано");
            }
        }

        // Нажатие на кнопку создания(изменения) и утверждения
        private void createNapprove_button_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show($"Вы уверены, что хотите {createNapprove_button.Text} выбранное коммерческое условие?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                nullCheck();

                if (createNapprove_button.Text == "Создать и утвердить")
                {
                    // Создание и утверждение
                    addKU("Утверждено");
                }
                else
                {
                    // Изменение и утверждение
                    updateKU("Утверждено");
                }
            }
        }

        // Нажатие на кнопку закрытия КУ
        private void close_button_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы уверены, что хотите изменить статус КУ на 'Закрыто' ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand($"UPDATE KU SET Status = 'Закрыто' WHERE KU_id = {_KU_id}", _sqlConnection);
                command.ExecuteNonQuery();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Нажатие на кнопку отмены при изменении КУ
        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Проверка на пустые поля при нажатии на кнопки
        private void nullCheck()
        {
            // Проверка, выбран ли поставщик + введены ли данные
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Поставщик не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ((textBox1.Text == "") || (comboBox2.SelectedIndex == -1))
            {
                MessageBox.Show("Введите данные!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //
            // Добавить проверку на пустые datetimepicker'ы
            //
        }

        // Добавление КУ в БД
        private void addKU(string status)
        {
            // Проверка на неповторность временного периода
            List<DateTime> dateFrom = new List<DateTime>(), dateTo = new List<DateTime>();
            DateTime currDateFrom = dateTimePicker1.Value, currDateTo = dateTimePicker2.Value;

            SqlCommand command = new SqlCommand($"SELECT Date_from, Date_to FROM KU WHERE Vendor_id = " +
                $"(SELECT Vendor_id FROM Vendors WHERE Name = '{comboBox1.SelectedItem}')", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dateFrom.Add(Convert.ToDateTime(reader[0]));
                dateTo.Add(Convert.ToDateTime(reader[1]));
            }
            reader.Close();

            // цикл с проверкой
            for (int i = 0; i < dateFrom.Count; i++)
            {
                if (dateFrom[i] < currDateTo && currDateFrom < dateTo[i])
                {
                    MessageBox.Show($"В базе данных уже содержится информация о коммерческих условиях поставщика '{comboBox1.SelectedItem}' в обозначенный период с " +
                        $"{currDateFrom.ToShortDateString()} по {currDateTo.ToShortDateString()}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Создание КУ
            command = new SqlCommand(
           $"INSERT INTO KU (Vendor_id, [Percent], Period, Date_from, Date_to, Status) VALUES ((SELECT Vendor_id FROM Vendors WHERE Name = '{comboBox1.SelectedItem}'), " +
           $"'{(int)(Convert.ToDouble(textBox1.Text) * 10)}', '{comboBox2.SelectedItem}', '{dateTimePicker1.Value.ToShortDateString()}', '{dateTimePicker2.Value.ToShortDateString()}', '{status}')", _sqlConnection);
            command.ExecuteNonQuery();

            // Создание условия "Все" для включенных товаров по выбранной КУ
            command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type) VALUES ((SELECT KU_id FROM KU WHERE Vendor_id = (SELECT Vendor_id FROM Vendors WHERE Name = " +
                $"'{comboBox1.SelectedItem}' AND Date_from = '{dateTimePicker1.Value.ToShortDateString()}')), 'Все')", _sqlConnection);
            command.ExecuteNonQuery();

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Text = "";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }

        // Измменение КУ в БД
        private void updateKU(string status)
        {
            // Проверка на неповторность временного периода
            List<DateTime> dateFrom = new List<DateTime>(), dateTo = new List<DateTime>();
            DateTime currDateFrom = dateTimePicker1.Value, currDateTo = dateTimePicker2.Value;

            SqlCommand command = new SqlCommand($"SELECT Date_from, Date_to FROM KU WHERE Vendor_id = " +
                $"(SELECT Vendor_id FROM Vendors WHERE Name = '{comboBox1.SelectedItem}') AND KU_id != {_KU_id}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dateFrom.Add(Convert.ToDateTime(reader[0]));
                dateTo.Add(Convert.ToDateTime(reader[1]));
            }
            reader.Close();

            // цикл с проверкой
            for (int i = 0; i < dateFrom.Count; i++)
            {
                if (dateFrom[i] < currDateTo && currDateFrom < dateTo[i])
                {
                    MessageBox.Show($"В базе данных уже содержится информация о коммерческих условиях поставщика '{comboBox1.SelectedItem}' в обозначенный период с " +
                        $"{currDateFrom.ToShortDateString()} по {currDateTo.ToShortDateString()}", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            command = new SqlCommand(
                    $"UPDATE KU SET [Percent] = '{(int)(Convert.ToDouble(textBox1.Text) * 10)}', Period = '{comboBox2.SelectedItem}', " +
                    $"Date_from = '{dateTimePicker1.Value.ToShortDateString()}', Date_to = '{dateTimePicker2.Value.ToShortDateString()}', Status = '{status}'" +
                    $" WHERE KU_id = {_KU_id}", _sqlConnection);
            command.ExecuteNonQuery();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }




        // Изменение минимальной даты окончания, в зависимости от выбранной даты начала
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }
        // Изменение значения 2 календаря
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Long;
        }

        // Ограничение ввода процента
        private void textBox_KeyPress_only_float_numbers(object sender, KeyPressEventArgs e) // Ограничение на ввод только дробных чисел
        {
            char number = e.KeyChar;
            
            if (!Char.IsDigit(number) && number != 8 && number != 44) //разрешение ввода чисел, запятой и backspace
            {
                e.Handled = true;
            }
        }




        // КНОПКИ МЕНЮ
        //
        //Открытие формы списка КУ с помощью кнопки на верхней панели
        private void списокКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormKUList = new KUListForm();

            FormKUList.Show();

        }

        //Открытие формы списка поставщиков с помощью кнопки на верхней панели
        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormVendorsList = new VendorsListForm();

            FormVendorsList.Show();
        }

        //Открытие графика КУ с помощью кнопки на верхней панели
        private void графикКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormKUGraph = new KUGraphForm();

            FormKUGraph.Show();
        }

        //Отображение производителя и марки в combobox в таблицах искл и вкл товаров
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex > -1)
            {
               
                //SqlCommand command = new SqlCommand($"SELECT Vendor_id FROM Vendors WHERE Vendors.Name = '{comboBox1.SelectedItem}'", _sqlConnection);

               // DataTable dt = new DataTable();
               // SqlDataAdapter adapt = new SqlDataAdapter(command);
                //adapt.SelectCommand = command;
              //  adapt.Fill(dt);
                //showProducerBrand(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value));
                //showExInProducts(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value));

                //showProducerBrand(Convert.ToInt64(dt.Rows[0][0]));
                //showExInProducts(Convert.ToInt64()
            }

        }

        //Включение производителя и марки в combobox в таблицах искл и вкл товаров
        private void showProducerBrand(Int64 VendorId)
        {
            DataGridViewComboBoxColumn combo1 = dataGridView2.Columns["ProducerP"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn combo2 = dataGridView2.Columns["BrandP"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn combo3 = dataGridView3.Columns["ProducerM"] as DataGridViewComboBoxColumn;
            DataGridViewComboBoxColumn combo4 = dataGridView3.Columns["BrandM"] as DataGridViewComboBoxColumn;
            combo1.Items.Clear();
            combo2.Items.Clear();
            combo3.Items.Clear();
            combo4.Items.Clear();

            SqlCommand command = new SqlCommand($"SELECT DISTINCT Producer, Brand_name FROM Products, Assortment Where Products.Product_id = Assortment.Product_id AND Vendor_id = {VendorId} ", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                combo1.Items.Add(reader[0]);
                combo2.Items.Add(reader[1]);
                combo3.Items.Add(reader[0]);
                combo4.Items.Add(reader[1]);

            }
            reader.Close();
        }

        // Отображение добавленных и исключенных из расчета продуктов
        private void showExInProducts(Int64 KUId)
        {
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            SqlCommand command = new SqlCommand($"SELECT * FROM Included_products WHERE KU_id = {KUId}", _sqlConnection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[0].Value = reader[0];
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[1].Value = reader[1];
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[2].Value = reader[2];
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[3].Value = reader[3];
                dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[4].Value = reader[4];
                (dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[5] as DataGridViewComboBoxCell).Value = reader[5].ToString();
                (dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[6] as DataGridViewComboBoxCell).Value = reader[6].ToString();

                // Запрет выбора произв и торг марки для товаров
                if (dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[2].Value.ToString() == "Товары")
                {
                    dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[5].ReadOnly = true;
                    dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[6].ReadOnly = true;
                }
            }
            reader.Close();

            command = new SqlCommand($"SELECT * FROM Excluded_products WHERE KU_id = {KUId}", _sqlConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[0].Value = reader[0];
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[1].Value = reader[1];
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[2].Value = reader[2];
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[3].Value = reader[3];
                dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[4].Value = reader[4];
                (dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[5] as DataGridViewComboBoxCell).Value = reader[5].ToString();
                (dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[6] as DataGridViewComboBoxCell).Value = reader[6].ToString();

                // Запрет выбора произв и торг марки для товаров
                if (dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[2].Value.ToString() == "Товары")
                {
                    dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[5].ReadOnly = true;
                    dataGridView3.Rows[dataGridView3.RowCount - 1].Cells[6].ReadOnly = true;
                }
            }
            reader.Close();
        }


        // Закрытие подключения к БД
        private void InputKUForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
        }

        
    }
}
