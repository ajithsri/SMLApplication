using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMLApplication.Data;

namespace SMLApplication.Business
{
    public interface IChannelManager
    {
        IList<Appointment> GetAppointmentsByDoctorId(int doctorId);
        Appointment GetAppointmentByAppointmentId(int id);
        bool CreateAppointmentByPatientIdAndDoctorId(int patientId, int doctorId);

        bool UpdateAppointment(int appointmentId, int patientId, int doctorId);
        bool DeleteAppointment(int appointmentId);



    }
}
