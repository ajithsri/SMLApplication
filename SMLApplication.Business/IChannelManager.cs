﻿using System;
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
    }
}
