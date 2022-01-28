using BookingSystemBackend.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public class EFCorePersonRepository : EFCoreRepository<Person, BookingSystemContext>, IPersonRepository
    {
        BookingSystemContext _context;

        public EFCorePersonRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAllWithAccounts()
        {
            return await _context.People.Include(x => x.Account).ToListAsync();
        }

        public async Task<Person> GetByUsername(string username)
        {
            return await _context.People
                .Where(p => p.Username.Equals(username))
                .Include(a => a.Account)
                .FirstOrDefaultAsync();
        }

        public void UpdatePersonDetails(int personId, string name, string address, string email, string username, string password, string role, string oldUsername)
        {
            var personIdParam = new SqlParameter("personId", personId);
            var nameParam = new SqlParameter("name", name);
            var addressParam = new SqlParameter("address", address);
            var emailParam = new SqlParameter("email", email);
            var usernameParam = new SqlParameter("username", username);
            var passwordParam = new SqlParameter("password", password);
            var roleParam = new SqlParameter("role", role);
            var oldUsernameParam = new SqlParameter("oldUsername", oldUsername);

            var connection = (SqlConnection)_context.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UpdatePersonDetailsProcedure";
            command.Parameters.Add(personIdParam);
            command.Parameters.Add(nameParam);
            command.Parameters.Add(addressParam);
            command.Parameters.Add(emailParam);
            command.Parameters.Add(usernameParam);
            command.Parameters.Add(passwordParam);
            command.Parameters.Add(roleParam);
            command.Parameters.Add(oldUsernameParam);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
