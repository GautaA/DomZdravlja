using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.IService;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }
        public IActionResult Index()
        {
            List<DoctorViewModel> model = new List<DoctorViewModel>();

            foreach (Doctor d in doctorService.GetDoctors())
            {
                DoctorViewModel doctor = new DoctorViewModel
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    GodineIskustva = d.GodineIskustva
                };
                model.Add(doctor);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateDoc()
        {
            return View("~/Views/Doctor/Create.cshtml");
        }

        [HttpPost]
        public ActionResult CreateDoc(DoctorViewModel d)
        {
            Doctor doctor = new Doctor
            {
                FirstName = "Dr. " + d.FirstName,
                LastName = d.LastName,
                GodineIskustva = d.GodineIskustva,
            };

            doctorService.InsertDoctor(doctor);
            if (doctor.Id > 0)
            {
                return Redirect("~/Home/Index");
            }
            return View(d);
        }

        public ActionResult DetailsByPatientId(int id)
        {
            Doctor d = doctorService.GetDoctor(id);
            List<DoctorViewModel> model = new List<DoctorViewModel>();
            DoctorViewModel docToAdd = new DoctorViewModel
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                GodineIskustva = d.GodineIskustva
            };
            model.Add(docToAdd);
            return PartialView("_DoctorsByPatient", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DoctorViewModel d = new DoctorViewModel();
            if (id != 0)
            {
                Doctor doctor = doctorService.GetDoctor(id);
                d.Id = doctor.Id;
                d.FirstName = doctor.FirstName;
                d.LastName = doctor.LastName;
                d.GodineIskustva = doctor.GodineIskustva;
            }
            return View(d);
        }

        [HttpPost]
        public ActionResult Edit(DoctorViewModel d)
        {
            Doctor doctor = doctorService.GetDoctor(d.Id);
            doctor.Id = d.Id;
            doctor.FirstName = d.FirstName;
            doctor.LastName = d.LastName;
            doctor.GodineIskustva = d.GodineIskustva;

            doctorService.UpdateDoctor(doctor);
            if (doctor.Id > 0)
            {
                return Redirect("~/Home/Index");
            }
            return View(d);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            doctorService.DeleteDoctor(id);
            return Redirect("~/Home/Index");
        }

        public ActionResult BackToHome()
        {
            return Redirect("~/Home/Index");
        }
    }
}