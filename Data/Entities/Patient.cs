using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Entities
{
    public class Patient : SharedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string PersonalID { get; set; }
        [Required]
        public int DoctorId { get; set; }
    }
}
