using SMLApplication.Business;
using SMLApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMLApplication.WebServices.Controllers
{
    public class AppointmentsController : ApiController, IChannelManager
    {
        private SMLDBEntities context = new SMLDBEntities();

        //// GET api/Values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/Channel/5
        //public string Get1(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/Channel/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/Channel/5
        //public void Delete(int id)
        //{
        //}

        // GET api/Appointments
        [HttpGet]
        public IList<Appointment> GetAppointments()
        {
            return context.Appointments.ToList();
        }

        [HttpGet]
        public Appointment GetAppointmentByAppointmentId(int id)
        {
            return context.Appointments.Find(id);
        }

        // GET api/Appointments/AppointmentsByDoctorId/5
        [HttpGet]
        [ActionName("AppointmentsByDoctorId")]
        public IList<Appointment> GetAppointmentsByDoctorId(int id)
        {
            return context.Appointments.Where(r => r.Doctor_Id == id).ToList();
        }

        // GET api/Appointments/AppointmentsByPatientId/5
        [HttpGet]
        [ActionName("AppointmentsByPatientId")]
        public IList<Appointment> GetAppointmentsByPatientId(int id)
        {
            return context.Appointments.Where(r => r.Patient_Id == id).ToList();
        }

        // GET api/Appointments/5
        public bool CreateAppointmentByPatientIdAndDoctorId(int patientId, int doctorId)
        {
            // TODO: Add insert logic here
            Appointment appointment = new Appointment();

            //TODO Get the current patient Id  from the session
            appointment.Patient_Id = patientId;
            appointment.Doctor_Id = doctorId;

            context.Appointments.Add(appointment);
            context.SaveChanges();
            return true;
        }

        public bool UpdateAppointment(int appointmentId, int patientId, int doctorId)
        {
            Appointment appointment = context.Appointments.Find(appointmentId);
            appointment.Patient_Id = patientId;
            appointment.Doctor_Id = doctorId;
            context.SaveChanges();

            return true;
        }

        public bool DeleteAppointment(int appointmentId)
        {
            Appointment appointment = context.Appointments.Find(appointmentId);
            context.Appointments.Remove(appointment);
            context.SaveChanges();

            return true;
        }
    }
}