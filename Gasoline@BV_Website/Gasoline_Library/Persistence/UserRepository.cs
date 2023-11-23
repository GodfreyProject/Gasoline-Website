
using Gasoline_Library.Business.Logic;
using GasolineBV_Library.Business.Logic;
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

    public class UserRepository : IUserRepository
    {
        private String ADD_NEW_USER = "INSERT INTO users(FullName, UserName, Email, Password, Zipcode,Photo, Role)VALUES(@full, @user, @email, @pass,@zip, @img, @role)";

        private String GET_ALL_USERS = "SELECT * FROM users";

        private String GET_USER_BYID = "SELECT * FROM users WHERE UserId=@id";

       private String GET_USERNAME_AND_PASSWORD = "SELECT UserId, FullName, UserName, Email, Password, Photo, Role FROM users WHERE UserName=@user AND Password=@pass";

        private String GET_USER_BY_USERNAME = "SELECT * FROM users WHERE UserName=@user";

        private String UPDATE_NEW_USER = "UPDATE users SET FullName=@full, UserName=@user, Email=@email, Photo=@img, Role=@role WHERE UserId=@id";

        private String REMOVE_USER = "DELETE FROM users WHERE UserId=@id";

       
        public bool AddNewUser(User user)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            try
            {
                String SQL = ADD_NEW_USER;

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@full", user.FullName);
                cmd.Parameters.AddWithValue("@user", user.UserName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@pass", DBConnection.HashPasswordMD5(user.Password));
                cmd.Parameters.AddWithValue("@zip", user.Zipcode);
                cmd.Parameters.AddWithValue("@img", user.Photo);

                cmd.Parameters.AddWithValue("@role", user.Role);

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

            return false;
        }

        public bool DeleteUser(int UserID)
        {
            bool Successfully = false;

            MySqlConnection conn = DBConnection.GetConnection();

            String SQL = REMOVE_USER;

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", UserID);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader is null)
                {
                    Successfully = false;
                }

                if (reader.RecordsAffected > 0)
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
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return Successfully;
        }

        public List<User> GetAllUsers()
        {
            MySqlConnection conn = DBConnection.GetConnection();

            List<User> users = new List<User>();

            try
            {
                String SQL = GET_ALL_USERS;

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                conn.Open();



                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["UserId"]);

                    String FullName = reader["FullName"].ToString();
                    String UserName = reader["UserName"].ToString();
                    String Email = reader["Email"].ToString();
                    String Password = reader["Password"].ToString();
                    String Zipcode = reader["Zipcode"].ToString();
                    Byte[] Photo = (byte[])reader["Photo"];
                    String Role = reader["Role"].ToString();

                    users.Add(new User(ID, FullName, UserName,Email, Password,Zipcode, Photo, Role ));
                }


            }
            catch (InvalidOperationException Exp)
            {
                Debug.WriteLine(Exp.Message);
            }
            catch (Exception exp)
            {

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return users;
        }

        public User GetUser(int ID)
        {

            MySqlConnection conn = DBConnection.GetConnection();

            User user = new User();

            try
            {
                String SQL = GET_USER_BYID;

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@id", ID);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ID = Convert.ToInt32(reader["UserId"]);

                    String FullName = reader["FullName"].ToString();
                    String UserName = reader["UserName"].ToString();
                    String Email = reader["Email"].ToString();
                    String Password = reader["Password"].ToString();
                    String Zipcode = reader["Zipcode"].ToString();
                    Byte[] Photo = (byte[])reader["Photo"];
                    String Role = reader["Role"].ToString();

                    user = new User(ID, FullName, UserName, Email, Password,Zipcode, Photo, Role);

                    return user;
                }
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
            return null;
        }
        public User GetUserByUserName(string Username)
        {
            MySqlConnection conn = DBConnection.GetConnection();
           
            try
            {
                string sql = GET_USER_BY_USERNAME;

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@user", Username);
               
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                User person;

                while (reader.Read())
                {
                    if (reader[7].ToString() == "Admin")
                    {
                        person = new Admin(
                            Convert.ToInt32(reader[0]),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                             reader[5].ToString(),
                             (byte[])reader[6],
                            reader[7].ToString());

                        return person;
                    }
                    else if (reader[7].ToString() == "Consumer")
                    {
                        person = new Customer(
                            Convert.ToInt32(reader[0]),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                             reader[5].ToString(),
                            (byte[])reader[6],
                            reader[7].ToString());

                        return person;
                    }

                    else if (reader[7].ToString() == "Retailer")
                    {
                        person = new Retailer(
                            Convert.ToInt32(reader[0]),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                             reader[5].ToString(),
                            (byte[])reader[6],
                            reader[7].ToString());

                        return person;
                    }

                    else if (reader[7].ToString() == "WareHouse-Manager")
                    {
                        person = new WareHouse_Manager(
                            Convert.ToInt32(reader[0]),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                             reader[5].ToString(),
                            (byte[])reader[6],
                            reader[7].ToString());

                        return person;
                    }
                    else if (reader[7].ToString() == "Sales-Manager")
                    {
                        person = new Sales_Manager(
                            Convert.ToInt32(reader[0]),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                             reader[5].ToString(),
                            (byte[])reader[6],
                            reader[7].ToString());

                        return person;
                    }
                    else if (reader[7].ToString() == "Production-Manager")
                    {
                        person = new Production_Manager(
                            Convert.ToInt32(reader[0]),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                             reader[5].ToString(),
                            (byte[])reader[6],
                            reader[7].ToString());

                        return person;
                    }

                    else if (reader[7].ToString() == "Financial-Manager")
                    {
                        person = new Financial_Manager(
                            Convert.ToInt32(reader[0]),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                             reader[5].ToString(),
                            (byte[])reader[6],
                            reader[7].ToString());

                        return person;
                    }

                    else if (reader[7].ToString() == "Supplier")
                    {
                        person = new Supplier(
                            Convert.ToInt32(reader[0]),
                            reader[1].ToString(),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            reader[4].ToString(),
                             reader[5].ToString(),
                            (byte[])reader[6],
                            reader[7].ToString());

                        return person;
                    }
                }
            }
            catch (MySqlException a)
            { Debug.WriteLine(a.Message); }
            catch (Exception a)
            { Debug.WriteLine(a.Message); }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return null;
        }

        public User GetUserInfo(String UserName, String Password)
        {
            MySqlConnection conn = DBConnection.GetConnection();
            User foundUser = null; // Initialize a separate variable to store the found user

            try
            {
                conn.Open(); // Open the connection

                string sql = "SELECT * FROM  users WHERE UserName = @user AND Password = @pass";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@user",UserName);
                cmd.Parameters.AddWithValue("@pass", DBConnection.HashPasswordMD5(Password));

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Check if a record was found
                    {
                        string role = reader["Role"].ToString();
                        if (role == "Admin-Manager")
                        {
                            foundUser = new Admin();
                        }
                        else if (role == "Consumer")
                        {
                            foundUser = new Customer();
                        }

                        else if (role == "Retailer")
                        {
                            foundUser = new Retailer();
                        }
                        else if (role == "Production-Manager")
                        {
                            foundUser = new Production_Manager();
                        }
                        else if (role == "WareHouse-Manager")
                        {
                            foundUser = new WareHouse_Manager();
                        }
                        else if (role == "Sales-Manager")
                        {
                            foundUser = new Sales_Manager();
                        }
                        else if (role == "Financial-Manager")
                        {
                            foundUser = new Financial_Manager();
                        }
                        else if (role == "Supplier")
                        {
                            foundUser = new Supplier();
                        }
                        else
                        {
                            throw new InvalidOperationException("Invalid user type.");
                        }

                        // Populate the common properties
                        foundUser.UserID = Convert.ToInt32(reader["UserId"]);
                        foundUser.FullName = reader["FullName"].ToString();
                        foundUser.UserName = reader["UserName"].ToString();
                        foundUser.Email = reader["Email"].ToString();
                        foundUser.Password = reader["Password"].ToString();
                        foundUser.Photo = (byte[])reader["Photo"];
                        foundUser.Role = role;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred: " + ex.ToString());
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close(); // Close the connection in the finally block
                }
            }

            return foundUser; // Return the found user or null if not found
        }





        //MySqlConnection conn = DBConnection.GetConnection();

        //try
        //{
        //    string sql = GET_USERNAME_AND_PASSWORD;

        //    MySqlCommand cmd = new MySqlCommand(sql, conn);

        //    cmd.Parameters.AddWithValue("@user", UserName);
        //    cmd.Parameters.AddWithValue("@pass", Password);

        //    conn.Open();

        //    MySqlDataReader reader = cmd.ExecuteReader();

        //    User person;

        //    while (reader.Read())
        //    {
        //        if (reader[6].ToString() == "Admin")
        //        {
        //            person = new Admin(
        //                Convert.ToInt32(reader[0]),
        //                reader[1].ToString(),
        //                reader[2].ToString(),
        //                reader[3].ToString(),
        //                reader[4].ToString(),
        //                 (byte[])reader[5],
        //                reader[6].ToString());

        //            return person;
        //        }
        //         if (reader[6].ToString() == "Customer")
        //        {
        //            person = new Customer(
        //                Convert.ToInt32(reader[0]),
        //                reader[1].ToString(),
        //                reader[2].ToString(),
        //                reader[3].ToString(),
        //                reader[4].ToString(),
        //                (byte[])reader[5],
        //                reader[6].ToString());

        //            return person;
        //        }
        //        else
        //        {
        //            throw new InvalidOperationException("Error");
        //        }
        //    }
        //}
        ////catch (MySqlException a)
        ////{ Debug.WriteLine(a.Message); }
        //catch (Exception a)
        //{ Debug.WriteLine(a.Message); }
        //finally
        //{
        //    if (conn != null)
        //    {
        //        conn.Close();
        //    }
        //}
        //return null;
        //}

        public User SearchUser(string Search)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            String SQL = $"SELECT * FROM susers WHERE UserId LIKE '%{Search}%' OR FullName LIKE '%{Search}%'";

            DataTable dt = new DataTable();

            User user = new User();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(SQL, conn);

                conn.Open();
                adapter.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    user.UserID = Convert.ToInt32(dt.Rows[0]["UserId"]);
                    user.FullName = dt.Rows[0]["FullName"].ToString();
                    user.UserName = dt.Rows[0]["UserName"].ToString();
                    user.Email = dt.Rows[0]["Email"].ToString();
                    user.Password = dt.Rows[0]["Password"].ToString();
                    user.Photo = (byte[])dt.Rows[0]["Photo"];
                }
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

            return user;
        }

        public bool UpdateNewUser(User user)
        {
            MySqlConnection conn = DBConnection.GetConnection();

            try
            {
                String SQL = UPDATE_NEW_USER;

                MySqlCommand cmd = new MySqlCommand(SQL, conn);

                cmd.Parameters.AddWithValue("@full", user.FullName);
                cmd.Parameters.AddWithValue("@user", user.UserName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@pass", DBConnection.HashPasswordMD5(user.Password));
                cmd.Parameters.AddWithValue("@img", user.Photo);

                cmd.Parameters.AddWithValue("@role", user.Role);

                cmd.Parameters.AddWithValue("@id", user.UserID);

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

            return false;
        }
    }
}
