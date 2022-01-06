using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs.Builders
{
    public class PersonBuilder
    {
        public static Person ToPerson(User user)
        {
            return new Person(0,
                              user.Name,
                              user.Address,
                              user.Email,
                              user.Username,
                              AccountBuilder.ToAccount(user),
                              null
            );
        }
    }
}
