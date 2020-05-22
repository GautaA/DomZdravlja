using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IService
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctor(int id);
        void InsertDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int id);
    }
}
