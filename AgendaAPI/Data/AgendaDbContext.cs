using AgendaAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Data
{
    public class AgendaDbContext : IdentityDbContext
    {      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"data source=DESKTOP-3QVKJ23;initial catalog=AgendaToolDbEF;trusted_connection=true;TrustServerCertificate=True;");
        }

        public DbSet<Agenda> Agendas { get; set; }
    }
}
