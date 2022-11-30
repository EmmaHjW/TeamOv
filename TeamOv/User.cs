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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int UserId { get; init; }
        public bool Active { get; set; }
        public bool IsAdmin { get; init; }
        public string LoggedInUser { get; set; }
        public User(string? userName, string? password, string firstName, string lastName, bool active)
        {
            UserId = idPool++;
            UserName = userName;
            Password = password;
            Active = active;
            IsAdmin = IsAdmin;
            FirstName = firstName;
            LastName = lastName;
        }

        public User()
        {
        }
        public static void InitiateUsers() //Adds users to userList at run
        {
            Admin.adminList.Add(new Admin("Admin", "password","Team", "OV", true));
            User customer1 = new User() { UserId = idPool++,UserName = "Oskar", Password = "1234", FirstName = "Oskar", LastName = "Ullsten", Active = true };
            User customer2 = new User() { UserId = idPool++,UserName = "Emma", Password = "1234", FirstName = "Emma", LastName = "Hjalmarsson", Active = true };
            User.customerList.Add(customer1);
            User.customerList.Add(customer2);
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
