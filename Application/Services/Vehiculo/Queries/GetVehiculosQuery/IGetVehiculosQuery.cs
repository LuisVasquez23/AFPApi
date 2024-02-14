using Domain.Entities.Vehiculo;

namespace Application.Services.Vehiculo.Queries.GetVehiculosQuery
{
    public interface IGetVehiculosQuery
    {
        Task<List<VehiculoEntity>> Execute();
    }
}
