using BookingSystemBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
	public interface IConnectionRepository : IRepository<Connection>
	{
		public Task<List<Connection>> GetAllIncludeEverythingAsync();
	}
}
