using HairSalon.Core.Entities;

namespace HairSalon.Core.Contracts.Services
{
    public interface IUserService
    {
        Task<Customer?> AuthenticateForCustomer(string email, string password);

        Task<Employee?> AuthenticateForEmployee(string email, string password);

        Task<Customer?> GetCustomer(int customerId);

        Task<Employee?> GetEmployee(int employeeId);

        Task UpdateRefreshTokenCustomer(int customerId, string refreshToken, DateTime date);
    }
}
