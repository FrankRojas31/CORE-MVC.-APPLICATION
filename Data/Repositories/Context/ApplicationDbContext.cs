using Biblioteca82.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca82.Data.Repositories.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Usuarios { get; set; }
        public DbSet<RolEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var rolAdmin = new RolEntity
            {
                Id = 1,
                Nombre = "Admin",
                EsBorrado = false
            };

            modelBuilder.Entity<RolEntity>().HasData(rolAdmin);

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = 1,
                UserName = "Emmanuel_Rojas",
                Nombre = "Emmanuel",
                Password = "password",
                IdRol = rolAdmin.Id,
                EsBorrado = false
            });
        }
    }
}