using Microsoft.EntityFrameworkCore;
using ARinspection.Models;
namespace ARinspection.Data
{
    public class PecaContext : DbContext
    {
        public DbSet<PecaModel> people { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Data Source=pecas.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
