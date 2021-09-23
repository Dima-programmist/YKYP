using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace РасчетКУ
{
    public partial class KUGraphForm : Form
    {
        private SqlConnection SqlCon;
        public string VendorName;
        public string EntitiesName;

        public KUGraphForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            SqlCon.Open();

            ShowGraph();
        }

        //Вывод графика из БД
        private void ShowGraph()
        {
            DataTable graphs = new DataTable();
            SqlCommand cm1 = new SqlCommand("SELECT * FROM KU_graph", SqlCon);
            SqlDataAdapter adt1 = new SqlDataAdapter();
            adt1.SelectCommand = cm1;
            adt1.Fill(graphs);

            dataGridView1.Rows.Clear();
            for (int i = 0; i < graphs.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["Graph_Id"].Value = graphs.Rows[i][0];
                dataGridView1.Rows[i].Cells["KU_id"].Value = graphs.Rows[i][1];
                dataGridView1.Rows[i].Cells["Vendor_id"].Value = graphs.Rows[i][2];
                dataGridView1.Rows[i].Cells["Percent"].Value = Convert.ToDouble(graphs.Rows[i][3]) / 10;
                dataGridView1.Rows[i].Cells["Period"].Value = graphs.Rows[i][4];
                dataGridView1.Rows[i].Cells["Date_from"].Value = Convert.ToDateTime(graphs.Rows[i][5]).ToShortDateString();
                dataGridView1.Rows[i].Cells["Date_to"].Value = Convert.ToDateTime(graphs.Rows[i][6]).ToShortDateString();
                dataGridView1.Rows[i].Cells["Date_calc"].Value = Convert.ToDateTime(graphs.Rows[i][7]).ToShortDateString();
                dataGridView1.Rows[i].Cells["GraphStatus"].Value = graphs.Rows[i][8];
                dataGridView1.Rows[i].Cells["GraphSumN"].Value = graphs.Rows[i][9];
                dataGridView1.Rows[i].Cells["GraphSumP"].Value = graphs.Rows[i][10];
                dataGridView1.Rows[i].Cells["GraphSumS"].Value = graphs.Rows[i][11];
            }
        }

        // Кнопка согласовать (статус)
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {
                SqlCommand comm = new SqlCommand($"UPDATE KU_graph SET Status = 'Согласовано' WHERE Graph_id = {dataGridView1.SelectedRows[i].Cells["Graph_Id"].Value}", SqlCon);
                comm.ExecuteNonQuery();
            }
            ShowGraph();
        }

        // Расчет БОНУСА
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка есть ли рассчет в выбранных строчках или нет
            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[i];
                if (row.Cells["GraphStatus"].Value.ToString() == "Рассчитано")
                {
                    DialogResult result;
                    result = MessageBox.Show("В выбранных строках графика уже рассчитана сумма ретро бонуса, пересчитать их?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                        return;
                }
                SqlCommand command = new SqlCommand($"UPDATE KU_graph SET Sum_calc = NULL, Sum_bonus = NULL, Sum_accept = NULL WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Included_products_list WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
                command = new SqlCommand($"DELETE FROM Excluded_products_list WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();
            }

            // Расчет бонуса для каждой выделенной строки
            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[i];

                // Изменение статуса на "В расчете"
                SqlCommand command = new SqlCommand($"UPDATE KU_graph SET Status = 'В расчете' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                command.ExecuteNonQuery();

                Actions actions = new Actions();
                if(actions.currentRetroCalc(this, row.Index))
                {
                    // Изменение статуса на "Рассчитано" 
                    command = new SqlCommand($"UPDATE KU_graph SET Status = 'Рассчитано' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                }
                else
                {
                    // Изменение статуса на "Создан" 
                    command = new SqlCommand($"UPDATE KU_graph SET Status = 'Создан' WHERE Graph_id = {row.Cells["Graph_Id"].Value}", SqlCon);
                }
                command.ExecuteNonQuery();
            }
            ShowGraph();
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

        //Открытие формы списка поставщиков с помощью кнопки на верхней панели
        private void поставщикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FormVendorsList = new VendorsListForm();

            FormVendorsList.Show();
        }
        // Открытие формы настроек
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsForm();
            settings.ShowDialog();
        }

        // Закрытие соединения с БД
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) 
        {
            SqlCon.Close();
        }

        //Отчёт ворд
        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            SqlCommand cm = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = " +
                $"{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            VendorName = (string)cm.ExecuteScalar();

            SqlCommand cm2 = new SqlCommand($"SELECT Name FROM Entities WHERE Entity_id = (SELECT Entity_id FROM Vendors WHERE Vendor_id = " +
                $"{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value}) ", SqlCon);
            EntitiesName = (string)cm2.ExecuteScalar();

            var helper = new WordHelper("protokol.docx");
            /*string NameEntities;
            string NameVendors;*/
            var items = new Dictionary<string, string>
            {
                {"<num>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value)},
                {"<Entities.Name>",EntitiesName},
                {"<Vendors.Name>", VendorName},
                {"<KU_graph.Percent>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value)},
                {"<KU_graph.Date_from>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value)},
                {"<KU_graph.Date_to>", Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value)},
            };
            

            helper.Process(items);
           // MessageBox.Show("Файл сохранен");

           
        }

        //Отчёт эксель
        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application ObjExcel = new Excel.Application();
            SqlCommand commanda = new SqlCommand($"SELECT Name FROM Vendors WHERE Vendor_id = " +
                 $"{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            string VendorName1 = (string)commanda.ExecuteScalar();


            Excel.Workbook ObjWorkBook;
             Excel.Worksheet ObjWorkSheet;
            //Книга.
             ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
            
            //Значения y - строка,x - столбец
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 1], ObjWorkSheet.Cells[1, 6]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 1], ObjWorkSheet.Cells[1, 6]] = "Отчёт по расчёту размера Ретро-Бонуса для поставщика:";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 7], ObjWorkSheet.Cells[1, 8]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 7], ObjWorkSheet.Cells[1, 8]] = VendorName1;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 1], ObjWorkSheet.Cells[1, 9]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[1, 1], ObjWorkSheet.Cells[1, 9]].Font.Bold = true;

            ObjWorkSheet.Range[ObjWorkSheet.Cells[4, 1], ObjWorkSheet.Cells[4, 4]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[4, 1], ObjWorkSheet.Cells[4, 4]] = "Размер премии составил: ";
            ObjWorkSheet.Cells[4, 5] = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[4, 1], ObjWorkSheet.Cells[4, 4]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 1], ObjWorkSheet.Cells[3, 8]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 1], ObjWorkSheet.Cells[3, 8]] = "Расчет премии был произведен на основании суммы по накладным в размере: ";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 1], ObjWorkSheet.Cells[3, 8]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Cells[3, 9] = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 1], ObjWorkSheet.Cells[3, 9]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 10], ObjWorkSheet.Cells[3, 11]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 10], ObjWorkSheet.Cells[3, 11]] = "и процента КУ: ";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[3, 10], ObjWorkSheet.Cells[3, 11]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Cells[3, 12] = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);

            ObjWorkSheet.Range[ObjWorkSheet.Cells[5, 1], ObjWorkSheet.Cells[5, 4]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[5, 1], ObjWorkSheet.Cells[5, 4]] = "Согласованный размер премии равен: ";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[5, 1], ObjWorkSheet.Cells[5, 4]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Cells[5, 5] = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value);

            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]].Merge(Type.Missing);
            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]].WrapText = true;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]] = "Накладные, использованные для расчета:";
            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            ObjWorkSheet.Range[ObjWorkSheet.Cells[7, 1], ObjWorkSheet.Cells[8, 3]].Font.Bold = true;

            ObjWorkSheet.Cells[9, 1] = "Код накладной";
            ObjWorkSheet.Cells[9, 1].WrapText = true;
            ObjWorkSheet.Cells[9, 1].ColumnWidth = 10.15;
            ObjWorkSheet.Cells[9, 2] = "Сумма по накладной";
            ObjWorkSheet.Cells[9, 2].WrapText = true;
            ObjWorkSheet.Cells[9, 2].ColumnWidth = 10.15;


            DataTable invoice1 = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT Invoice_id FROM Invoices WHERE Vendor_id = " + $" {dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value} ", SqlCon);
            SqlDataAdapter adt2 = new SqlDataAdapter();
            adt2.SelectCommand = command;
            adt2.Fill(invoice1);

            for (int i = 0; i < invoice1.Rows.Count; i++)
            {
                ObjWorkSheet.Cells[i + 10, 1] = invoice1.Rows[i][0];
            }

            DataTable sum_inv = new DataTable();
            SqlCommand comm = new SqlCommand($"SELECT SUM(Summ) FROM Invoices_products, Invoices WHERE Invoices.Invoice_id = Invoices_products.Invoice_id AND" +
                                $" Invoices.Vendor_id =  {dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Vendor_id"].Value}", SqlCon);
            SqlDataAdapter adt3 = new SqlDataAdapter();
            adt3.SelectCommand = comm;
            adt3.Fill(sum_inv);

            for (int j = 0; j < sum_inv.Rows.Count; j++)
            {
                ObjWorkSheet.Cells[j + 10, 2] = sum_inv.Rows[j][0];
            }


            //  ObjWorkSheet.Rows.AutoFit();
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
        }
    }
}
