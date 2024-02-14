using Application.Services;
using Domain.Entities.Vehiculo;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;

namespace Persistence.DataBase
{
    public class AFPContext : DbContext , IDatabaseServices
    {

        public AFPContext(DbContextOptions options) : base(options) { 
            
        }

        public DbSet<VehiculoEntity> Vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new VehiculoConfiguration(modelBuilder.Entity<VehiculoEntity>());
        }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
