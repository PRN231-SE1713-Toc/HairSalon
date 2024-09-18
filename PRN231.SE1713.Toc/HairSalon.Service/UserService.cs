using HairSalon.Core.Contracts;
using HairSalon.Core.Contracts.Repositories;
using HairSalon.Core.Contracts.Services;
using HairSalon.Core.Entities;

namespace HairSalon.Service
{
    public class UserService : IUserService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IEmployeeRepository employeeRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Customer?> AuthenticateForCustomer(string email, string password)
            => await _customerRepository.Get(c => c.Email == email && c.Password == password);

        public async Task<Employee?> AuthenticateForEmployee(string email, string password)
            => await _employeeRepository.Get(e => e.Email == email && e.Password == password);

        public async Task<Customer?> GetCustomer(int customerId)
            => await _customerRepository.FindAsync(customerId);

        public async Task<Employee?> GetEmployee(int employeeId)
            => await _employeeRepository.FindAsync(employeeId);

        public async Task UpdateRefreshTokenCustomer(int customerId, string refreshToken, DateTime date)
        {
            try
            {
                var customer = await GetCustomer(customerId);
                if (customer is not null)
                {
                    customer.RefreshToken = refreshToken;
                    customer.RefreshTokenExpiryTime = date;
                    _customerRepository.Update(customer);
                    await _unitOfWork.SaveAsync();
                }
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}

