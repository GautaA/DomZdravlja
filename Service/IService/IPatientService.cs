using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.IService
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetUsers();
        Patient GetUser(int id);
        void InsertUser(Patient user);
        void UpdateUser(Patient user);
        void DeleteUser(int id);
    }
}
