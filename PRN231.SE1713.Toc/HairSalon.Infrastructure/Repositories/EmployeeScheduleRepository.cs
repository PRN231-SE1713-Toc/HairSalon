using HairSalon.Core.Contracts.Repositories;
using HairSalon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Infrastructure.Repositories
{
    public class EmployeeScheduleRepository : Repository<EmployeeSchedule>, IEmployeeScheduleRepository
    {
        public EmployeeScheduleRepository(HairSalonDbContext dbContext) : base(dbContext)
        {
        }
    }
}
