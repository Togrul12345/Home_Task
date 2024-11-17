using Ado_Net.Models;
using Ado_Net.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Net.Services.Concretes
{
    internal class Service : IService
    {
        public void InsertIntoTable()
        {
            using (SqlConnection connection = new SqlConnection(Connection._connection))
            {
                string query = "insert into Students values('Cebrayil','Cebrayilov','2005-07-28','Cebrayil123456','1234rtfd','2024-09-02')";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                   
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);


                }

            }
        }

        public void DeleteTable(int id)
        {
            using (SqlConnection connection = new SqlConnection(Connection._connection))
            {
                string query = $"Delete  from Students where id={id}";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]},{reader[1]},{reader[2]}");
                        }

                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);


                }

            }
        }

        public void ReadTable()
        {
            using (SqlConnection connection = new SqlConnection(Connection._connection))
            {
                string query = "Select * from Students";

                SqlCommand command = new SqlCommand(query,connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]},{reader[1]},{reader[2]},{reader[3]},{reader[4]},{reader[5]},{reader[6]}");
                        }

                    }
                    reader.Close();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    
                }
                
            }

        }
        public  void UpdateTable(int id)
        {
            using (SqlConnection connection = new (Connection._connection))
            {
                string date = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    
                string query = $"Update Students set enrollmentDate='{date}' where id={id}";
                Console.WriteLine(query);

                SqlCommand command = new(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Update completed");
                    reader.Close();
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);


                }

            }
        }
    }
}
