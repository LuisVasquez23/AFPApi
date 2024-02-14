using Domain.Entities.Vehiculo;

namespace Application.Services.Vehiculo.Commands.UpdateVehiculoCommand
{
    public class UpdateVehiculoCommand : IUpdateVehiculoCommand
    {
        private readonly IDatabaseServices _databaseServices;

        public UpdateVehiculoCommand(IDatabaseServices databaseServices)
        {
            _databaseServices = databaseServices;
        }

        public async Task<VehiculoEntity> Execute(VehiculoEntity vehiculo)
        {
            _databaseServices.Vehiculos.Update(vehiculo);
            await _databaseServices.SaveAsync();
            return vehiculo;
        }
    }
}
