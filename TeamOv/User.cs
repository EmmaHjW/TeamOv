using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace TeamOv
{
     
    public class User
    {
        public static List<User> CustomerList = new();

        private static int idPool;      
        protected bool isAdmin;
        protected string username;
        protected string password;

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int UserId { get; init; }
        public bool Active { get; set; }
        public int Tries { get; set; }
        public bool IsAdmin { get; init; }
        public User(string? userName, string? password, bool active)
        {
            this.UserName = userName;
            this.Password = password;
            this.Active = active;
            this.IsAdmin = IsAdmin;
            this.UserId = idPool++;

        }
           
        public static bool UserExists(string username) //Checks so not dublicate new customer
        {
            bool exists = CustomerList.Exists(User=>User.UserName == username );
            Log.Debug(
                "User with username {username} {existing}",
                username,
                (exists ? "exists." : "does not exist.")
            );

            return exists;
        }
        public override string ToString()
        {
            return $"userid: {UserId}, username: {UserName}, password: {Password}, active: {Active}, isAdmin: {IsAdmin}";
        }
        


    }
}
