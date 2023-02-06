using Microsoft.EntityFrameworkCore;
using onlineTickets.Data.Base;
using onlineTickets.Models;

namespace onlineTickets.Data.Services
{
    public class ActorsService :EntityBaseRepository<Actor> ,  IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }

    }
}

