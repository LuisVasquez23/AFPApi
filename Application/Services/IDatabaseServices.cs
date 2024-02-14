using Domain.Entities.Vehiculo;
using Microsoft.EntityFrameworkCore;


namespace Application.Services
{
    public interface IDatabaseServices
    {
        DbSet<VehiculoEntity> Vehiculos { get; set; }
        Task<bool> SaveAsync();
    }
}
