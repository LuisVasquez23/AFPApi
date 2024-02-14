using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Vehiculo
{
    [Table("Vehiculo")]
    public class VehiculoEntity
    {

        [Key]
        public string? NumeroDePlaca { get; set; }

        [Required(ErrorMessage = "El VIN es requerido.")]
        public string? VIN { get; set; }

        public string? Marca { get; set; }

        public string? Serie { get; set; }

        public int Anio { get; set; }

        public string? Color { get; set; }

        public int CantidadDePuertas { get; set; }

    }
}
