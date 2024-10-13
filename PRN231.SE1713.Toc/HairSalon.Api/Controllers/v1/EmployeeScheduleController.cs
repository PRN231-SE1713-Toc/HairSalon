using Asp.Versioning;
using AutoMapper;
using HairSalon.Core.Contracts.Services;
using HairSalon.Dto.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Api.Controllers.v1
{
    [Route("api/v{v:apiVersion}/prn231-hairsalon")]
    [ApiController]
    [ApiVersion(1)]
    public class EmployeeScheduleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeScheduleService _employeeScheduleService;

        public EmployeeScheduleController(IMapper mapper, IEmployeeScheduleService employeeScheduleService)
        {
            _mapper = mapper;
            _employeeScheduleService = employeeScheduleService;
        }

        /// Get all schedule
        [HttpGet("schedule")]
        public ActionResult GetAllSchedule()
        {
            var schedules = _employeeScheduleService.GetAll();
            if (schedules == null)
            {
                return StatusCode(404);
            }

            return StatusCode(200, _mapper.Map<List<EmployeeScheduleDto>>(schedules));
        }

        /// Get schedule by id
        [HttpGet("schedule/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var schedules = await _employeeScheduleService.GetScheduleById(id);
            if (schedules == null)
            {
                return StatusCode(404);
            }

            return StatusCode(200, _mapper.Map<EmployeeScheduleDto>(schedules));
        }
    }
}
