using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DAL.ADO.Entities;
using DAL.ADO.Interfaces;

namespace DAL.ADO.Gateways
{
    public class SupplierGateway:IGateway<Supplier>
    {
        private string connectionString;

        public SupplierGateway()
        {
            connectionString = ConfigurationManager.
                ConnectionStrings["DBConnection"].
                ConnectionString;
        }

        public SupplierGateway(string connection)
        {
            connectionString = connection;
        }

        public bool Create(Supplier item)
        {
            if (item == null)
                throw new ArgumentNullException();

            SqlParameter Id = new SqlParameter("@Id", item.ID);
            SqlParameter NameCompany = new SqlParameter("@NameCompany", item.NameCompany);

            string query = $"INSERT INTO Suppliers VALUES (@Id,@NameCompany);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction;
                SqlCommand command = new SqlCommand(query, connection);

                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                command.Parameters.AddRange(new SqlParameter[] { Id, NameCompany });

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }

            return false;
        }

        public Supplier Get(int id)
        {
            if (!ValidateId(id))
                return null;

            SqlParameter Id = new SqlParameter("@Id", id);
            SqlDataReader reader;
            Supplier supplier = new Supplier();
            string query = $"SELECT * FROM Suppliers WHERE ID = @Id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(Id);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                try
                {
                    connection.Open();

                    while (reader.Read())
                    {
                        supplier.ID = reader.GetInt32(0);
                        supplier.NameCompany = reader.GetString(1);
                    }
                }
                finally
                {
                    reader.Close();
                }

            }

            return supplier;
        }

        public IEnumerable<Supplier> GetAll()
        {
            SqlDataReader reader;
            List<Supplier> suppliers = new List<Supplier>();
            string query = $"SELECT * FROM Suppliers;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var toAdd = new Supplier()
                        {
                            ID = reader.GetInt32(0),
                            NameCompany = reader.GetString(1)
                        };
                        suppliers.Add(toAdd);
                    }

                    reader.NextResult();
                }
                reader.Close();
            }

            return suppliers;
        }

        public bool Remove(int id)
        {
            if (!ValidateId(id))
                return false;

            SqlParameter Id = new SqlParameter("@Id", id);
            string query = $"DELETE FROM Suppliers WHERE ID = @Id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlTransaction transaction;

                command.Parameters.Add(Id);
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }

            return false;
        }

        public bool Remove(Supplier item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return Remove(item.ID);
        }

        public bool Update(Supplier item)
        {
            SqlParameter Id = new SqlParameter("@Id", item.ID);
            SqlParameter NameCompany = new SqlParameter("@NameCompany", item.NameCompany);

            string query = $"UPDATE Suppliers SET TypeName = @NameCompany WHERE ID = @Id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlTransaction transaction = connection.BeginTransaction();

                command.Parameters.AddRange(new SqlParameter[] { Id, NameCompany });
                command.Transaction = transaction;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
            }

            return false;
        }

        private bool ValidateId(int id)
        {
            if (id < 0)
                return false;
            return true;
        }
    }
}
