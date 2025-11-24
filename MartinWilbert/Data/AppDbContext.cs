using MartinWilbert.Models;
using Microsoft.EntityFrameworkCore;

namespace MartinWilbert.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasMany(e => e.Users).WithOne(u => u.Role).HasForeignKey(u => u.RoleId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Role>().HasData(

                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Usuario" }

            );
            base.OnModelCreating(modelBuilder);

        }
    }
}
