using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using DAL.ADO.Entities;
using DAL.ADO.Interfaces;
using System.Data.SqlClient;

namespace DAL.ADO.Gateways
{
    public class ProductGateway: IGateway<Product>
    {
        private string connectionString;

        public ProductGateway()
        {
            connectionString = ConfigurationManager.
                ConnectionStrings["DBConnection"].
                ConnectionString;
        }
        
        public ProductGateway(string connection)
        {
            connectionString = connection;
        }

        public bool Create(Product item)
        {
            if (item == null)
                throw new ArgumentNullException();

            SqlParameter Id = new SqlParameter("@Id", item.ID);
            SqlParameter Name = new SqlParameter("@Name", item.Name);
            SqlParameter SupplierId = new SqlParameter("@SupplierId", item.Supplier_id);
            SqlParameter TypeId = new SqlParameter("@TypeId", item.Type_id);

            string query = $"INSERT INTO Products VALUES (@Id,@Name,@SupplierId,@TypeId);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction;
                SqlCommand command = new SqlCommand(query, connection);

                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                command.Parameters.AddRange(new SqlParameter[] { Id, Name, SupplierId,TypeId });

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

        public Product Get(int id)
        {
            if (!ValidateId(id))
                throw new FormatException("InvalidIdException!");

            SqlParameter Id = new SqlParameter("@Id", id);
            SqlDataReader reader;
            Product product = new Product();
            string query = $"SELECT * FROM Products WHERE ID = @Id;";

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
                        product.ID = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.Type_id = reader.GetInt32(2);
                        product.Supplier_id = reader.GetInt32(3);
                    }
                }
                finally
                {
                    reader.Close();
                }

            }

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            SqlDataReader reader;
            List<Product> products = new List<Product>();
            string query = $"SELECT * FROM Products;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string temp1 = reader.GetValue(0).ToString();
                        string temp2 = reader.GetValue(1).ToString();
                        string temp3 = reader.GetValue(2).ToString();
                        string temp4 = reader.GetValue(3).ToString();
                        string temp5 = reader.GetValue(4).ToString();
                        var toAdd = new Product()
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Type_id = reader.GetInt32(3),
                            Supplier_id = reader.GetInt32(4)
                        };
                        products.Add(toAdd);
                    }

                    reader.NextResult();
                }
                reader.Close(); 
            }

            return products;
        }

        public bool Remove(int id)
        {
            if (!ValidateId(id))
                throw new FormatException("InvalidIdException!");

            SqlParameter Id = new SqlParameter("@Id", id);
            string query = $"DELETE FROM Products WHERE ID = @Id;";

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

        public bool Remove(Product item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return Remove(item.ID);
        }

        public bool Update(Product item)
        {
            SqlParameter Id = new SqlParameter("@Id", item.ID);
            SqlParameter Name = new SqlParameter("@Name", item.Name);
            SqlParameter SupplierId = new SqlParameter("@SupplierId", item.Supplier_id);
            SqlParameter TypeId = new SqlParameter("@TypeId", item.Type_id);

            string query = $"UPDATE Products SET Name = @Name, Supplier_Id = @SupplierId, Type_Id = @TypeId WHERE ID = @Id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlTransaction transaction = connection.BeginTransaction();

                command.Parameters.AddRange(new SqlParameter[] { Id, Name, TypeId,SupplierId });
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
