using Microsoft.EntityFrameworkCore;
using Test2WebApp.Models;
//using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

namespace Test2WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1 , Name="Action" , DisplayOder=1 },
                new Category { Id=2, Name="Romance" , DisplayOder=2 },
                new Category { Id=3, Name="Sci-Fi" , DisplayOder=3}
                );
        }
    }
}
