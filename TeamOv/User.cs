using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamOv
{
    public abstract class User
    {
        protected bool isAdmin;
        protected string username;
        protected string password;

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public int Tries { get; set; }
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { }
        }

        protected User(string? userName, string? password, int userId, bool active, bool IsAdmin)
        {
            this.UserName = userName;
            this.Password = password;
            this.UserId = userId;
            this.Active = active;
            this.IsAdmin = IsAdmin;
        }
        public override string ToString()
        {
            return $"userid: {UserId}, username: {UserName}, password: {Password}, active: {Active}";
        }
    }
}
