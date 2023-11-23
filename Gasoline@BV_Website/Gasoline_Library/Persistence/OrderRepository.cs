using MySql.Data.MySqlClient;
using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Persistence.ReposInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace Stock_Inventory_Library.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private String GET_PRODUCT_QUANTITY = "SELECT Quantity FROM product WHERE ProductID=@id";

        private String UPDATE_PRODUCT_QUANTITY = "UPDATE product SET Quantity=@qty WHERE ProductID=@id";

        private String ADD_NEW_CUSTOMER_ORDER = "INSERT INTO orders (UserId, ProductID, FullName, OrderQuantity, Price, Image, TotalCost, Date, TotalAmount)VALUES(@userid, @prodid, @user, @name, @qty, @price, @img, @total, @date, @amount)";

        private String GET_ALL_CUSTOMERS_ORDERS = "SELECT * FROM carts";

        //private String GET_CUSTOMER_ORDERSBYID = "SELECT * FROM orders WHERE OrderId=@id";

        private String GET_CARTITEMS_BYNAME = "SELECT * FROM carts WHERE ProductName=@name";
        public bool DecreaseProduct(int ID, int DecreaseQty)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            bool SuccessFully = false;
            try
            {
                // Get the Actual Qty for the Product


                int CurrentQuantity = this.GetProductQuantity(ID);

                // Increase the Qty , after it has been deducted from Product store

                int NewQuantity = CurrentQuantity - DecreaseQty;

                // Update Product Qty

                SuccessFully = this.UpdateProductQuantity(ID, NewQuantity);
            }
            catch (Exception Exp)
            {
                Debug.WriteLine(Exp.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return SuccessFully;
        }

        public int GetProductQuantity(int ProductID)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String Sql = GET_PRODUCT_QUANTITY;

            int Qty = 0;

            // Data Table

            DataTable dt = new DataTable();

            try
            {
                MySqlCommand cmd = new MySqlCommand(Sql, conn);

                cmd.Parameters.AddWithValue("@id", ProductID);

                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Qty = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return Qty;
        }


        public bool UpdateProductQuantity(int ProductID, int NewQty)
        {
            // Create boolean variable to set it value to false
            bool Success = false;

            MySqlConnection conn = DBConnection.GetConnection();

            String Sql = UPDATE_PRODUCT_QUANTITY;

            try
            {
                MySqlCommand cmd = new MySqlCommand(Sql, conn);
                cmd.Parameters.AddWithValue("@qty", NewQty);
                cmd.Parameters.AddWithValue("@id", ProductID);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader is null)
                {
                    Success = false;
                }
                if (reader.RecordsAffected > 0)
                {
                    Success = true;
                }


            }
            catch (MySqlException Exp)
            {
                Debug.WriteLine(Exp.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return Success;

        }

        public List<ShoppingCart> GetshoppingCarts()
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = GET_ALL_CUSTOMERS_ORDERS;

            List<ShoppingCart> carts = new List<ShoppingCart>();

            try
            {
                ShoppingCart cart = new ShoppingCart();

                MySqlCommand cmd = new MySqlCommand(SQl, conn);

                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int OrderId = Convert.ToInt32(reader["CartID"]);

                    int ProductID = Convert.ToInt32(reader["ProductID"]);

                    int UserID = Convert.ToInt32(reader["UserId"]);

                    //String FullName = reader["FullName"].ToString();

                    String Name = reader["ProductName"].ToString();
                     int OrderQuantity = Convert.ToInt32(reader["OrderQuantity"].ToString());
                    Decimal OrderPrice = (decimal)Convert.ToDouble(reader["Price"].ToString());

                    Byte[] ImageProd = (Byte[])reader["Image"];

                    Decimal TotalCost = (decimal)Convert.ToDouble(reader["TotalCost"].ToString());

                    //String Date = reader["Date"].ToString();
                    //Double TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());

                    carts.Add(new ShoppingCart(OrderId,  ProductID, UserID, Name, OrderQuantity, ImageProd, OrderPrice, TotalCost));
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if(conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return carts;
        }

        public bool PlaceOrder(ShoppingCart shoppingCart)
        {
            MySqlConnection conn = DBConnection.GetConnection();


            try
            {
                String SQL = ADD_NEW_CUSTOMER_ORDER;

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@userid", shoppingCart.UserID);
                cmd.Parameters.AddWithValue("@prodid", shoppingCart.ProductID);
                cmd.Parameters.AddWithValue("@user", shoppingCart.FullName);
                cmd.Parameters.AddWithValue("@name", shoppingCart.Name);
                cmd.Parameters.AddWithValue("@qty", shoppingCart.OrderQuantity);
                cmd.Parameters.AddWithValue("@price", shoppingCart.OrderPrice);
                cmd.Parameters.AddWithValue("@img", shoppingCart.ImageProd);
                cmd.Parameters.AddWithValue("@total", shoppingCart.TotalCost);
                cmd.Parameters.AddWithValue("@date", shoppingCart.Date);
                cmd.Parameters.AddWithValue("@amount", shoppingCart.TotalAmount);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader is null)
                {
                    return false;
                }
                if (reader.RecordsAffected > 0)
                {
                    return true;
                }
            }
            catch (InvalidOperationException exp)
            {
                Debug.Write(exp.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Clone();
                }
            }
            return false;
        }

        public User SearchCustomer(string SearchUserInfo)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQL = $"SELECT UserId, FullName FROM susers WHERE UserId LIKE '%{SearchUserInfo}%' OR FullName LIKE '%{SearchUserInfo}%'";

            DataTable dt = new DataTable();

            User user = new User();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(SQL, conn);

                conn.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    user.UserID = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    user.FullName = dt.Rows[0]["FullName"].ToString();
                   
                }
            }
            catch (Exception Exp)
            {
                Debug.WriteLine(Exp.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return user;
        }

        public Product SearchForProduct(string Search)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQL = $"SELECT ProductID, ProductName, Quantity, Price, Image FROM sproducts WHERE ProductID LIKE '%{Search}%' OR ProductName LIKE '%{Search}%'";

            DataTable dt = new DataTable();

            Product FoundProduct = new Product();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(SQL, conn);

                conn.Open();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    FoundProduct.ID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                    FoundProduct.ProductName = dt.Rows[0]["ProductName"].ToString();
                    FoundProduct.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                    FoundProduct.Price = (decimal)Convert.ToDouble(dt.Rows[0]["Price"].ToString());
       
                    FoundProduct.ImagePath = (byte[])dt.Rows[0]["Image"];
                }
            }
            catch (Exception Exp)
            {
                Debug.WriteLine(Exp.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return FoundProduct;
        }

        public List<ShoppingCart> GetCustomerShoppingCart(int UserID)
        {
            MySqlConnection conn = DBConnection.GetConnection();


            String SQL = "SELECT  OrderID, ProductID, UserID,  FullName,  Name, OrderQuantity, Price, Image,  TotalCost, Date,  SUM(OrderQuantity * Price) AS TotalAmount FROM   orders WHERE  UserId=@userid GROUP BY OrderID, ProductID, UserID,  FullName,  Name, OrderQuantity, Price, Image,  TotalCost, Date";



            List<ShoppingCart> carts = new List<ShoppingCart>();

            try
            {
                ShoppingCart cart = new ShoppingCart();

                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@userid", UserID);
                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int OrderId = Convert.ToInt32(reader["OrderID"]);

                    int ProductID = Convert.ToInt32(reader["ProductID"]);

                     UserID = Convert.ToInt32(reader["UserId"]);

                    String FullName = reader["FullName"].ToString();

                    String Name = reader["Name"].ToString();
                    int OrderQuantity = Convert.ToInt32(reader["OrderQuantity"].ToString());
                    Decimal OrderPrice = (decimal)Convert.ToDouble(reader["Price"].ToString());

                    Byte[] ImageProd = (Byte[])reader["Image"];

                    Decimal TotalCost = (decimal)Convert.ToDouble(reader["TotalCost"].ToString());

                    String Date = reader["Date"].ToString();
                    Double TotalAmount = Convert.ToDouble(reader["TotalAmount"].ToString());

                    carts.Add(new ShoppingCart(OrderId, UserID, ProductID, FullName, Name, OrderQuantity, OrderPrice, ImageProd, TotalCost, Date, TotalAmount));
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return carts;
        }

        //public bool UpdateCustomersOrder(ShoppingCart shoppingCart)
        //{
        //    MySqlConnection conn = DBConnection.GetConnection();


        //    try
        //    {
        //        String SQL = "UPDATE orders SET UserId=@userid,  ProductID=@prodid, FullName=@user, Name=@name, OrderQuantity=@qty, Price=@price, Image=@img, TotalCost=@total, Date=@date, TotalAmount=@amount WHERE OrderID=@id";

        //        MySqlCommand cmd = new MySqlCommand(SQL, conn);

        //        cmd.Parameters.AddWithValue("@id", shoppingCart.CartId);
        //        cmd.Parameters.AddWithValue("@userid", shoppingCart.UserID);
        //        cmd.Parameters.AddWithValue("@prodid", shoppingCart.ProductID);
        //        cmd.Parameters.AddWithValue("@user", shoppingCart.FullName);
        //        cmd.Parameters.AddWithValue("@name", shoppingCart.Name);
        //        cmd.Parameters.AddWithValue("@qty", shoppingCart.OrderQuantity);
        //        cmd.Parameters.AddWithValue("@price", shoppingCart.OrderPrice);
        //        cmd.Parameters.AddWithValue("@img", shoppingCart.ImageProd);
        //        cmd.Parameters.AddWithValue("@total", shoppingCart.TotalCost);
        //        cmd.Parameters.AddWithValue("@date", shoppingCart.Date);
        //        cmd.Parameters.AddWithValue("@amount", shoppingCart.TotalAmount);

        //        conn.Open();

        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        if (reader is null)
        //        {
        //            return false;
        //        }
        //        if (reader.RecordsAffected > 0)
        //        {
        //            return true;
        //        }
        //    }
        //    catch (InvalidOperationException exp)
        //    {
        //        Debug.Write(exp.Message);
        //    }
        //    finally
        //    {
        //        if (conn != null)
        //        {
        //            conn.Clone();
        //        }
        //    }
        //    return false;
        //}

        public bool IncreaseProduct(int ID, int IncreaseQty)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            bool SuccessFully = false;
            try
            {
                // Get the Actual Qty for the Product


                int CurrentQuantity = this.GetProductQuantity(ID);

                // Increase the Qty , after it has been deducted from Product store

                int NewQuantity = CurrentQuantity + IncreaseQty;

                // Update Product Qty

                SuccessFully = this.UpdateProductQuantity(ID, NewQuantity);
            }
            catch (Exception Exp)
            {
                Debug.WriteLine(Exp.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return SuccessFully;
        }

        public ShoppingCart GETCustomerOrderByID(int ORDERID)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQl = "SELECT * FROM carts WHERE UserID=@userid";
           // String SQL = "SELECT  OrderID, ProductID, UserID,  FullName,  Name, OrderQuantity, Price, Image,  TotalCost, Date,  SUM(OrderQuantity * Price) AS TotalAmount FROM   orders WHERE  UserId=@userid GROUP BY OrderID, ProductID, UserID,  FullName,  Name, OrderQuantity, Price, Image,  TotalCost, Date";



            // ShoppingCart carts = new ShoppingCart();

            try
            {
                ShoppingCart cart = new ShoppingCart();

                MySqlCommand cmd = new MySqlCommand(SQl, conn);
                cmd.Parameters.AddWithValue("@userid", ORDERID);
                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ORDERID = Convert.ToInt32(reader["OrderID"]);

                    int ProductID = Convert.ToInt32(reader["ProductID"]);

                    int USERID = Convert.ToInt32(reader["UserId"]);

                    String FullName = reader["FullName"].ToString();

                    String Name = reader["Name"].ToString();
                    int OrderQuantity = Convert.ToInt32(reader["OrderQuantity"].ToString());
                    Decimal  OrderPrice = (decimal)Convert.ToDouble(reader["Price"].ToString());

                    Byte[] ImageProd = (Byte[])reader["Image"];

                    Decimal TotalCost = (decimal)Convert.ToDouble(reader["TotalCost"].ToString());

                    String Date = reader["Date"].ToString();

                    Double TotalAmount = (double)(decimal)Convert.ToDouble(reader["TotalAmount"].ToString());

                    cart = new ShoppingCart(ORDERID, USERID, ProductID, FullName, Name, OrderQuantity, OrderPrice, ImageProd, TotalCost, Date, TotalAmount);

                    return cart;
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return null;
        }

        public int GetProductRowCount()
        {
            MySqlConnection conn = DBConnection.GetConnection();
            int count = 0;

            try
            {
                string SQL = "SELECT COUNT(*) FROM carts"; // Replace YourTableName with the name of your table.

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                conn.Open();

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    count = Convert.ToInt32(result);
                }
            }
            catch (Exception Exp)
            {
                Console.WriteLine("Error Message: " + Exp.Message); // Print out the error message for debugging.
                throw new InvalidOperationException("Error occurred while retrieving data from the database.", Exp);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return count;
        }

        public bool UpdateCustomersOrder(ShoppingCart shoppingCart)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            try
            {
                string SQL = "UPDATE carts SET   OrderQuantity = @qty, price = price - @price, TotalCost = @qty * price WHERE CartID = @id";

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", shoppingCart.CartId);
                // cmd.Parameters.AddWithValue("@prodid", shoppingCart.ProductID);
                cmd.Parameters.AddWithValue("@qty", shoppingCart.OrderQuantity);
                cmd.Parameters.AddWithValue("@price", shoppingCart.OrderPrice);

                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            catch (MySqlException exp)
            {
                Debug.Write("MySQL Exception: " + exp.Message);
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return false;
        }

        public ShoppingCart GetCartByName(string Name)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQL = GET_CARTITEMS_BYNAME;

            try
            {
                ShoppingCart cart = new ShoppingCart();

                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@name", Name);
                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ORDERID = Convert.ToInt32(reader["CartID"]);

                    int ProductID = Convert.ToInt32(reader["ProductID"]);

                    Name = reader["ProductName"].ToString();
                    int OrderQuantity = Convert.ToInt32(reader["OrderQuantity"].ToString());
                    Decimal OrderPrice = (decimal)Convert.ToDouble(reader["Price"].ToString());

                    Byte[] ImageProd = (Byte[])reader["Image"];

                    Decimal TotalCost = (decimal)Convert.ToDouble(reader["TotalCost"].ToString());

                    cart = new ShoppingCart(ORDERID, ProductID, Name, OrderQuantity, ImageProd, OrderPrice, TotalCost);

                    return cart;
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return null;
        }

        public bool PurchaseCartItem(ShoppingCart Cart)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    string SQL = "INSERT INTO carts(ProductID, UserID, ProductName, OrderQuantity, Price, Image, TotalCost) VALUES (@prodid, @userid, @name, @qty, @price, @img, @total)";

                    MySqlCommand cmd = new MySqlCommand(SQL, conn);

                    cmd.Parameters.AddWithValue("@userid", Cart.UserID);
                    cmd.Parameters.AddWithValue("@prodid", Cart.ProductID);
                    cmd.Parameters.AddWithValue("@name", Cart.Name);
                    cmd.Parameters.AddWithValue("@qty", Cart.OrderQuantity);
                    cmd.Parameters.AddWithValue("@price", Cart.OrderPrice);
                    cmd.Parameters.AddWithValue("@img", Cart.ImageProd);
                    cmd.Parameters.AddWithValue("@total", Cart.TotalCost);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
                catch (MySqlException exp)
                {
                    Debug.Write(exp.Message);
                }
            }
            return false;
        }

        public bool RemoveOrderCartItem(int ID)
        {
            bool Successfully = false;
            MySqlConnection conn = DBConnection.GetConnection();
            string SQL = "DELETE FROM carts WHERE CartID = @id";

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery(); // Use ExecuteNonQuery for DELETE operation

                if (rowsAffected > 0)
                {
                    Successfully = true;
                }
            }
            catch (Exception exp)
            {
                // Handle the exception appropriately
                Debug.WriteLine(exp.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return Successfully;
        }

        public ShoppingCart ShoppingCart(int ProductID)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQL = "SELECT * FROM carts WHERE ProductID=@prodid";

            try
            {
                ShoppingCart cart = new ShoppingCart();

                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@prodid", ProductID);
                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ORDERID = Convert.ToInt32(reader["CartID"]);

                     ProductID = Convert.ToInt32(reader["ProductID"]);

                   String Name = reader["ProductName"].ToString();
                    int OrderQuantity = Convert.ToInt32(reader["OrderQuantity"].ToString());
                    Decimal OrderPrice = (decimal)Convert.ToDouble(reader["Price"].ToString());

                    Byte[] ImageProd = (Byte[])reader["Image"];

                    Decimal TotalCost = (decimal)Convert.ToDouble(reader["TotalCost"].ToString());

                    cart = new ShoppingCart(ORDERID, ProductID, Name, OrderQuantity, ImageProd, OrderPrice, TotalCost);

                    return cart;
                }
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return null;
        }
    }
}
