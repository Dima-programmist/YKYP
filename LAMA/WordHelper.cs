using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using System.Configuration;

namespace РасчетКУ
{
    class WordHelper
    {
        private FileInfo _fileInfo;
        //public string NameEntities;
        //private SqlConnection SqlCon;

       /* private void Form1_Load(object sender, EventArgs e)
        {
            SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            SqlCon.Open();
        }*/
        public WordHelper(string fileName)
        {
            if (File.Exists(fileName))
            {
                _fileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new ArgumentException("not found");
            }
        }

        internal bool Process(Dictionary<string, string> items)
        {
            Word.Application app = null;
            try
            {
                app = new Word.Application();
                Object file = _fileInfo.FullName;
                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchSoundsLike: missing,
                        Forward:true,
                        Wrap:wrap,
                        Format:false,
                        ReplaceWith: missing,
                        Replace:replace);

                }

               // Object newFileName = Path.Combine(_fileInfo.DirectoryName, _fileInfo.Name);
                app.Visible = true;
                //app.ActiveDocument.SaveAs2(newFileName);
                //app.ActiveDocument.Close();

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                if (app != null)
                    app.Visible = true;

                 //app.Quit();

                 //app.Documents.Open(file);
            }
            return false;
        }

        /*public string GetEntitiesName(string NameEntities)
        {
            SqlCommand cm = new SqlCommand("SELECT Name from Entities where ");
        }*/
    }
}
