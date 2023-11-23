using Gasoline_Library.Business.Logic;
using MySql.Data.MySqlClient;
using Stock_Inventory_Library.Persistence.ReposInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace Stock_Inventory_Library.Persistence
{
    public class ProductRepository : IProductRepository
    {
        //private String ADD_PRODUCT = "INSERT INTO product(ProductName, Description, Material, Origin, Quantity, CostPrice,Price, ProductType, Image)VALUES(@name,@descr, @mat, @ori, @qty, @cp, @price, @type, @img)";

        //private String GET_ALL_PRODUCTS = "SELECT * FROM product";

        //private String GET_PRODUCT_BYID = "SELECT * FROM product WHERE ProductID=@prodid";

        private String GET_PRODUCT_BYNAME = "SELECT * FROM product WHERE ProductName=@name";

        public String UPDATE_PRODUCT = "UPDATE product SET ProductName=@name, Quantity=@qty, CostPrice=@cp, Price=@price, ProductType=@type, Image=@img WHERE ProductID=@id";

        public String DELETE_PRODUCT = "DELETE FROM product WHERE ProductID=@prodid";

        public String GET_PRODUCT_QUANTITY = "SELECT Quantity FROM product WHERE ProductID=@id";

        public String UPDATE_PRODUCT_QUANTITY = "UPDATE product SET Quantity=@qty WHERE ProductID=@id";

        public bool AddNewProduct(Product newProduct)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            try
            {
                string SQL = "INSERT INTO sproducts (FabricType, QualityAndDurability, Comfort, ColourAndPattern, Quantity, CostPrice, Price, Sustainability, MaintenanceAndCare, OriginAndManufacturingProcess, HypoallergenicProperties, Versatility, ReviewsAndRecommendations, BrandReputation, ReturnAndExchangePolicies, CertificationsAndLabels, Availability, Image, ProductName) " +
                             "VALUES (@fabricType, @qualityAndDurability, @comfort, @colourAndPattern, @quantity, @costPrice, @price, @sustainability, @maintenanceAndCare, @originAndManufacturingProcess, @hypoallergenicProperties, @versatility, @reviewsAndRecommendations, @brandReputation, @returnAndExchangePolicies, @certificationsAndLabels, @availability, @img, @name)";

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@fabricType", newProduct.FabricType);
                cmd.Parameters.AddWithValue("@qualityAndDurability", newProduct.QualityAndDurability);
                cmd.Parameters.AddWithValue("@comfort", newProduct.Comfort);
                cmd.Parameters.AddWithValue("@colourAndPattern", newProduct.ColourAndPattern);
                cmd.Parameters.AddWithValue("@quantity", newProduct.Quantity);
                cmd.Parameters.AddWithValue("@costPrice", newProduct.CostPrice);
                cmd.Parameters.AddWithValue("@price", newProduct.Price);
                cmd.Parameters.AddWithValue("@sustainability", newProduct.Sustainability);
                cmd.Parameters.AddWithValue("@maintenanceAndCare", newProduct.MaintenanceAndCare);
                cmd.Parameters.AddWithValue("@originAndManufacturingProcess", newProduct.OriginAndManufacturingProcess);
                cmd.Parameters.AddWithValue("@hypoallergenicProperties", newProduct.HypoallergenicProperties);
                cmd.Parameters.AddWithValue("@versatility", newProduct.Versatility);
                cmd.Parameters.AddWithValue("@reviewsAndRecommendations", newProduct.ReviewsAndRecommendations);
                cmd.Parameters.AddWithValue("@brandReputation", newProduct.BrandReputation);
                cmd.Parameters.AddWithValue("@returnAndExchangePolicies", newProduct.ReturnAndExchangePolicies);
                cmd.Parameters.AddWithValue("@certificationsAndLabels", newProduct.CertificationsAndLabels);
                cmd.Parameters.AddWithValue("@availability", newProduct.Availability);
                cmd.Parameters.AddWithValue("@img", newProduct.ImagePath);
                cmd.Parameters.AddWithValue("@name", newProduct.ProductName);

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
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return false;
        }

        public bool DeleteProduct(int ID)
        {
            bool Successfully = false;

            MySqlConnection conn = DBConnection.GetConnection();

            String SQL = DELETE_PRODUCT;

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", ID);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if(reader is null)
                {
                    Successfully = false;
                }

                if(reader.RecordsAffected > 0)
                {
                    Successfully = true;
                }
            }
            catch (InvalidOperationException Exp)
            {
                Debug.WriteLine(Exp.Message);
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return Successfully;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();
            MySqlConnection conn = DBConnection.GetConnection();

            try
            {
                string SQL = "SELECT * FROM sproducts";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ID = reader.GetInt32("ProductID"),
                        FabricType = reader.GetString("FabricType"),
                        QualityAndDurability = reader.GetString("QualityAndDurability"),
                        Comfort = reader.GetString("Comfort"),
                        ColourAndPattern = reader.GetString("ColourAndPattern"),
                        Quantity = reader.GetInt32("Quantity"),
                        CostPrice = reader.GetDecimal("CostPrice"),
                        Price = reader.GetDecimal("Price"),
                        Sustainability = reader.GetString("Sustainability"),
                        MaintenanceAndCare = reader.GetString("MaintenanceAndCare"),
                        OriginAndManufacturingProcess = reader.GetString("OriginAndManufacturingProcess"),
                        HypoallergenicProperties = reader.GetString("HypoallergenicProperties"),
                        Versatility = reader.GetString("Versatility"),
                        ReviewsAndRecommendations = reader.GetString("ReviewsAndRecommendations"),
                        BrandReputation = reader.GetString("BrandReputation"),
                        ReturnAndExchangePolicies = reader.GetString("ReturnAndExchangePolicies"),
                        CertificationsAndLabels = reader.GetString("CertificationsAndLabels"),
                        Availability = reader.GetString("Availability"),
                        ImagePath = (Byte[])reader["Image"],
                        ProductName = reader.GetString("ProductName"), 
                    };
                    productList.Add(product);
                }
            }
            catch (MySqlException exp)
            {
                Debug.Write(exp.Message);
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return productList;
        }


        public Product GetProduct(int ID)
        {
            MySqlConnection conn = DBConnection.GetConnection();
           // Product product = null;

            try
            {
                String SQL = "SELECT * FROM sproducts WHERE ProductID=@prodid";
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@prodid", ID);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ID = reader.GetInt32("ProductID"),
                        FabricType = reader.GetString("FabricType"),
                        QualityAndDurability = reader.GetString("QualityAndDurability"),
                        Comfort = reader.GetString("Comfort"),
                        ColourAndPattern = reader.GetString("ColourAndPattern"),
                        Quantity = reader.GetInt32("Quantity"),
                        CostPrice = reader.GetDecimal("CostPrice"),
                        Price = reader.GetDecimal("Price"),
                        Sustainability = reader.GetString("Sustainability"),
                        MaintenanceAndCare = reader.GetString("MaintenanceAndCare"),
                        OriginAndManufacturingProcess = reader.GetString("OriginAndManufacturingProcess"),
                        HypoallergenicProperties = reader.GetString("HypoallergenicProperties"),
                        Versatility = reader.GetString("Versatility"),
                        ReviewsAndRecommendations = reader.GetString("ReviewsAndRecommendations"),
                        BrandReputation = reader.GetString("BrandReputation"),
                        ReturnAndExchangePolicies = reader.GetString("ReturnAndExchangePolicies"),
                        CertificationsAndLabels = reader.GetString("CertificationsAndLabels"),
                        Availability = reader.GetString("Availability"),
                        ImagePath = (Byte[])reader["Image"],
                        ProductName = reader.GetString("ProductName"),
                    };
                    return product;
                }
            }
            catch (MySqlException exp)
            {
                Debug.Write(exp.Message);
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            
            return null; // return null if no product is found
        }


        public Product GetProductByName(string ProductName)
        {
            MySqlConnection conn = DBConnection.GetConnection();

           // Product product = new Product();

            try
            {
                String SQL = GET_PRODUCT_BYNAME;

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@name", ProductName);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ID = reader.GetInt32("ProductID"),
                        FabricType = reader.GetString("FabricType"),
                        QualityAndDurability = reader.GetString("QualityAndDurability"),
                        Comfort = reader.GetString("Comfort"),
                        ColourAndPattern = reader.GetString("ColourAndPattern"),
                        Quantity = reader.GetInt32("Quantity"),
                        CostPrice = reader.GetDecimal("CostPrice"),
                        Price = reader.GetDecimal("Price"),
                        Sustainability = reader.GetString("Sustainability"),
                        MaintenanceAndCare = reader.GetString("MaintenanceAndCare"),
                        OriginAndManufacturingProcess = reader.GetString("OriginAndManufacturingProcess"),
                        HypoallergenicProperties = reader.GetString("HypoallergenicProperties"),
                        Versatility = reader.GetString("Versatility"),
                        ReviewsAndRecommendations = reader.GetString("ReviewsAndRecommendations"),
                        BrandReputation = reader.GetString("BrandReputation"),
                        ReturnAndExchangePolicies = reader.GetString("ReturnAndExchangePolicies"),
                        CertificationsAndLabels = reader.GetString("CertificationsAndLabels"),
                        Availability = reader.GetString("Availability"),
                        ImagePath = (byte[])reader["Image"],
                        ProductName = reader.GetString("ProductName"),

                       
                    };
                    return product;
                }
            }
            catch (MySqlException exp)
            {
                Debug.Write(exp.Message);
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
          
            return null;
        }

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
                if(conn != null)
                {
                    conn.Close();
                }
            }

            return SuccessFully;
        }

        public Product SearchProduct(string Search)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQL = $"SELECT * FROM product WHERE ProductID LIKE '%{Search}%' OR ProductName LIKE '%{Search}%'";

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
                   // FoundProduct.Price = Convert.ToDouble(dt.Rows[0]["Price"].ToString());
                   //FoundProduct.ProductType = dt.Rows[0]["ProductType"].ToString();
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

        public bool UpdateProuct(Product product)
        {
            MySqlConnection conn = DBConnection.GetConnection();


            try
            {
                String SQL = UPDATE_PRODUCT;

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@name", product.ProductName);
                cmd.Parameters.AddWithValue("@qty", product.Quantity);
                cmd.Parameters.AddWithValue("@price", product.Price);
               // cmd.Parameters.AddWithValue("@type", product.ProductType);
                cmd.Parameters.AddWithValue("@img", product.ImagePath);
                cmd.Parameters.AddWithValue("@id", product.ID);

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

                if(dt.Rows.Count > 0)
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
                if(conn != null)
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

                if(reader is null)
                {
                    Success = false;
                }
                if(reader.RecordsAffected > 0)
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
                if(conn != null)
                {
                    conn.Close();
                }
            }

            return Success;
        }

        public List<Product> GetProductsBYID(string Search)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQL = $"SELECT * FROM product WHERE ProductID LIKE '%{Search}%' OR ProductName LIKE '%{Search}%'";

            DataTable dt = new DataTable();

            List<Product> products = new List<Product>();

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
                   // FoundProduct.Price = Convert.ToDouble(dt.Rows[0]["Price"].ToString());
                    //FoundProduct.ProductType = dt.Rows[0]["ProductType"].ToString();
                    FoundProduct.ImagePath = (byte[])dt.Rows[0]["Image"];

                    products.Add(FoundProduct);
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

            return products;
        }

        public List<Product> SearchProducts(string search)
        {
            List<Product> productList = new List<Product>();
            MySqlConnection conn = DBConnection.GetConnection();

            try
            {
                string SQL = @"SELECT ProductID, ProductName, FabricType, QualityAndDurability, Comfort, 
        ColourAndPattern, Quantity, CostPrice, Price, Sustainability, MaintenanceAndCare, 
        OriginAndManufacturingProcess, HypoallergenicProperties, Versatility, ReviewsAndRecommendations, 
        BrandReputation, ReturnAndExchangePolicies, CertificationsAndLabels, Availability, Image 
        FROM sproducts 
        WHERE ProductName LIKE @search 
        OR ProductID LIKE @search
        OR FabricType LIKE @search 
        OR QualityAndDurability LIKE @search 
        OR Comfort LIKE @search 
        OR ColourAndPattern LIKE @search 
        OR OriginAndManufacturingProcess LIKE @search 
        OR HypoallergenicProperties LIKE @search 
        OR Versatility LIKE @search 
        OR ReviewsAndRecommendations LIKE @search 
        OR BrandReputation LIKE @search 
        OR ReturnAndExchangePolicies LIKE @search 
        OR CertificationsAndLabels LIKE @search 
        OR Availability LIKE @search
        OR Quantity LIKE @search
        OR Price LIKE @search
        OR Image LIKE @search";

               

                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ID = reader.GetInt32("ProductID"),
                        ProductName = reader.GetString("ProductName"),
                        FabricType = reader.GetString("FabricType"),
                        QualityAndDurability = reader.GetString("QualityAndDurability"),
                        Comfort = reader.GetString("Comfort"),
                        ColourAndPattern = reader.GetString("ColourAndPattern"),
                        Quantity = reader.GetInt32("Quantity"),
                        CostPrice = reader.GetDecimal("CostPrice"),
                        Price = reader.GetDecimal("Price"),
                        Sustainability = reader.GetString("Sustainability"),
                        MaintenanceAndCare = reader.GetString("MaintenanceAndCare"),
                        OriginAndManufacturingProcess = reader.GetString("OriginAndManufacturingProcess"),
                        HypoallergenicProperties = reader.GetString("HypoallergenicProperties"),
                        Versatility = reader.GetString("Versatility"),
                        ReviewsAndRecommendations = reader.GetString("ReviewsAndRecommendations"),
                        BrandReputation = reader.GetString("BrandReputation"),
                        ReturnAndExchangePolicies = reader.GetString("ReturnAndExchangePolicies"),
                        CertificationsAndLabels = reader.GetString("CertificationsAndLabels"),
                        Availability = reader.GetString("Availability"),
                        ImagePath = (Byte[])reader["Image"]
                    };
                    productList.Add(product);
                }
            }
            catch (MySqlException exp)
            {
                Debug.Write(exp.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return productList;
        }

        public List<Stock> GetListAllProducts()
        {
            List<Stock> productList = new List<Stock>();

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                string query = "SELECT * FROM products";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stock product = new Stock()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Brand = reader["Brand"].ToString(),
                                Model = reader["Model"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                FabricType = reader["FabricType"].ToString(),
                                QualityAndDurability = reader["QualityAndDurability"].ToString(),
                                Comfort = reader["Comfort"].ToString(),
                                ColourAndPattern = reader["ColourAndPattern"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Sustainability = reader["Sustainability"].ToString(),
                                MaintenanceAndCare = reader["MaintenanceAndCare"].ToString(),
                                OriginAndManufacturingProcess = reader["OriginAndManufacturingProcess"].ToString(),
                                HypoallergenicProperties = reader["HypoallergenicProperties"].ToString(),
                                Versatility = reader["Versatility"].ToString(),
                                ReviewsAndRecommendations = reader["ReviewsAndRecommendations"].ToString(),
                                BrandReputation = reader["BrandReputation"].ToString(),
                                ReturnAndExchange = reader["ReturnAndExchange"].ToString(),
                                CertificationAndLabels = reader["CertificationAndLabels"].ToString(),
                                Availability = reader["Availability"].ToString()
                            };

                            productList.Add(product);
                        }
                    }
                }
            }

            return productList;
        }
    }
    }

