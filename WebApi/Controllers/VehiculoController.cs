using Application.Exceptions;
using Application.Features;
using Application.Services.Vehiculo.Commands.CreateVehiculoCommand;
using Application.Services.Vehiculo.Commands.DeleteVehiculoCommand;
using Application.Services.Vehiculo.Commands.UpdateVehiculoCommand;
using Application.Services.Vehiculo.Queries.GetVehiculosQuery;
using Domain.Entities.Vehiculo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class VehiculoController : ControllerBase
    {

        public VehiculoController()
        {

        }

        [HttpGet("/api/v1/Vehiculos")]
        public async Task<IActionResult> Get([FromServices] IGetVehiculosQuery query)
        {
            var personas = await query.Execute();

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, personas, "Success"));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehiculoEntity vehiculoAdd, [FromServices] ICreateVehiculoCommand command)
        {
            var vehiculoAdded = await command.Execute(vehiculoAdd);
            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, vehiculoAdded, "Success"));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VehiculoEntity vehiculoUpdate, [FromServices] IUpdateVehiculoCommand command)
        {
            var vehiculoUpdated = await command.Execute(vehiculoUpdate);

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, vehiculoUpdated, "Updated"));
        }

        [HttpDelete("{numeroPlaca}")]
        public async Task<IActionResult> Delete(string numeroPlaca, [FromServices] IDeleteVehiculoCommand command)
        {
            if (numeroPlaca == null)
                return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status400BadRequest));

            var data = await command.Execute(numeroPlaca);

            if (!data)
            {
                return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status404NotFound, data));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiServices.Response(StatusCodes.Status200OK, null, "Success"));
        }
    }
}
