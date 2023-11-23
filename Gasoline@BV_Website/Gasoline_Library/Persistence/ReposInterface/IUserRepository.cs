using Stock_Inventory_Library.Business.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Persistence.ReposInterface
{
   public interface IUserRepository
    {

        // Get All Users

        public List<User> GetAllUsers();

        // Get User By Id or Username


        public User GetUser(int ID);


        public User GetUserInfo(String UserName, String Password);


        public User GetUserByUserName(String Username);

        // Add New User

        public bool AddNewUser(User user);


        // UPdate User

        public bool UpdateNewUser(User user);


        // Delete User 


        public bool DeleteUser(int UserID);


        // Search By User

        public User SearchUser(String Search);

       
    }
}
