using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SMLApplication.Data;
using SMLApplication.Web.Models;
using SMLApplication.Business;

namespace SMLApplication.Web.Controllers
{
    public class ChannelController : Controller
    {
        private SMLDBEntities Context = new SMLDBEntities();
        //
        // GET: /Channel/

        [HandleError(ExceptionType = typeof(NullReferenceException), View = "NullReferenceExceptionErrorPage")]
        public ActionResult Index()
        {
            // throw new Exception();
            ChannelModels model = new ChannelModels();
            IChannelManager manager = new ChannelManager();

            int doctorId = 1;

            //TODO Check whether the role id doctor
            if (doctorId == 1)
            {
                model.Appointments = manager.GetAppointmentsByDoctorId(doctorId);
            }
            //else if (pati)
            //{

            //}

            return View(model);
        }

        //
        // GET: /Channel/Details/5

        public ActionResult Details(int id)
        {
            Appointment appointment = Context.Appointments.Find(id);
            return View(appointment);
        }

        //
        // GET: /Channel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Channel/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            // TODO: Add insert logic here
            Appointment appointment = new Appointment();

            //TODO Get the current patient Id  from the session
            appointment.Patient_Id = 1;
            appointment.Doctor_Id = Int16.Parse(collection["Doctor_Id"]);

            Context.Appointments.Add(appointment);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }

        //
        // GET: /Channel/Edit/5

        public ActionResult Edit(int id)
        {
            Appointment appointment = Context.Appointments.Find(id);
            return View(appointment);
        }

        //
        // POST: /Channel/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Appointment appointment = Context.Appointments.Find(id);
                    appointment.Patient_Id = Int16.Parse(collection["Patient_Id"]);

                    UpdateModel(appointment);
                    Context.SaveChanges();

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Channel/Delete/5

        public ActionResult Delete(int id)
        {
            Appointment appointment = Context.Appointments.Find(id);
            return View(appointment);
        }

        //
        // POST: /Channel/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Appointment appointment = Context.Appointments.Find(id);

                if (appointment == null)
                    return View("NotFound");

                Context.Appointments.Remove(appointment);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
