using Application.Services.Vehiculo.Commands.CreateVehiculoCommand;
using Application.Services.Vehiculo.Commands.DeleteVehiculoCommand;
using Application.Services.Vehiculo.Commands.UpdateVehiculoCommand;
using Application.Services.Vehiculo.Queries.GetVehiculosQuery;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            // Persona
            services.AddTransient<ICreateVehiculoCommand, CreateVehiculoCommand>();
            services.AddTransient<IUpdateVehiculoCommand, UpdateVehiculoCommand>();
            services.AddTransient<IDeleteVehiculoCommand, DeleteVehiculoCommand>();
            services.AddTransient<IGetVehiculosQuery, GetVehiculosQuery>();

            return services;
        }
    }
}
