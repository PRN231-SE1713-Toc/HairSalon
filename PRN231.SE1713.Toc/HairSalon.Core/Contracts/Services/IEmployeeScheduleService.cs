using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Core.Contracts.Services
{
    public interface IEmployeeScheduleService
    {
        List<Core.Entities.EmployeeSchedule> GetAll();
        Task<Core.Entities.EmployeeSchedule> GetScheduleById(int id);
    }
}
