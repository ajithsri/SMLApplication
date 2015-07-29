using SMLApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMLApplication.Web.Models
{
    public class ChannelModels
    {
        public IList<Appointment> Appointments { get; set; }
    }
}