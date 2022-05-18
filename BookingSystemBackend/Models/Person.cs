using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(320)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string PhoneNumber { get; set; }

        [ForeignKey("Account"), Column(TypeName = "nvarchar(30)")]
        public string Username { get; set; }

        public Account Account { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Person()
        {

        }

        public Person(int personId, string name, string address, string email, string username, Account account, ICollection<Booking> bookings)
        {
            PersonId = personId;
            Name = name;
            Address = address;
            Email = email;
            Username = username;
            Account = account;
            Bookings = bookings;
        }
    }
}
