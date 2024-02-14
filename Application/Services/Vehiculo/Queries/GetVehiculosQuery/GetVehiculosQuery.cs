using Domain.Entities.Vehiculo;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Vehiculo.Queries.GetVehiculosQuery
{
    public class GetVehiculosQuery : IGetVehiculosQuery
    {

        private readonly IDatabaseServices _databaseServices;

        public GetVehiculosQuery(IDatabaseServices databaseServices)
        {
            _databaseServices = databaseServices;
        }

        public async Task<List<VehiculoEntity>> Execute()
        {
            var listEntity = await _databaseServices.Vehiculos.ToListAsync();

            return listEntity;
        }

    }
}
