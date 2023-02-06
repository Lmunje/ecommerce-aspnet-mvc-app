using onlineTickets.Data.Base;
using onlineTickets.Models;

namespace onlineTickets.Data.Services
{
    public class ProducersService: EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) :base(context) 
        {
        }
    }
}
