using AutoMapper;
using HairSalon.Core.Contracts;
using HairSalon.Core.Contracts.Repositories;
using HairSalon.Core.Contracts.Services;
using HairSalon.Core.Entities;
using HairSalon.Dto.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HairSalon.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Core.Entities.Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll().ToList();
        }


        public async Task<Core.Entities.Customer> GetCustomerById(int id)
        {
            return await _customerRepository.Get(e => e.Id == id);
        }

        // Update customer
        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await _unitOfWork.CustomerRepository.Get(c => c.Id == customer.Id);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            // Update the customer details from the incoming data
            existingCustomer.Name = customer.Name;
            existingCustomer.Address = customer.Address;
            existingCustomer.Email = customer.Email;
            existingCustomer.Password = customer.Password;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.DateOfBirth = customer.DateOfBirth;

            _customerRepository.Update(existingCustomer);
            await _unitOfWork.SaveAsync();
        }
    }
}
