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
            var idAdmin = Guid.NewGuid();

            var rolAdmin = new RolEntity
            {
                Id = idAdmin,
                Nombre = "Admin",
                EsBorrado = false
            };

            modelBuilder.Entity<RolEntity>().HasData(rolAdmin);

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = Guid.NewGuid(),
                UserName = "Emmanuel_Rojas",
                Nombre = "Emmanuel",
                Password = "password",
                IdRol = idAdmin,
                EsBorrado = false
            });
        }
    }
}