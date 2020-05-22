using DomainLayer.Entities;
using RepositoryLayer;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Service
{
    public class DoctorService : IDoctorService
    {
        private IGenericRepository<Doctor> doctorRepository;

        public DoctorService(IGenericRepository<Doctor> doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return doctorRepository.GetAll();
        }

        public Doctor GetDoctor(int id)
        {
            return doctorRepository.Get(id);
        }

        public void InsertDoctor(Doctor doctor)
        {
            doctorRepository.Insert(doctor);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            doctorRepository.Update(doctor);
        }

        public void DeleteDoctor(int id)
        {

            Doctor doctor = GetDoctor(id);
            doctorRepository.Remove(doctor);
            doctorRepository.SaveChanges();
        }
    }
}
