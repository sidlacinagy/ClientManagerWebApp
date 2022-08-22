using ClientManager.Api.Entities;
using ClientManager.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace ClientManager.Api.Database
{
    public class ClientManagerDbContext : DbContext
    {
        public ClientManagerDbContext(DbContextOptions<ClientManagerDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Client { get; set; }
    }
}
