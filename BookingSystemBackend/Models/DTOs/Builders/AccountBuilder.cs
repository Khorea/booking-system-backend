using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs.Builders
{
    public class AccountBuilder
    {
        public static Account ToAccount(User user)
        {
            return new Account(user.Username, user.Password, user.Role, false);
        }

        public static Account ToAccount(LoginDTO loginDTO)
        {
            return new Account(loginDTO.Username, loginDTO.Password, null, false);
        }
    }
}
