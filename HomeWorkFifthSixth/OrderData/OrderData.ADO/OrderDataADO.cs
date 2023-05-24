using OrderData.Models;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;


namespace OrderData.ADO
{
    public class OrderDataADO
    {
        private SqlConnection connection;
        private string connectionString;

        public OrderDataADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /* Используя SqlCommand и SqlDataReader, вывести на консоль все заказы (Orders) за последний год. */
        public IEnumerable<Order> GetOrdersFromLastYearSQLCommand()
        {
            List<Order> orders = new List<Order>();

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string commandText = @"SELECT ord_id, ord_datetime, an_name, an_cost, an_price, an_group
                                        FROM Orders o LEFT JOIN Analysis a on o.ord_an = a.an_id
                                        WHERE ord_datetime >= DATEADD(year, -1, GETDATE());";
                SqlCommand command = new SqlCommand(commandText, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(
                        new Order
                        {

                            Id = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            Analysis = new Analysis
                            {
                                Name = reader.GetString(2),
                                Cost = reader.GetDecimal(3),
                                Price = reader.GetDecimal(4),
                                GroupId = reader.GetInt32(5)
                            }
                        }
                       );
                }
            }

            return orders;
        }

        /*  Выполнить условие задания 1, но с использованием SqlDataAdapter и DataSet */
        public IEnumerable<Order> GetOrdersFromLastYearSQLAdapter()
        {
            List<Order> orders = new List<Order>();
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string commandText = @"SELECT ord_id, ord_datetime, an_name, an_cost, an_price, an_group
                                        FROM Orders o LEFT JOIN Analysis a on o.ord_an = a.an_id
                                        WHERE ord_datetime >= DATEADD(year, -1, GETDATE());";
                SqlDataAdapter adapter = new SqlDataAdapter(commandText, connection);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                DataTable table = dataSet.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    orders.Add(
                        new Order
                        {

                            Id = (int)row["ord_id"],
                            Date = (DateTime)row["ord_datetime"],
                            Analysis = new Analysis
                            {
                                Name = (string)row["an_name"],
                                Cost = (decimal)row["an_cost"],
                                Price = (decimal)row["an_price"],
                                GroupId = (int)row["an_group"]
                            }
                        }
                       );
                }
            }

            return orders;

        }

        /* Используя SqlCommand создать новую запись в таблице Orders */
        public int CreateOrder(Order order)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string commandText = @"INSERT INTO Orders(ord_id, ord_datetime, ord_an)
                                    VALUES(@id, @datetime, @analysis)";

                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@id", order.Id);
                command.Parameters.AddWithValue("@datetime", DateTime.Now);
                command.Parameters.AddWithValue("@analysis", order.AnalysisId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        /* Используя SqlCommand обновить одну из записей в таблице Orders */
        public int UpdateOrder(Order orderToUpdate)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string commandText = @"UPDATE Orders SET ord_datetime = @datetime, ord_an=@analysis WHERE ord_id = @id";

                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@id", orderToUpdate.Id);
                command.Parameters.AddWithValue("@datetime", DateTime.Now);
                command.Parameters.AddWithValue("@analysis", orderToUpdate.AnalysisId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        /* Используя SqlCommand удалить одну из записей в таблице Orders */
        public int DeleteOrder(int orderId)
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string commandText = "DELETE FROM Orders WHERE ord_id = @id";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@id", orderId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }
    }
}