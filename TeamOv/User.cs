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
        public static List<User> customerList = new();

        private static int idPool;      
        protected bool isAdmin;
        protected string username;
        protected string password;

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int UserId { get; init; }
        public bool Active { get; set; }
        public bool IsAdmin { get; init; }
        protected User(string? userName, string? password, bool active)
        {
            this.UserId = idPool++;
            this.UserName = userName;
            this.Password = password;
            this.Active = active;
            this.IsAdmin = IsAdmin;
            

        }

        public User()
        {
        }

        public static bool UserExists(string username) //Checks so not dublicate new customer
        {
            bool exists = customerList.Exists(User=>User.UserName == username );
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
