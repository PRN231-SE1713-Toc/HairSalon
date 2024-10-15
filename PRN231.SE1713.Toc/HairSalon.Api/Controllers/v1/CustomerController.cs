using AutoMapper;
using HairSalon.Core.Contracts.Services;
using HairSalon.Dto.Requests;
using HairSalon.Dto.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Api.Controllers.v1
{
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet("Customer")]
        public ActionResult GetAllCustomer()
        {
            var customer = _customerService.GetAllCustomers();
            if (customer == null)
            {
                return StatusCode(404);
            }

            return StatusCode(200, _mapper.Map<List<CustomerModel>>(customer));
        }

        /// <summary>
        /// Get By Id Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet("Customer/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return StatusCode(404);
            }

            return StatusCode(200, _mapper.Map<CustomerModel>(customer));
        }
        /// <summary>
        /// Update Customer
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerEntity = _mapper.Map<Core.Entities.Customer>(customerModel);
            try
            {
                await _customerService.UpdateAsync(customerEntity);
                return Ok(new { message = "Customer updated successfully" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Customer not found" });
            }
        }
    }
}
