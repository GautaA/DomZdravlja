using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainLayer.Entities;

namespace DomainLayer.EntityMaps
{
    public class DoctorMap
    {
        public DoctorMap(EntityTypeBuilder<Doctor> entityBuilder)
        {
            entityBuilder.HasKey(lambda => lambda.Id);
            entityBuilder.Property(lambda => lambda.FirstName).IsRequired();
            entityBuilder.Property(lambda => lambda.LastName).IsRequired();
            entityBuilder.Property(lambda => lambda.GodineIskustva).IsRequired();
        }
    }
}
