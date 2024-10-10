using Asp.Versioning;
using AutoMapper;
using HairSalon.Core.Contracts.Services;
using HairSalon.Core.Entities;
using HairSalon.Dto.Requests;
using HairSalon.Dto.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Api.Controllers.v1
{
    [Route("api/v{v:apiVersion}/prn231-hairsalon")]
    [ApiController]
    [ApiVersion(1)]
    public class HairServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHairServce _hairService;

        public HairServiceController(IMapper mapper, IHairServce hairService)
        {
            _mapper = mapper;
            _hairService = hairService;
        }

        /// <summary>
        /// Get all hair service
        /// </summary>
        /// <returns></returns>
        [HttpGet("service")]
        public ActionResult GetAllHairService()
        {
            var hairService = _hairService.GetServices();
            if (hairService == null)
            {
                return StatusCode(404);
            }

            return StatusCode(200, _mapper.Map<List<HairServiceDto>>(hairService));
        }

        /// <summary>
        /// Get hair service by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("service/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hairService = await _hairService.GetServicesById(id);
            if (hairService == null)
            {
                return StatusCode(404);
            }

            return StatusCode(200, _mapper.Map<HairServiceDto>(hairService));
        }

        [HttpPost("services")]
        public ActionResult Create(CreateServiceModel createServiceModel)
        {
            try
            {
                Core.Entities.Service service = new Core.Entities.Service
                {
                    Name = createServiceModel.Name,
                    Description = createServiceModel.Description,
                    Duration = createServiceModel.Duration,
                    Price = createServiceModel.Price,
                };

                _hairService.CreateService(service);
                return Ok(service);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while creating the service." });
            }
        }
    }
}
