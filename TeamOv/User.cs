using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public class User
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public int Tries { get; set; }

        public User(string? userName, string? password, int userId, bool active)
        {
            UserName = userName;
            Password = password;
            UserId = userId;
            Active = active;
        }
        public override string ToString()
        {
            return $"userid: {UserId}, username: {UserName}, password: {Password}, active: {Active}";
        }
    }
}
