using System.Data.SqlClient;
using System.Configuration;

namespace РасчетКУ
{
    class Global_parameters
    {
        private string connString = "Data Source=S-684\\SQLEXPRESS;Initial Catalog=DataBaseKU;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void setString(string text)
        {
            connString = text;
            
        }

        public string getString()
        {
            return connString;
        }

        private void addParameter(string name)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand($"INSERT INTO Global_parameters (Name) VALUES ('{name}')", conn);
            command.ExecuteNonQuery();
           
            conn.Close();
        }

        public void setParameter(string name, string value)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand($"SELECT Value FROM Global_parameters WHERE Name = '{name}'", conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                reader.Close();
                command = new SqlCommand($"UPDATE Global_parameters SET Value = '{value}' WHERE Name = '{name}'", conn);
                command.ExecuteNonQuery();
            }
            else
                reader.Close();

            conn.Close();
        }

        public string getParameter(string name)
        {
            string param = "null";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand command = new SqlCommand($"SELECT Value FROM Global_parameters WHERE Name = '{name}'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if(reader.HasRows)
                param = reader[0].ToString();
            else
            {
                reader.Close();
                conn.Close();
                addParameter(name);
                getParameter(name);
            }
            reader.Close();
            conn.Close();
           return param;
        }
    }
}
