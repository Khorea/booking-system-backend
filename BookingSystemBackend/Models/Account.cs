using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
    public class Account
    {
        [Key, Column(TypeName = "nvarchar(30)")]
        public string Username { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Role { get; set; }

        public bool IsActive { get; set; }

        public Account(string username, string password, string role, bool isActive)
        {
            Username = username;
            Password = password;
            Role = role;
            IsActive = isActive;
        }
    }
}
