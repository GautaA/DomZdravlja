using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DoctorPatientViewModel
    {
        public DoctorPatientViewModel()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
        }
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
