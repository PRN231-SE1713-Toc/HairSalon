using HairSalon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Core.Contracts.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task UpdateAsync(Customer customer);
    }
}
