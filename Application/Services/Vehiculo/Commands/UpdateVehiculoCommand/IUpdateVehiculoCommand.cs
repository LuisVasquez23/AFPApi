using Domain.Entities.Vehiculo;

namespace Application.Services.Vehiculo.Commands.UpdateVehiculoCommand
{
    public interface IUpdateVehiculoCommand
    {
        Task<VehiculoEntity> Execute(VehiculoEntity vehiculo);
    }
}
