using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace РасчетКУ
{
    class Actions
    {
        private SqlConnection _sqlConnection;
        
        // Создание графиков для всех КУ
        public bool addGraphs()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            _sqlConnection.Open();
            bool isAdded = false;

            // Получения списка КУ, для которых можно расчитать график
            DataTable KU_list = new DataTable();
            SqlCommand command = new SqlCommand("SELECT KU_id FROM KU WHERE Status = 'Утверждено'", _sqlConnection);
            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(KU_list);
            _sqlConnection.Close();

            // Вызов метода расчета для каждого КУ
            for (int i = 0; i < KU_list.Rows.Count; i++)
            {
                isAdded = addGraphToCurrentKU(Convert.ToInt64(KU_list.Rows[i][0]));
            }
            return isAdded;
        }

        // Создание графика для определенного КУ
        public bool addGraphToCurrentKU(Int64 KU_id)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            _sqlConnection.Open();

            // Загрузка переменной сдвига дат
            Global_parameters gb = new Global_parameters();
            int sdvig = Convert.ToInt32(gb.getParameter("delta"));
            //MessageBox.Show($"kol-vo dney:  {sdvig}");

            // Проверка, создан ли график для выбранного КУ
            SqlCommand command = new SqlCommand($"SELECT * FROM KU_graph WHERE KU_id = {KU_id}", _sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                DialogResult result;
                result = MessageBox.Show($"Для КУ с номером {KU_id} уже создан график, пересоздать?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    reader.Close();
                    command = new SqlCommand($"UPDATE KU_graph SET Sum_calc = NULL, Sum_bonus = NULL, Sum_accept = NULL WHERE KU_id = {KU_id}", _sqlConnection);
                    command.ExecuteNonQuery();

                    command = new SqlCommand($"SELECT Graph_id FROM KU_graph WHERE KU_id = {KU_id}", _sqlConnection);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapt = new SqlDataAdapter(command);
                    adapt.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        command = new SqlCommand($"DELETE FROM Included_products_list WHERE Graph_id = {dt.Rows[i][0]}", _sqlConnection);
                        command.ExecuteNonQuery();
                        command = new SqlCommand($"DELETE FROM Excluded_products_list WHERE Graph_id = {dt.Rows[i][0]}", _sqlConnection);
                        command.ExecuteNonQuery();
                    }
                    command = new SqlCommand($"DELETE FROM KU_graph WHERE KU_id = {KU_id}", _sqlConnection);
                    command.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            if(!reader.IsClosed)
                reader.Close();
            // Запрос на выборку конкретного КУ
            DataTable KU_table = new DataTable(), graph_table = new DataTable();
            command = new SqlCommand($"SELECT * FROM KU WHERE KU_id = {KU_id} AND Status = 'Утверждено'", _sqlConnection);
            SqlDataAdapter adt = new SqlDataAdapter(command);
            adt.Fill(KU_table);

            //int j = 0;
            DateTime dateFrom, dateTo;

            // Настройка таблицы графика в коде
            graph_table.Columns.Add("KU_id", typeof(Int64));
            graph_table.Columns.Add("Vendor_id", typeof(Int64));
            graph_table.Columns.Add("KU_percent", typeof(int));
            graph_table.Columns.Add("Period", typeof(string));
            graph_table.Columns.Add("Date_from", typeof(DateTime));
            graph_table.Columns.Add("Date_to", typeof(DateTime));
            graph_table.Columns.Add("Date_calc", typeof(DateTime));
            graph_table.Columns.Add("Status", typeof(string));
            graph_table.Rows.Add();

            // Цикл по строкам КУ
            for (int i = 0; i < KU_table.Rows.Count; i++)
            {
                dateFrom = Convert.ToDateTime(KU_table.Rows[i][4]);
                dateTo = dateFrom;
                while (dateFrom < Convert.ToDateTime(KU_table.Rows[i][5]))
                {
                    graph_table.Rows[0][0] = KU_table.Rows[i][0];
                    graph_table.Rows[0][1] = KU_table.Rows[i][1];
                    graph_table.Rows[0][2] = KU_table.Rows[i][2];
                    graph_table.Rows[0][3] = KU_table.Rows[i][3];
                    graph_table.Rows[0][4] = dateFrom.ToShortDateString();
                    graph_table.Rows[0][7] = "Создан";

                    // Прибавление, в зависимости от периода
                    switch (KU_table.Rows[i][3].ToString())
                    {
                        case "Год":
                            dateTo = dateFrom.AddYears(1).AddDays(-dateFrom.DayOfYear + 1);
                            break;
                        case "Квартал":
                            dateTo = nextQuater(dateFrom);
                            break;
                        case "Месяц":
                            dateTo = dateFrom.AddMonths(1).AddDays(-dateFrom.Day + 1);
                            break;
                        case "Неделя":
                            dateTo = nextWeek(dateFrom);
                            break;
                    }

                    if (dateTo < Convert.ToDateTime(KU_table.Rows[i][5]))
                    {
                        graph_table.Rows[0][5] = dateTo.ToShortDateString();
                        graph_table.Rows[0][6] = Convert.ToDateTime(graph_table.Rows[0][5]).AddDays(sdvig).ToShortDateString();
                    }
                    else
                    {
                        graph_table.Rows[0][5] = Convert.ToDateTime(KU_table.Rows[i][5]).ToShortDateString();
                        graph_table.Rows[0][6] = Convert.ToDateTime(graph_table.Rows[0][5]).AddDays(sdvig).ToShortDateString();
                    }

                    // Запрос на запись в БД в таблицу Графика
                    command = new SqlCommand($"INSERT INTO KU_graph (KU_id, Vendor_id, KU_percent, Period, Date_from, Date_to, Date_calc, Status) VALUES " +
                        $"({graph_table.Rows[0][0]}, {graph_table.Rows[0][1]}, {graph_table.Rows[0][2]}, " +
                        $"'{graph_table.Rows[0][3]}', '{graph_table.Rows[0][4]}', '{graph_table.Rows[0][5]}', " +
                        $"'{graph_table.Rows[0][6]}', '{graph_table.Rows[0][7]}')", _sqlConnection);
                    command.ExecuteNonQuery();

                    dateFrom = dateTo;
                }
            }
            _sqlConnection.Close();
            return true;
        }

        //Расчёт графика для квартала с поправкой на начало периода
        private DateTime nextQuater(DateTime dateFrom)
        {
            int month = dateFrom.Month;
            if (month < 4)
            {
                dateFrom = new DateTime(dateFrom.Year, 4, dateFrom.Day);
            }
            if (month >= 4 && month < 7)
            {
                dateFrom = new DateTime(dateFrom.Year, 7, dateFrom.Day);
            }
            if (month >= 7 && month < 10)
            {
                dateFrom = new DateTime(dateFrom.Year, 10, dateFrom.Day);
            }
            if (month >= 10)
            {
                dateFrom = dateFrom.AddYears(1);
                dateFrom = new DateTime(dateFrom.Year, 1, dateFrom.Day);
            }
            dateFrom = dateFrom.AddDays(-dateFrom.Day + 1);

            return dateFrom;
        }

        //Расчёт графика для недели с поправкой на начало периода
        private DateTime nextWeek(DateTime dateFrom)
        {
            dateFrom = dateFrom.AddDays(1);
            while (dateFrom.DayOfWeek != DayOfWeek.Monday)
            {
                dateFrom = dateFrom.AddDays(1);
            }
            return dateFrom;

        }


        // Расчет ретро-бонуса конкретной строки графика
        public bool currentRetroCalc(Form graph_form, int rowIndex)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            bool state = false;
            _sqlConnection.Open();
            DataGridView dgv = graph_form.Controls["dataGridView1"] as DataGridView;
            DataGridViewRow row = dgv.Rows[rowIndex];
            Int64 Graph_id = (Int64)row.Cells["Graph_Id"].Value;

            DataTable invoicesProducts = new DataTable();
            SqlCommand cm = new SqlCommand($"SELECT Product_id, Summ FROM Invoices, Invoices_products WHERE Invoices.Invoice_id = Invoices_products.Invoice_id AND " +
                $"Vendor_id = {row.Cells["Vendor_id"].Value} AND Date >= '{row.Cells["Date_from"].Value}' AND Date < '{row.Cells["Date_to"].Value}'", _sqlConnection);
            SqlDataAdapter adapt = new SqlDataAdapter(cm);
            adapt.Fill(invoicesProducts);

            DataTable included = new DataTable();
            cm = new SqlCommand($"SELECT Type, Attribute_1, Attribute_2, Producer, Brand_name FROM Included_products WHERE KU_id = " +
                $"{row.Cells["KU_id"].Value}", _sqlConnection);
            adapt = new SqlDataAdapter(cm);
            adapt.Fill(included);

            DataTable excluded = new DataTable();
            cm = new SqlCommand($"SELECT Type, Attribute_1, Attribute_2, Producer, Brand_name FROM Excluded_products WHERE KU_id = " +
                $"{row.Cells["KU_id"].Value}", _sqlConnection);
            adapt = new SqlDataAdapter(cm);
            adapt.Fill(excluded);

            // Учет включенных и исключенных товаров
            //
            // Создаем список ВКЛ и ИСКЛ товаров по условиям
            int repeater = 0;
            string type, tableName = "Included_products_list";
            SqlCommand command;
            SqlDataReader reader;
            DataTable currTable = included;
            while(repeater < 2)
            {
                for (int i = 0; i < currTable.Rows.Count; i++)
                {
                    type = currTable.Rows[i][0].ToString();
                    switch (type)
                    {
                        case "Все":

                            // Цикл по всем товарам
                            for (int j = 0; j < invoicesProducts.Rows.Count; j++)
                            {
                                // Проверка, не добавлен ли уже этот товар
                                if (duplicateCheck(Graph_id, (Int64)invoicesProducts.Rows[j][0], tableName))
                                    continue;

                                // Если имеются фильтры произв. и торг. марки
                                if (currTable.Rows[i][3].ToString() != "" && currTable.Rows[i][4].ToString() != "")
                                {
                                    // Проверка товара на соответствие условиям произв и торг марки
                                    command = new SqlCommand($"SELECT Producer, Brand_name FROM Products WHERE Product_id = {invoicesProducts.Rows[j][0]}", _sqlConnection);
                                    reader = command.ExecuteReader();
                                    reader.Read();
                                    if (reader[0].ToString() != currTable.Rows[i][3].ToString() || reader[1].ToString() != currTable.Rows[i][4].ToString())
                                    {
                                        reader.Close();
                                        continue;
                                    }
                                    reader.Close();
                                }

                                // Добавление
                                command = new SqlCommand($"INSERT INTO {tableName} (Graph_id, Product_id) VALUES ({Graph_id}, {invoicesProducts.Rows[j][0]})", _sqlConnection);
                                command.ExecuteNonQuery();
                            }

                            break;
                        case "Категория":

                            // Отбор товаров выбранной категории
                            command = new SqlCommand($"SELECT Product_id FROM Invoices, Products WHERE Vendor_id = {row.Cells["Vendor_id"].Value} AND Date >= '{row.Cells["Date_from"].Value}' " +
                                $"AND Date < '{row.Cells["Date_to"].Value}' AND Classifier_id LIKE '{currTable.Rows[i][1]}*'", _sqlConnection);
                            adapt = new SqlDataAdapter(command);
                            DataTable categotyProducts = new DataTable();
                            adapt.Fill(categotyProducts);

                            // Цикл по товарам выбранной категории
                            for (int j = 0; j < categotyProducts.Rows.Count; j++)
                            {
                                // Проверка, не добавлен ли уже этот товар
                                if (duplicateCheck(Graph_id, (Int64)categotyProducts.Rows[j][0], tableName))
                                    continue;

                                // Если имеются фильтры произв. и торг. марки
                                if (currTable.Rows[i][3].ToString() != "" && currTable.Rows[i][4].ToString() != "")
                                {
                                    // Проверка товара на соответствие условиям произв и торг марки
                                    command = new SqlCommand($"SELECT Producer, Brand_name FROM Products WHERE Product_id = {categotyProducts.Rows[j][0]}", _sqlConnection);
                                    reader = command.ExecuteReader();
                                    reader.Read();
                                    if (reader[0].ToString() != currTable.Rows[i][3].ToString() || reader[1].ToString() != currTable.Rows[i][4].ToString())
                                    {
                                        reader.Close();
                                        continue;
                                    }
                                    reader.Close();
                                }

                                // Добавление
                                command = new SqlCommand($"INSERT INTO {tableName} (Graph_id, Product_id) VALUES ({Graph_id}, {categotyProducts.Rows[j][0]})", _sqlConnection);
                                command.ExecuteNonQuery();
                            }
                            categotyProducts.Clear();

                            break;
                        case "Товары":

                            // Проверка, не добавлен ли уже этот товар
                            if (duplicateCheck(Graph_id, Convert.ToInt64(currTable.Rows[i][1]), tableName))
                                break;

                            // Проверка наличия товара в списке товаров по накладным
                            if (!productCheck(invoicesProducts, Convert.ToInt64(currTable.Rows[i][1])))
                                break;
                            
                            // Добавление
                            command = new SqlCommand($"INSERT INTO {tableName} (Graph_id, Product_id) VALUES ({Graph_id}, {currTable.Rows[i][1]})", _sqlConnection);
                            command.ExecuteNonQuery();

                            break;
                    }
                }

                repeater++;
                currTable = excluded;
                tableName = "Excluded_products_list";
            }


            // Вычисление товаров, имеющихся во вкл и неимеющихся в искл
            DataTable InMinusEx = new DataTable();
            command = new SqlCommand($"SELECT DISTINCT Product_id FROM Included_products_list WHERE Graph_id = {Graph_id} EXCEPT " +
                $"(SELECT Product_id FROM Excluded_products_list WHERE Graph_id = {Graph_id})", _sqlConnection);
            adapt.SelectCommand = command;
            adapt.Fill(InMinusEx);

            InMinusEx.Columns.Add("Summ", typeof(double));
            for(int i = 0; i < InMinusEx.Rows.Count; i++)
            {
                command = new SqlCommand($"SELECT Summ FROM Invoices_products WHERE Invoice_id = (SELECT Invoice_id FROM Invoices WHERE Vendor_id = {row.Cells["Vendor_id"].Value}) " +
                    $"AND Product_id = {InMinusEx.Rows[i][0]}", _sqlConnection);
                InMinusEx.Rows[i][1] = command.ExecuteScalar();
            }
            
            // Вывод суммы по накладным и бонуса
            if (InMinusEx.Rows.Count > 0)
            {
                double summ = 0, bonus;
                for (int i = 0; i < InMinusEx.Rows.Count; i++)
                {
                    summ += (double)InMinusEx.Rows[i][1];
                }
                bonus = summ * (double)row.Cells["Percent"].Value / 100;

                command = new SqlCommand($"UPDATE KU_graph SET Sum_calc = {Math.Round(summ, 2)}, Sum_bonus = {Math.Round(bonus, 2)} WHERE " +
                    $"Graph_id = {Graph_id}", _sqlConnection);
                command.ExecuteNonQuery();
                state = true;
            }

            invoicesProducts.Clear();
            included.Clear();
            excluded.Clear();
            InMinusEx.Clear();

            _sqlConnection.Close();
            return state;
        }


        // Проверка дублированности товаров в списках доб или искл товаров
        private bool duplicateCheck(Int64 Graph_id, Int64 Product_id, string tableName)
        {
            SqlCommand command = new SqlCommand($"SELECT Product_id FROM {tableName} WHERE Graph_id = {Graph_id}", _sqlConnection);
            List<Int64> ProductsInDB = new List<long>();
            SqlDataReader reader = command.ExecuteReader();
            ProductsInDB.Clear();
            while (reader.Read())
            {
                ProductsInDB.Add((long)reader[0]);
            }
            reader.Close();

            for(int i = 0; i < ProductsInDB.Count; i++)
            {
                if (Product_id == ProductsInDB[i])
                    return true;
            }

            return false;
        }

        private bool productCheck(DataTable Invoices_prod, Int64 Prod_id)
        {
            for (int i = 0; i < Invoices_prod.Rows.Count; i++)
            {
                if (Prod_id == Convert.ToInt64(Invoices_prod.Rows[i][0]))
                    return true;
            }

            return false;
        }

    }
}
