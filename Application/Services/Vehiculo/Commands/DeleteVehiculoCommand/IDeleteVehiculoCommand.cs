namespace Application.Services.Vehiculo.Commands.DeleteVehiculoCommand
{
    public interface IDeleteVehiculoCommand
    {
        Task<bool> Execute(string numeroPlaca);
    }
}
