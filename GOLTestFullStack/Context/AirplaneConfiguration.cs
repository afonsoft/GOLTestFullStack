using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOLTestFullStack.Api.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GOLTestFullStack.Api.Context
{
    public class AirplaneConfiguration : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder
                .Property(q => q.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(q => q.CodAviao)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(q => q.Modelo)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(q => q.QtsPassageiros);

            builder
                .Property(q => q.DateCreate);

        }
    }
}
