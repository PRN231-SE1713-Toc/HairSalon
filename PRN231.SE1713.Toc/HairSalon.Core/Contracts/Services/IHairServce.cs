﻿using HairSalon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Core.Contracts.Services
{
    public interface IHairServce
    {
        List<Service> GetServices();
        Task<Service> GetServicesById(int id);
        Service CreateService(Service service);
    }
}
