﻿using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public interface IPersonRepository : IRepository<Person>
    {
        public Task<Person> GetByUsername(string username);
    }
}
