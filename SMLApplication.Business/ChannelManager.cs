using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMLApplication.Data;

namespace SMLApplication.Business
{
    public class ChannelManager : IChannelManager
    {
        public IList<Data.Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            SMLDBEntities context = new SMLDBEntities();
            return context.Appointments.Where(r => r.Doctor_Id == doctorId).ToList();
        }
    }
}
