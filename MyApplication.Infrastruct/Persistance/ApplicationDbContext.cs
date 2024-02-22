using Microsoft.EntityFrameworkCore;
using MyApplication.Domain.Entities.Models;

namespace MyApplication.Infrastruct.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }
        DbSet<Car> Cars { get; set; }
    }
}
