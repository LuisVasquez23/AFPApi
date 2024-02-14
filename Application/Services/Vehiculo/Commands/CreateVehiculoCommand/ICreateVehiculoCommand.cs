using Domain.Entities.Vehiculo;

namespace Application.Services.Vehiculo.Commands.CreateVehiculoCommand
{
    public interface ICreateVehiculoCommand
    {
        Task<VehiculoEntity> Execute(VehiculoEntity model);
    }
}
