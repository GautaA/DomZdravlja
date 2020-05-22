using DomainLayer.Entities;
using RepositoryLayer;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Service
{
    public class PatientService : IPatientService
    {
        private IGenericRepository<Patient> patientRepository;

        public PatientService(IGenericRepository<Patient> patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetUsers()
        {
            return patientRepository.GetAll();
        }

        public Patient GetUser(int id)
        {
            return patientRepository.Get(id);
        }

        public void InsertUser(Patient patient)
        {
            patientRepository.Insert(patient);
        }
        public void UpdateUser(Patient patient)
        {
            patientRepository.Update(patient);
        }

        public void DeleteUser(int id)
        {
            Patient patient = GetUser(id);
            patientRepository.Remove(patient);
            patientRepository.SaveChanges();
        }
    }
}
