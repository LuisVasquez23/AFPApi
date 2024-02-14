using Domain.Entities.Vehiculo;

namespace Application.Services.Vehiculo.Commands.CreateVehiculoCommand
{
    public class CreateVehiculoCommand : ICreateVehiculoCommand
    {
        private readonly IDatabaseServices _databaseServices;

        public CreateVehiculoCommand(IDatabaseServices databaseServices)
        {
            _databaseServices = databaseServices;
        }

        public async Task<VehiculoEntity> Execute(VehiculoEntity model)
        {
            await _databaseServices.Vehiculos.AddAsync(model);
            await _databaseServices.SaveAsync();
            return model;
        }
    }
}
