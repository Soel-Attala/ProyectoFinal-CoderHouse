namespace Final_Project.Data
{
    using System;
    using System.Collections.Generic;
    using Final_Project.Entity;
    using Microsoft.Data.SqlClient;

    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager()
        {
            this.connectionString = "Server=.;Database=coderhouse;Trusted_Connection=True;";
        }

        //metodos del usuario
        public User GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "SELECT * FROM User where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int obtainedId = Convert.ToInt32(reader["id"]);
                    string firstName = reader.GetString(1);
                    string lastName = reader.GetString(2);
                    string username = reader.GetString(3);
                    string password = reader.GetString(4);
                    string email = reader.GetString(5);

                    User user = new User(obtainedId, firstName, lastName, username, password, email);

                    return user;
                }

                throw new Exception("Id not found");
            }
        }

        public bool AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "INSERT INTO User (FirstName, LastName, Username, Password, Email) values (@firstName, @lastName, @username, @password, @email); select @@IDENTITY as ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("firstName", user.FirstName);
                command.Parameters.AddWithValue("lastName", user.LastName);
                command.Parameters.AddWithValue("username", user.Username);
                command.Parameters.AddWithValue("password", user.Password);
                command.Parameters.AddWithValue("email", user.Email);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "DELETE FROM User WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateUserById(int id, User user)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "UPDATE User SET FirstName = @firstName, LastName = @lastName, Username = @username, Password = @password, Email = @email WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("firstName", user.FirstName);
                command.Parameters.AddWithValue("lastName", user.LastName);
                command.Parameters.AddWithValue("username", user.Username);
                command.Parameters.AddWithValue("password", user.Password);
                command.Parameters.AddWithValue("email", user.Email);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateUserById(int id, string lastName)
        {
            throw new NotImplementedException("Method not implemented");
        }



        //metodos de productos
        public Product GetProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "SELECT * FROM Product where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int obtainedId = Convert.ToInt32(reader["id"]);
                    string name = reader.GetString(1);
                    string description = reader.GetString(2);
                    double cost = Convert.ToDouble(reader["cost"]);
                    long stock = Convert.ToInt64(reader["stock"]);
                    double salePrice = Convert.ToDouble(reader["salePrice"]);
                    int userId = Convert.ToInt32(reader["userId"]);

                    Product product = new Product(obtainedId, name, description, cost, stock, salePrice, userId);

                    return product;
                }

                throw new Exception("Id not found");
            }
        }

        public bool AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "INSERT INTO Product (Name, Description, Cost, Stock, SalePrice, UserId) values (@name, @description, @cost, @stock, @salePrice, @userId); select @@IDENTITY as ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("name", product.Name);
                command.Parameters.AddWithValue("description", product.Description);
                command.Parameters.AddWithValue("cost", product.Cost);
                command.Parameters.AddWithValue("stock", product.Stock);
                command.Parameters.AddWithValue("salePrice", product.SalePrice);
                command.Parameters.AddWithValue("userId", product.UserId);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "DELETE FROM Product WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateProductById(int id, Product product)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "UPDATE Product SET Name = @name, Description = @description, Cost = @cost, Stock = @stock, SalePrice = @salePrice, UserId = @userId WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("name", product.Name);
                command.Parameters.AddWithValue("description", product.Description);
                command.Parameters.AddWithValue("cost", product.Cost);
                command.Parameters.AddWithValue("stock", product.Stock);
                command.Parameters.AddWithValue("salePrice", product.SalePrice);
                command.Parameters.AddWithValue("userId", product.UserId);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateProductById(int id, double cost)
        {
            throw new NotImplementedException("Method not implemented");
        }

        //metodos de ventas
        public Sale GetSaleById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "SELECT * FROM Sale where id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int obtainedId = Convert.ToInt32(reader["id"]);
                    int saleId = Convert.ToInt32(reader["saleId"]);
                    string comments = reader.GetString(2);

                    Sale sale = new Sale(obtainedId, saleId, comments);

                    return sale;
                }

                throw new Exception("Id not found");
            }
        }

        public bool AddSale(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "INSERT INTO Sale (SaleId, Comments) values (@saleId, @comments); select @@IDENTITY as ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("saleId", sale.SaleId);
                command.Parameters.AddWithValue("comments", sale.Comments);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteSaleById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "DELETE FROM Sale WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateSaleById(int id, Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "UPDATE Sale SET SaleId = @saleId, Comments = @comments WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("saleId", sale.SaleId);
                command.Parameters.AddWithValue("comments", sale.Comments);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateSaleById(int id, string comments)
        {
            throw new NotImplementedException("Method not implemented");
        }


        //metodos de productos ya vendidos
        public SoldProduct GetSoldProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "SELECT * FROM SoldProduct WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int obtainedId = Convert.ToInt32(reader["id"]);
                    int productId = Convert.ToInt32(reader["productId"]);
                    int saleId = Convert.ToInt32(reader["saleId"]);
                    long stock = Convert.ToInt64(reader["stock"]);

                    SoldProduct soldProduct = new SoldProduct(obtainedId, productId, saleId, stock);

                    return soldProduct;
                }

                throw new Exception("Id not found");
            }
        }

        public bool AddSoldProduct(SoldProduct soldProduct)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "INSERT INTO SoldProduct (ProductId, SaleId, Stock) VALUES (@productId, @saleId, @stock); SELECT @@IDENTITY AS ID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("productId", soldProduct.ProductId);
                command.Parameters.AddWithValue("saleId", soldProduct.SaleId);
                command.Parameters.AddWithValue("stock", soldProduct.Stock);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteSoldProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "DELETE FROM SoldProduct WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateSoldProductById(int id, SoldProduct soldProduct)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string query = "UPDATE SoldProduct SET ProductId = @productId, SaleId = @saleId, Stock = @stock WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("productId", soldProduct.ProductId);
                command.Parameters.AddWithValue("saleId", soldProduct.SaleId);
                command.Parameters.AddWithValue("stock", soldProduct.Stock);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateSoldProductById(int id, long stock)
        {
            throw new NotImplementedException("Method not implemented");
        }

        public List<User> GetUserById()
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSaleById()
        {
            throw new NotImplementedException();
        }

        public List<SoldProduct> GetSoldProductById()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductById()
        {
            throw new NotImplementedException();
        }
    }


}