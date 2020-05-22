using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Entities
{
    public class PatientMap
    {
        public PatientMap(EntityTypeBuilder<Patient> entityBuilder)
        {
            entityBuilder.HasKey(lambda => lambda.Id);
            entityBuilder.Property(lambda => lambda.FirstName).IsRequired();
            entityBuilder.Property(lambda => lambda.LastName).IsRequired();
            entityBuilder.Property(lambda => lambda.PersonalID).IsRequired();
        }
    }
}
