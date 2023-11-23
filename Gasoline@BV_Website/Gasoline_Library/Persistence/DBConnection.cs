

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Stock_Inventory_Library.Persistence
{
    using MySql.Data.MySqlClient; // Make sure to include the MySql.Data library

    public class DBConnection
    {
        //public static MySqlConnection GetConnection()
        //{
        //    string server = "mysqltutorial.mysql.database.azure.com"; //"your_server.mysql.database.azure.com";
        //    string database = "projects"; // Replace with your database name
        //    string username = "Success"; // Replace with your username
        //    string password = "Server123@"; // Replace with your password
        //    string sslMode = "Required";
        //    string port = "3306";// Change this to "Required" if SSL is required, otherwise, use "None"



        //    string connectionString = $"Server={server};Database={database};User Id={username};Password={password};SslMode={sslMode};Port={port};";

        //    MySqlConnection conn = new MySqlConnection(connectionString);

        //    return conn;
        //}


        //public class DBConnection
        //{
        //   // private static string connectionString = "Server=localhost;Port=3306;Database=projects;Uid=root;Pwd=1234;";

        //    public static MySqlConnection GetConnection()
        //    {
        //        string server = "your_server.mysql.database.azure.com";
        //        string database = "$users";
        //        string username = "Success";
        //        string password = "Server123@";
        //        string SslMode = "Required";
        //        MySqlConnection conn =
        //              new MySqlConnection($"Server ={server}; Database ={ database}; User Id = { username }; Password ={ password}; SslMode = {SslMode};");///("Server=localhost;Port=3306;Database=projects;Uid=root;Pwd=1234;");

        //        return conn;

        //    }

        //try
        //{
        //    MySqlConnection conn = new MySqlConnection("server=localhost;database=projects;user=root;password=1234;port=3306;");
        //    return conn;
        //}
        //catch (Exception ex)
        //{
        //    // Handle the exception, log it, or display an error message.
        //    Console.WriteLine("An error occurred: " + ex.Message);
        //    return null;
        //}
        //MySqlConnection conn =

        //    new MySqlConnection("server=localhost;database=projects;user=root;password=1234");

        //return conn;

        public static MySqlConnection GetConnection()
        {
            string server = "localhost";
            string database = "minor";
            string username = "root";
            string password = "1234";
            string port = "3306";

            string connectionString = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password};";
            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }

        //MySqlConnection conn =

        //    new MySqlConnection("server=localhost;database=projects;user=root;password=1234");

        //return conn;






    


public static string HashPasswordMD5(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password), "Password cannot be null.");
            }

            using (MD5 md5 = MD5.Create())
            {
                if (md5 == null)
                {
                    throw new Exception("MD5 hashing is not available.");
                }

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = md5.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

 
        }
    }










