﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMLApplication.Data;
using SMLApplication.Web.Models;
using SMLApplication.Business;

namespace SMLApplication.Web.Controllers
{
    public class ChannelController : Controller
    {
        //
        // GET: /Channel/

        public ActionResult Index()
        {
            ChannelModels model = new ChannelModels();
            IChannelManager manager = new ChannelManager();

            int doctorId = 1;
            model.Appointments = manager.GetAppointmentsByDoctorId(doctorId);

            return View(model);
        }

        //
        // GET: /Channel/Details/5

        public ActionResult Details(int id)
        {
            return View();
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
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Channel/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Channel/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        //
        // POST: /Channel/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}