using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Entities
{
    public class Doctor : SharedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GodineIskustva { get; set; }
    }
}
