using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Dto.Responses
{
    public class EmployeeScheduleDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public DateOnly WorkingDate { get; set; }

        public TimeOnly WorkingStartTime { get; set; }

        public TimeOnly WorkingEndTime { get; set; }
    }
}
