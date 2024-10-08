using Asp.Versioning;
using AutoMapper;
using HairSalon.Core.Contracts.Services;
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
        private readonly IHairServce _hairServce;

        public HairServiceController(IMapper mapper, IHairServce hairServce)
        {
            _mapper = mapper;
            _hairServce = hairServce;
        }

        /// <summary>
        /// Get all hair service
        /// </summary>
        /// <returns></returns>
        [HttpGet("service")]
        public ActionResult GetAllHairService()
        {
            var hairService = _hairServce.GetServices();
            if (hairService == null)
            {
                return StatusCode(404);
            }

            return StatusCode(200, _mapper.Map<List<HairServiceDto>>(hairService));
        }
    }
}
