using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace РасчетКУ
{
    public partial class CategorySelectionForm : Form
    {
        private SqlConnection _sqlConnection;
        public CategorySelectionForm()
        {
            InitializeComponent();
        }

       private void CategorySelectionForm_Load(object sender, EventArgs e)
       {
       //     _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
       //                 _sqlConnection.Open();
       //
       //     List<string> categories = SqlConnection.Select("SELECT Сategory FROM dbo.Products ORDER BY Сategory");
       }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
