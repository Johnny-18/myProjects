using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ADO.Interfaces;
using DAL.ADO.Entities;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL.ADO.Gateways
{
    public class ProductTypeGateway:IGateway<ProductType>
    {
        private string connectionString;

        public ProductTypeGateway()
        {
            connectionString = ConfigurationManager.
                ConnectionStrings["DBConnection"].
                ConnectionString;
        }

        public ProductTypeGateway(string connection)
        {
            connectionString = connection;
        }

        public bool Create(ProductType item)
        {
            if (item == null)
                throw new ArgumentNullException();

            SqlParameter Id = new SqlParameter("@Id", item.ID);
            SqlParameter TypeName = new SqlParameter("@TypeName", item.TypeName);

            string query = $"INSERT INTO ProductTypes VALUES (@Id,@TypeName);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction;
                SqlCommand command = new SqlCommand(query,connection);

                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                command.Parameters.AddRange(new SqlParameter[] { Id, TypeName });

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    return true;
                }
                catch(Exception)
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

        public ProductType Get(int id)
        {
            if (!ValidateId(id))
                throw new FormatException("InvalidIdException!");

            SqlParameter Id = new SqlParameter("@Id",id);
            SqlDataReader reader;
            ProductType productType = new ProductType();
            string query = $"SELECT * FROM ProductTypes WHERE ID = @Id;";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add(Id);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                try
                {
                    connection.Open();

                    while (reader.Read())
                    {
                        productType.ID = reader.GetInt32(0);
                        productType.TypeName = reader.GetString(1);
                    }
                }
                finally
                {
                    reader.Close();
                }

            }

            return productType;
        }

        public IEnumerable<ProductType> GetAll()
        {
            SqlDataReader reader;
            List<ProductType> productTypes = new List<ProductType>();
            string query = $"SELECT * FROM ProductTypes;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var toAdd = new ProductType()
                        {
                            ID = reader.GetInt32(0),
                            TypeName = reader.GetString(1)
                        };
                        productTypes.Add(toAdd);
                    }

                    reader.NextResult();
                }
                reader.Close();
            }

            return productTypes;
        }

        public bool Remove(int id)
        {
            if (!ValidateId(id))
                throw new FormatException("InvalidIdException!");

            SqlParameter Id = new SqlParameter("@Id", id);
            string query = $"DELETE FROM ProductTypes WHERE ID = @Id;";

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

        public bool Remove(ProductType item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return Remove(item.ID);
        }   

        public bool Update(ProductType item)
        {
            SqlParameter Id = new SqlParameter("@Id",item.ID);
            SqlParameter TypeName = new SqlParameter("@TypeName", item.TypeName);

            string query = $"UPDATE ProductType SET TypeName = @TypeName WHERE ID = @Id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlTransaction transaction = connection.BeginTransaction();

                command.Parameters.AddRange(new SqlParameter[] { Id,TypeName });
                command.Transaction = transaction;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    return true;
                }
                catch(Exception)
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

