using Stock_Inventory_Library.Business.Logic;
using Stock_Inventory_Library.Persistence.ReposInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock_Inventory_Library.Business.ManagerClass
{
    public class UserManager : IUserRepository
    {
        private IUserRepository userRepository;


        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public bool AddNewUser(User user)
        {
            if (this.userRepository.AddNewUser(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(int UserID)
        {
            if (this.userRepository.DeleteUser(UserID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return this.userRepository.GetAllUsers();
        }

        public User GetUser(int ID)
        {
            return this.userRepository.GetUser(ID);
        }

        public User GetUserByUserName(string Username)
        {
            return this.userRepository.GetUserByUserName(Username);
        }

        public User GetUserInfo(String UserName, String Password)
        {
            User FoundUser = this.userRepository.GetUserInfo(UserName, Password);

            if(FoundUser != null)
            {
                return FoundUser; 
            }
            else
            {
                return null;
            }
        }

        public User SearchUser(string Search)
        {
            return this.userRepository.SearchUser(Search);
        }

        public bool UpdateNewUser(User user)
        {
            if (this.userRepository.UpdateNewUser(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
