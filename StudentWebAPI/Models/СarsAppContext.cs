using Microsoft.EntityFrameworkCore;
using APICore.Models;

namespace WebAPI.Models
{
    public class СarsAppContext : DbContext
    {
        public DbSet<ModelsCar> ModelsCars { get; set; }
        public DbSet<Marks> MarksCars { get; set; }

        public СarsAppContext(DbContextOptions<СarsAppContext> options) : base(options)
        {

        }
    }
}
