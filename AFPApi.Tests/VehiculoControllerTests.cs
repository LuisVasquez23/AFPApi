using Application.Services.Vehiculo.Commands.CreateVehiculoCommand;
using Application.Services.Vehiculo.Commands.DeleteVehiculoCommand;
using Application.Services.Vehiculo.Commands.UpdateVehiculoCommand;
using Application.Services.Vehiculo.Queries.GetVehiculosQuery;
using Domain.Entities.Vehiculo;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using WebApi.Controllers;

namespace AFPApi.Tests
{
    [TestClass]
    public class VehiculoControllerTests
    {
        // EXITO
        [TestMethod]
        public async Task Get_DeberiaDevolverListaDeVehiculos_CuandoSeLlama()
        {
            // Arrange
            var mockQuery = new Mock<IGetVehiculosQuery>();
            var vehiculos = new List<VehiculoEntity>
            {
                new VehiculoEntity { NumeroDePlaca = "ABC123", Marca = "Toyota" },
                new VehiculoEntity { NumeroDePlaca = "XYZ789", Marca = "Honda" }
            };
            mockQuery.Setup(query => query.Execute()).ReturnsAsync(vehiculos);
            var controller = new VehiculoController();

            // Act
            var resultado = await controller.Get(mockQuery.Object) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(StatusCodes.Status200OK, resultado.StatusCode);

            var baseResponse = resultado.Value as BaseResponseModel;
            Assert.IsNotNull(baseResponse);
            Assert.IsTrue(baseResponse.Success);
            Assert.AreEqual("Success", baseResponse.Message);

            var data = baseResponse.Data as List<VehiculoEntity>;
            Assert.IsNotNull(data);
            CollectionAssert.AreEqual(vehiculos, data);
        }

        [TestMethod]
        public async Task Create_DeberiaCrearVehiculo_CuandoSeLlama()
        {
            // Arrange
            var mockCommand = new Mock<ICreateVehiculoCommand>();
            var nuevoVehiculo = new VehiculoEntity { NumeroDePlaca = "ABC123", Marca = "Toyota" };
            mockCommand.Setup(cmd => cmd.Execute(nuevoVehiculo)).ReturnsAsync(nuevoVehiculo);
            var controller = new VehiculoController();

            // Act
            var resultado = await controller.Create(nuevoVehiculo, mockCommand.Object) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(StatusCodes.Status200OK, resultado.StatusCode);

            var baseResponse = resultado.Value as BaseResponseModel;
            Assert.IsNotNull(baseResponse);
            Assert.IsTrue(baseResponse.Success);
            Assert.AreEqual("Success", baseResponse.Message);

            var data = baseResponse.Data as VehiculoEntity;
            Assert.IsNotNull(data);
            Assert.AreEqual(nuevoVehiculo, data);
        }

        [TestMethod]
        public async Task Update_DeberiaActualizarVehiculo_CuandoSeLlama()
        {
            // Arrange
            var mockCommand = new Mock<IUpdateVehiculoCommand>();
            var vehiculoActualizado = new VehiculoEntity { NumeroDePlaca = "ABC123", Marca = "Toyota", Color = "Rojo" };
            mockCommand.Setup(cmd => cmd.Execute(vehiculoActualizado)).ReturnsAsync(vehiculoActualizado);
            var controller = new VehiculoController();

            // Act
            var resultado = await controller.Update(vehiculoActualizado, mockCommand.Object) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(StatusCodes.Status200OK, resultado.StatusCode);

            var baseResponse = resultado.Value as BaseResponseModel;
            Assert.IsNotNull(baseResponse);
            Assert.IsTrue(baseResponse.Success);
            Assert.AreEqual("Updated", baseResponse.Message);

            var data = baseResponse.Data as VehiculoEntity;
            Assert.IsNotNull(data);
            Assert.AreEqual(vehiculoActualizado, data);
        }

        [TestMethod]
        public async Task Delete_DeberiaEliminarVehiculo_CuandoSeLlama()
        {
            // Arrange
            var mockCommand = new Mock<IDeleteVehiculoCommand>();
            mockCommand.Setup(cmd => cmd.Execute("ABC123")).ReturnsAsync(true);
            var controller = new VehiculoController();

            // Act
            var resultado = await controller.Delete("ABC123", mockCommand.Object) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(StatusCodes.Status200OK, resultado.StatusCode);

            var baseResponse = resultado.Value as BaseResponseModel;
            Assert.IsNotNull(baseResponse);
        }

        // ERROR
        [TestMethod]
        public async Task Create_DeberiaDevolverBadRequest_CuandoLaCreacionFalla()
        {
            // Arrange
            var mockCommand = new Mock<ICreateVehiculoCommand>();
            mockCommand.Setup(cmd => cmd.Execute(It.IsAny<VehiculoEntity>())).ThrowsAsync(new ApplicationException("Error al crear el veh�culo"));
            var controller = new VehiculoController();

            // Act
            var resultado = await controller.Create(new VehiculoEntity(), mockCommand.Object) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(StatusCodes.Status400BadRequest, resultado.StatusCode);
        }

        [TestMethod]
        public async Task Delete_DeberiaDevolverInternalServerError_CuandoLaEliminacionFalla()
        {
            // Arrange
            var mockCommand = new Mock<IDeleteVehiculoCommand>();
            mockCommand.Setup(cmd => cmd.Execute(It.IsAny<string>())).ThrowsAsync(new Exception("Error al eliminar el veh�culo"));
            var controller = new VehiculoController();

            // Act
            var resultado = await controller.Delete("ABC123", mockCommand.Object) as ObjectResult;

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, resultado.StatusCode);
        }
    }
}