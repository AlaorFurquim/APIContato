using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;

namespace ContatoAPI.Models
{
    public class ContatoDbContext : DbContext
    {
        public ContatoDbContext(DbContextOptions<ContatoDbContext> Options)
            : base(Options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ConDb"));
        }

        


    }
   
}
