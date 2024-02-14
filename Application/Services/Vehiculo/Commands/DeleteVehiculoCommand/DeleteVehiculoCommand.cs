using Domain.Entities.Vehiculo;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Vehiculo.Commands.DeleteVehiculoCommand
{
    public class DeleteVehiculoCommand : IDeleteVehiculoCommand
    {
        private readonly IDatabaseServices _databaseServices;

        public DeleteVehiculoCommand(IDatabaseServices databaseServices)
        {
            _databaseServices = databaseServices;
        }

        public async Task<bool> Execute(string numeroPlaca)
        {
            VehiculoEntity? vehiculo = await _databaseServices.Vehiculos.FirstOrDefaultAsync(x => x.NumeroDePlaca == numeroPlaca);

            if (vehiculo == null)
            {
                return false;
            }

            _databaseServices.Vehiculos.Remove(vehiculo);

            return await _databaseServices.SaveAsync();

        }
    }
}
