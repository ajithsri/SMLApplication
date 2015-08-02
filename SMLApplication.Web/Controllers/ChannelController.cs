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
        private ChannelModels channelModel;
        private IChannelManager channelManager;
        //
        // GET: /Channel/

        public ChannelController()
        {
            channelModel = new ChannelModels();
            channelManager = new ChannelManager();
        }

        [HandleError(ExceptionType = typeof(NullReferenceException), View = "NullReferenceExceptionErrorPage")]
        public ActionResult Index()
        {
            // throw new Exception();

            int doctorId = 1;

            //TODO Check whether the role id doctor
            if (doctorId == 1)
            {
                channelModel.Appointments = channelManager.GetAppointmentsByDoctorId(doctorId);
            }
            //else if (pati)
            //{

            //}

            return View(channelModel);
        }

        //
        // GET: /Channel/Details/5

        public ActionResult Details(int id)
        {
            channelModel.Appointment = channelManager.GetAppointmentByAppointmentId(id);
            return View(channelModel.Appointment);
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
            int patientId = Int16.Parse(collection["Patient_Id"]);
            int doctorId = Int16.Parse(collection["Doctor_Id"]);

            bool isCreated = channelManager.CreateAppointmentByPatientIdAndDoctorId(patientId, doctorId);
           
            return RedirectToAction("Index");
        }

        //
        // GET: /Channel/Edit/5

        public ActionResult Edit(int id)
        {
            channelModel.Appointment = channelManager.GetAppointmentByAppointmentId(id);

            return View(channelModel.Appointment);
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

                    int patientId = Int16.Parse(collection["Patient_Id"]);
                    int doctorId =  Int16.Parse(collection["Doctor_Id"]);

                    channelManager.UpdateAppointment(id, patientId, doctorId);
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
            channelModel.Appointment = channelManager.GetAppointmentByAppointmentId(id);
            return View(channelModel.Appointment);
        }

        //
        // POST: /Channel/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //int patientId = Int16.Parse(collection["Patient_Id"]);
                //int doctorId = Int16.Parse(collection["Doctor_Id"]);

                channelManager.DeleteAppointment(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
