using Domain.Entities.Vehiculo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configuration
{
    public class VehiculoConfiguration
    {
        public VehiculoConfiguration(EntityTypeBuilder<VehiculoEntity> entityBuilder)
        {

            entityBuilder.HasKey(x => x.NumeroDePlaca);
            entityBuilder.Property(x => x.VIN).IsRequired();
            entityBuilder.Property(x => x.Marca).IsRequired();
            entityBuilder.Property(x => x.Serie).IsRequired();
            entityBuilder.Property(x => x.Anio);
            entityBuilder.Property(x => x.Color);
            entityBuilder.Property(x => x.CantidadDePuertas);

        }
    }
}
