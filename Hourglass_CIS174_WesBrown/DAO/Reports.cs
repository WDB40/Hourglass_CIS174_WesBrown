﻿using Hourglass_CIS174_WesBrown.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hourglass_CIS174_WesBrown.DAO
{
    public class Reports
    {
        public List<Employee> Employees { get; set; }
        public List<WeeklyHours> WeeklyHours { get; set; }
        public List<PtoRequest> PtoRequests { get; set; }
    }
}
