using System;
using System.Data;
using System.Windows.Forms;

namespace РасчетКУ
{
    public partial class SettingsForm : Form
    {
        string name1 = "delta";
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Global_parameters GP = new Global_parameters();
            textBox1.Text = GP.getParameter(name1);
            if (textBox1.Text == "null")
                textBox1.Text = "";
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar != 8 && (e.KeyChar <= 47 || e.KeyChar >= 58))
            {
                e.Handled = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Количество дней для сдвига даты расчёта не введено! Попробуйте снова");
            }
            else
            {
               string text = textBox1.Text;
               Global_parameters GP1 = new Global_parameters();
               GP1.setParameter(name1, text);
               MessageBox.Show("Сохранено!");
              
            }
            /*if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Строка подключения не введена");
            }
            else
            {
                string text = textBox2.Text;
                Global_parameters GP1 = new Global_parameters();
                GP1.setString(text);
                MessageBox.Show(GP1.getString());
            }*/
        }

        
    }
}
