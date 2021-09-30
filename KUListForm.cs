using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace РасчетКУ
{
    public partial class KUListForm : Form
    {
        private SqlConnection _sqlConnection;
        private List<Int64> ProdIds = new List<Int64>();
        private List<string> CategoryID = new List<string>();
        public KUListForm()
        {
            InitializeComponent();
        }

        // Подключение к БД
        private void KUListForm_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            _sqlConnection.Open();

            showKUList();
            if (advancedDataGridView1.RowCount > 0)
            {
                showExInProducts(Convert.ToInt64(advancedDataGridView1.Rows[0].Cells["KU_id"].Value));
                showProducerBrand(Convert.ToInt64(advancedDataGridView1.Rows[0].Cells["Vendor_id"].Value));
            }

        }

        // Добавление КУ
        private void button1_Click(object sender, EventArgs e)
        {
            Form FormInputKU = new InputKUForm();

            FormInputKU.ShowDialog();

            if(FormInputKU.DialogResult == DialogResult.OK || FormInputKU.DialogResult == DialogResult.Cancel)
                showKUList();
        }

        // Изменение выбранного КУ
        private void button2_Click(object sender, EventArgs e)
        {
            Form FormInputKu = new InputKUForm(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value), Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value));
            FormInputKu.ShowDialog();

            if(FormInputKu.DialogResult == DialogResult.OK)
                showKUList();
        }

        // Удаление выбранного КУ
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            DataGridViewRow row = advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index];

            result = MessageBox.Show("Вы уверены, что хотите удалить информацию о коммерческих условиях с поставщиком " + row.Cells["Name"].Value.ToString() + " ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Удаление привязанных к КУ значений в других таблицах
            SqlCommand command = new SqlCommand($"DELETE FROM Included_products WHERE KU_id = {row.Cells["KU_id"].Value}", _sqlConnection);
            command.ExecuteNonQuery();
            command = new SqlCommand($"DELETE FROM Excluded_products WHERE KU_id = {row.Cells["KU_id"].Value}", _sqlConnection);
            command.ExecuteNonQuery();

            // Удаление самого КУ
            command = new SqlCommand("DELETE FROM KU WHERE KU_id = " + row.Cells["KU_id"].Value.ToString(), _sqlConnection);
            command.ExecuteNonQuery();

            showKUList();
            if (advancedDataGridView1.RowCount > 0)
            {
                showProducerBrand(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value));
                showExInProducts(Convert.ToInt64(advancedDataGridView1.Rows[0].Cells["KU_id"].Value));
            }
                
        }

        // Выбор определенного КУ
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (advancedDataGridView1.RowCount > 0)
            {
                showExInProducts(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value));
                showProducerBrand(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value));
            }

        }

        //Фильтр товаров
        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView1.DataSource as DataTable).DefaultView.RowFilter = advancedDataGridView1.FilterString;

        }

        // Сортировка товаров
        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            (advancedDataGridView1.DataSource as DataTable).DefaultView.Sort = advancedDataGridView1.SortString;

        }

        //Отображение производителя и марки в combobox в таблицах искл и вкл товаров
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

        // Кнопка "Добавить все"
        private void button4_Click(object sender, EventArgs e)
        {
            addLine("Все");
        }

        //Открытие формы выбора категории
        private void btnSelectCategory_Click(object sender, EventArgs e)
        {
            CategoryID.Clear();

            Form selectCategoryForm = new SelectCategoryForm(ref CategoryID);
            selectCategoryForm.ShowDialog();

            if (selectCategoryForm.DialogResult == DialogResult.OK)
                addLine("Категория");
            
        }

        // Открытие формы выбора продуктов
        private void button5_Click(object sender, EventArgs e)
        {
            int selectedKUId = Convert.ToInt32(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells[1].Value);
            ProdIds.Clear();

            // Сбор уже имеющихся ид выбранных товаров
            /*DataGridView dgv;
            string name, name2;
            if (tabControl1.SelectedIndex == 0)
            {
                dgv = dataGridView2;
                name = "TypeP";
                name2 = "Attribute1P";
            }
            else
            {
                dgv = dataGridView3;
                name = "TypeM";
                name2 = "Attribute1M";
            }
                
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if(dgv.Rows[i].Cells[name].Value.ToString() == "Товары")
                {
                    ProdIds.Add(Convert.ToInt64(dgv.Rows[i].Cells[name2].Value));
                }
            }*/

            Form SelectForm = new SelectProductForm(selectedKUId, ref ProdIds);
            SelectForm.ShowDialog();

            // Добавление строк с товарами 
            if(SelectForm.DialogResult == DialogResult.OK)
                addLine("Товары");
        }

        // Кнопка удаления из таблиц включенных и исключенных товаров
        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result;
            SqlCommand command;
            if(tabControl1.SelectedIndex == 0)
            {
                if (dataGridView2.RowCount < 1)
                {
                    MessageBox.Show("Нечего удалять", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                result = MessageBox.Show($"Вы уверены, что хотите удалить условие '{dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["TypeP"].Value}' ?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                command = new SqlCommand($"DELETE FROM Included_products WHERE In_prod_id = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["In_prod_id"].Value}", _sqlConnection);
            }
            else
            {
                if (dataGridView3.RowCount < 1)
                {
                    MessageBox.Show("Нечего удалять", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                result = MessageBox.Show($"Вы уверены, что хотите удалить условие '{dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells["TypeM"].Value}' ?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                command = new SqlCommand($"DELETE FROM Excluded_products WHERE Ex_prod_id = {dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells["Ex_prod_id"].Value}", _sqlConnection);
            }
            command.ExecuteNonQuery();
            showExInProducts(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value));
        }

        // Вывод списка КУ
        private void showKUList()
        {
            SqlCommand command = new SqlCommand("SELECT KU.KU_id, Vendors.Vendor_id, Vendors.Name, KU.[Percent], KU.Date_from, KU.Date_to, KU.Period, Status FROM KU, Vendors WHERE KU.Vendor_id = Vendors.Vendor_id", _sqlConnection);

            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(dt);
            // Изменение данных о процентах для правильного отображения
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][3] = Convert.ToDouble(dt.Rows[i][3]) / 10;
            }
            advancedDataGridView1.DataSource = dt;
            advancedDataGridView1.Columns["Vendor_id"].Visible = false;
        }

        // Добавление строк в таблицы включения и исключения
        private void addLine(string type)
        {
            Int64 KU_id = Convert.ToInt64(advancedDataGridView1.CurrentRow.Cells["KU_id"].Value);
            Int16 tabPageId = Convert.ToInt16(tabControl1.SelectedIndex);
            SqlCommand command;
            switch (type)
            {
                case "Все":
                    if (tabPageId == 0)
                    {
                        for(int i = 0; i < dataGridView2.RowCount; i++)
                        { 
                            if (dataGridView2.Rows[i].Cells["TypeP"].Value.ToString() == "Все")
                            {
                                MessageBox.Show("Данное условие уже добавлено!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type) VALUES ({KU_id}, '{type}')", _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        DialogResult result = DialogResult.Yes;
                        // Проверка, есть ли условие "все" в условиях на добавление
                        for(int i = 0; i < dataGridView2.RowCount; i++)
                        {
                            if (dataGridView2.Rows[i].Cells["TypeP"].Value.ToString() == "Все" && dataGridView2.Rows[i].Cells["ProducerP"].Value.ToString() == "" && dataGridView2.Rows[i].Cells["BrandP"].Value.ToString() == "")
                                result = MessageBox.Show("В условиях на добавление есть условие 'Все', если добавить условие 'Все' для исключения, ни один товар не будет выбран.\nВы уверены, что хотите добавить это условие?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        }
                        if(result == DialogResult.Yes)
                        {
                            for (int i = 0; i < dataGridView3.RowCount; i++)
                            {
                                if (dataGridView3.Rows[i].Cells["TypeM"].Value.ToString() == "Все")
                                {
                                    MessageBox.Show("Данное условие уже добавлено!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            command = new SqlCommand($"INSERT INTO Excluded_products (KU_id, Type) VALUES ({KU_id}, '{type}')", _sqlConnection);
                            command.ExecuteNonQuery();
                        }
                    }

                    break;
                case "Категория":
                    if (tabPageId == 0)
                    {
                        command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{KU_id}, '{type}', '{CategoryID[0]}', '{findNameById(CategoryID[0])}')", _sqlConnection);
                    }
                    else
                    {
                        command = new SqlCommand($"INSERT INTO Excluded_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                            $"{KU_id}, '{type}', '{CategoryID[0]}', '{findNameById(CategoryID[0])}')", _sqlConnection);
                    }
                    command.ExecuteNonQuery();

                    break;
                case "Товары":
                    for (int i = 0; i < ProdIds.Count; i++)
                    {
                        if (tabPageId == 0)
                        {
                            command = new SqlCommand($"INSERT INTO Included_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                                $"{KU_id}, '{type}', '{ProdIds[i]}', (SELECT Name FROM Products WHERE Product_id = {ProdIds[i]}))", _sqlConnection);
                        }
                        else
                        {
                            command = new SqlCommand($"INSERT INTO Excluded_products (KU_id, Type, Attribute_1, Attribute_2) VALUES (" +
                                $"{KU_id}, '{type}', '{ProdIds[i]}', (SELECT Name FROM Products WHERE Product_id = {ProdIds[i]}))", _sqlConnection);
                        }
                        command.ExecuteNonQuery();
                    }

                    break;
            }
            showExInProducts(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value));
        }

        // Поиск названия категории
        private string findNameById(string id)
        {
            SqlCommand command = new SqlCommand($"SELECT * FROM Classifier WHERE L1 = '{id}' OR L2 = '{id}' OR L3 = '{id}' OR L4 = '{id}'", _sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            for(int i = 0; i <= 6; i+=2)
            {
                if(dt.Rows[0][i].ToString() == id)
                {
                    return dt.Rows[0][i + 1].ToString();
                }
            }

            return "NULL";
        }

        //ПЕРЕНЕСТИ НИЖНИЕ ДВЕ Ф-ИИ 
        // Запись значений из комбобоксов в БД
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv;
            DataGridViewComboBoxCell combo1, combo2;
            string table = "", column = "";

            if(tabControl1.SelectedIndex == 0)
            {
                dgv = dataGridView2;
                combo1 = dgv.Rows[dgv.CurrentRow.Index].Cells["ProducerP"] as DataGridViewComboBoxCell;
                combo2 = dgv.Rows[dgv.CurrentRow.Index].Cells["BrandP"] as DataGridViewComboBoxCell;
                table = "Included_products";
                column = "In_prod_id";
            }
            else
            {
                dgv = dataGridView3;
                combo1 = dgv.Rows[dgv.CurrentRow.Index].Cells["ProducerM"] as DataGridViewComboBoxCell;
                combo2 = dgv.Rows[dgv.CurrentRow.Index].Cells["BrandM"] as DataGridViewComboBoxCell;
                table = "Excluded_products";
                column = "Ex_prod_id";
            }

            SqlCommand command = new SqlCommand($"UPDATE {table} SET Producer = '{combo1.Value}', Brand_name = '{combo2.Value}' WHERE " +
                $"{column} = {dgv.Rows[dgv.CurrentRow.Index].Cells[column].Value}", _sqlConnection);
            command.ExecuteNonQuery();
        }

        // Удаление данных из комбобоксов в таблицах
        private void KUListForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridView dgv;
            SqlCommand command;
            string table, column;

            // Отслеживание нажатия на delete и backspace
            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    dgv = dataGridView2;
                    table = "Included_products";
                    column = "In_prod_id";
                }
                else
                {
                    dgv = dataGridView3;
                    table = "Excluded_products";
                    column = "Ex_prod_id";
                }
                
                if (dgv.Focused)
                {
                    if (dgv.RowCount > 0 && dgv.CurrentCell.ColumnIndex > dgv.ColumnCount - 3)
                    {
                        (dgv.Rows[dgv.CurrentRow.Index].Cells[dgv.CurrentCell.ColumnIndex] as DataGridViewComboBoxCell).Value = "";

                        // Добавить удаление из БД
                        if(dgv.CurrentCell.ColumnIndex == dgv.ColumnCount - 2)
                        {
                            command = new SqlCommand($"UPDATE {table} SET Producer = NULL WHERE {column} = {dgv.Rows[dgv.CurrentRow.Index].Cells[column].Value}", _sqlConnection);
                            command.ExecuteNonQuery();
                        }
                        else if(dgv.CurrentCell.ColumnIndex == dgv.ColumnCount - 1)
                        {
                            command = new SqlCommand($"UPDATE {table} SET Brand_name = NULL WHERE {column} = {dgv.Rows[dgv.CurrentRow.Index].Cells[column].Value}", _sqlConnection);
                            command.ExecuteNonQuery();
                        }
                        
                    }
                        
                }
            }
        }
        

        //
        // МЕНЮ
        //
        // Открытие формы ввода коммерческих условий
        private void вводКУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormInputKU = new InputKUForm();

            FormInputKU.Show();
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

        // Кнопка меню для создания графика по выбранной КУ
        private void создатьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверка статуса выбранного КУ
            if(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["Status"].Value.ToString() != "Утверждено")
            {
                MessageBox.Show("КУ должно быть утверждено, чтобы создать по нему график!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Actions actions = new Actions();
            if(actions.addGraphToCurrentKU(Convert.ToInt64(advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value)) == true)
                MessageBox.Show($"Для КУ с номером: {advancedDataGridView1.Rows[advancedDataGridView1.CurrentRow.Index].Cells["KU_id"].Value} успешно создан график.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Кнопка меню для создания графика по всем КУ
        private void создатьГрафикДляВсехToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions actions = new Actions();
            if(actions.addGraphs() == true)
                MessageBox.Show("Графики созданы для всех утвержденных КУ.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Открытие формы графика
        private void показатьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form GraphForm = new KUGraphForm();
            GraphForm.Show();
        }


        // Закрытие соединения с БД при закрытии
        private void KUListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sqlConnection.Close();
        }

        
    }
}
