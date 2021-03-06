using System;
using System.Collections.Generic;
using System.Data;
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
        public static object Execute(string name, string paramName, object o)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name;
            command.Parameters.AddWithValue(paramName, o);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            sqlDataReader.Read();
            object oo = sqlDataReader.GetValue(0);
            sqlDataReader.Close();
            return oo;
        }
        public static List<T> Execute<T>(string name,
            string paramName1, object o1,
            string paramName2, object o2,
            string paramName3, object o3,
            string paramName4, object o4
            ) where T : new()
        {
            List<T> items = null;
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = name;
            command.Parameters.AddWithValue(paramName1, o1);
            command.Parameters.AddWithValue(paramName2, o2);
            command.Parameters.AddWithValue(paramName3, o3);
            command.Parameters.AddWithValue(paramName4, o4);
            SqlDataReader sqlDataReader = command.ExecuteReader();

            items = Fill<T>(sqlDataReader);

            sqlDataReader.Close();

            return items;
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
                                Type ty = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                object safeValue = (value == null) ? null : Convert.ChangeType(value, ty);
                                prop.SetValue(t, safeValue, null);
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
