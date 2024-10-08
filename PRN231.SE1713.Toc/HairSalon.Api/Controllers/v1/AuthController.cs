using AutoMapper;
using HairSalon.Core.Contracts.Services;
using HairSalon.Dto;
using HairSalon.Dto.Requests;
using HairSalon.Dto.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HairSalon.Api.Controllers.v1
{
    public class AuthController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(
            IMapper mapper,
            IUserService userService,
            ITokenService tokenService)
        {
            _mapper = mapper;
            _userService = userService;
            _tokenService = tokenService;
        }
        
        /// <summary>
        /// Authenticate for customer
        /// </summary>
        /// <param name="requestModel"></param>
        [HttpPost("login-customer")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponseModel<string>))]
        public async Task<ActionResult<ApiResponseModel<UserResponseModel>>> LoginForCustomer([FromBody] LoginRequestModel requestModel)
        {
            var customer = await _userService.AuthenticateForCustomer(requestModel.Email, requestModel.Password);
            if (customer is null) return NotFound(new ApiResponseModel<string>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "User not found"
            });
            // Create claims for access token
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid, customer.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, customer.Name),
                new Claim(ClaimTypes.Email, customer.Email),
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var response = _mapper.Map<LoggedInUserModel>(customer);
            return Ok(new ApiResponseModel<UserResponseModel>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Login successfully",
                Data = new UserResponseModel
                {
                    User = response,
                    AccessToken = accessToken,
                }
            });
        }

        /// <summary>
        /// Authenticate for employee in HairSalon
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost("login-employee")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ApiResponseModel<string>))]
        public async Task<ActionResult<ApiResponseModel<UserResponseModel>>> LoginForEmployee([FromBody] LoginRequestModel requestModel)
        {
            var customer = await _userService.AuthenticateForEmployee(requestModel.Email, requestModel.Password);
            if (customer is null) return NotFound(new ApiResponseModel<string>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "User not found"
            });
            // Create claims for access token
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.PrimarySid, customer.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, customer.Name),
                new Claim(ClaimTypes.Email, customer.Email),
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var response = _mapper.Map<LoggedInUserModel>(customer);
            return Ok(new ApiResponseModel<UserResponseModel>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Login successfully",
                Data = new UserResponseModel
                {
                    User = response,
                    AccessToken = accessToken,
                }
            });
        }
    }
}
