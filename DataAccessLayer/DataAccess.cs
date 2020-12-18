using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Transactions;

namespace DataAccessLayer
{
    public class DataAccess
    {
        SqlConnection connection;
        public DataAccess(Options.ConnectionOptions options)
        {
            string connectionInfo = $"Data Source = { options.Server }; Initial Catalog = { options.Database }; Integrated Security = { options.IntegratedSecurity }";

            using (TransactionScope scope = new TransactionScope())
            {
                connection = new SqlConnection(connectionInfo);
                connection.Open();
                scope.Complete();
            }
        }

        public List<T> GetListItems<T>(string sqlExpression) where T : new()
        {
            List<T> items = new List<T>();

            SqlCommand command = new SqlCommand(sqlExpression, connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            using (TransactionScope scope = new TransactionScope())
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T item = new T();
                    Type type = item.GetType();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        object value = reader.GetValue(i);
                        if (value.GetType() == typeof(DBNull))
                        {
                            value = null;
                        }
                        PropertyInfo info = type.GetProperty(reader.GetName(i));
                        info.SetValue(item, value);
                    }

                    items.Add(item);
                }

                reader.Close();
                scope.Complete();
            }

            return items;
        }
    }
}
