using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IService;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPatientService patientService;
        private readonly IDoctorService doctorService;

        public HomeController(IPatientService patientService, IDoctorService doctorService)
        {
            this.patientService = patientService;
            this.doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            DoctorPatientViewModel model = new DoctorPatientViewModel();
            foreach (Patient current in patientService.GetUsers()) {
                model.Patients.Add(current);
            }

            foreach (Doctor current in doctorService.GetDoctors())
            {
                model.Doctors.Add(current);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Doctor> allDoctors = doctorService.GetDoctors().ToList();
            List<int> doctorIds = new List<int>();

            foreach (Doctor doctor in allDoctors)
            {
                doctorIds.Add(doctor.Id);
            }

            ViewBag.Ids = doctorIds;

            return View();
        }

        [HttpPost]
        public ActionResult Create(PatientViewModel p)
        {
            Patient patient = new Patient
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                PersonalID = p.PersonalID,
                DoctorId = p.DoctorId
            };

            patientService.InsertUser(patient);
            if (patient.Id > 0)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PatientViewModel p = new PatientViewModel();
            if (id != 0)
            {
                Patient patient = patientService.GetUser(id);
                p.Id = patient.Id;
                p.FirstName = patient.FirstName;
                p.LastName = patient.LastName;
                p.PersonalID = patient.PersonalID;
                p.DoctorId = patient.DoctorId;
            }

            List<Doctor> allDoctors = doctorService.GetDoctors().ToList();
            List<int> doctorIds = new List<int>();

            foreach(Doctor doctor in allDoctors)
            {
                doctorIds.Add(doctor.Id);
            }

            ViewBag.Ids = doctorIds;

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(PatientViewModel p)
        {
            Patient patient = patientService.GetUser(p.Id);
            patient.Id = p.Id;
            patient.FirstName = p.FirstName;
            patient.LastName = p.LastName;
            patient.PersonalID = p.PersonalID;
            patient.DoctorId = p.DoctorId;

            patientService.UpdateUser(patient);
            if (patient.Id > 0)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            patientService.DeleteUser(id);
            return RedirectToAction("Index");
        }

        
        public ActionResult DetailsByDoctorId(int id)
        {
            List<PatientViewModel> model = new List<PatientViewModel>();

            foreach (Patient p in patientService.GetUsers())
            {
                if (p.DoctorId == id)
                {
                    PatientViewModel patient = new PatientViewModel
                    {
                        Id = p.Id,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        PersonalID = p.PersonalID
                    };
                    model.Add(patient);
                }
            };
            return PartialView("~/Views/Home/_PatientsByDoctor.cshtml", model);
        }

    }
}