using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Department
{
    static class DataBase
    {
        public static SqlConnection connection;

        public static void Connect()
        {
            try
            {
                connection = new SqlConnection(@"Server=localhost;Database=Deparment;Trusted_Connection=True;");
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public static void Disconnect()
        {
            connection.Close();
        }

        public static List<T> SelectQuery<T>(string query) where T : new()
        {
            List<T> items = null;
            SqlCommand command = connection.CreateCommand();
            try
            {
                command.CommandText = query;
                SqlDataReader sqlDataReader = command.ExecuteReader();

                items = Fill<T>(sqlDataReader);

                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

            return items;
        }

        public static int InsertUpdateDeleteQuery(string query)
        {
            int affectedRows = 0;
            SqlCommand command = connection.CreateCommand();
            try
            {
                command.CommandText = query;
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

            return affectedRows;
        }

        static List<T> Fill<T>(this SqlDataReader reader) where T : new()
        {
            List<T> res = new List<T>();
            while (reader.Read())
            {
                T t = new T();
                for (int inc = 0; inc < reader.FieldCount; inc++)
                {
                    Type type = t.GetType();
                    string name = reader.GetName(inc);
                    PropertyInfo prop = type.GetProperty(name);
                    if (prop != null)
                    {
                        if (name == prop.Name)
                        {
                            var value = reader.GetValue(inc);
                            if (value != DBNull.Value)
                            {
                                prop.SetValue(t, Convert.ChangeType(value, prop.PropertyType), null);
                            }
                        }
                    }
                }
                res.Add(t);
            }
            reader.Close();

            return res;
        }
    }
}
