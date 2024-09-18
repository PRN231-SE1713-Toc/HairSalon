using HairSalon.Core.Contracts;
using HairSalon.Core.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HairSalonDbContext _dbContext;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IServiceRepository _serviceRepository;

        public UnitOfWork(
            HairSalonDbContext dbContext,
            IAppointmentRepository appointmentRepository,
            ICustomerRepository customerRepository,
            IEmployeeRepository employeeRepository,
            IServiceRepository serviceRepository)
        {
            _dbContext = dbContext;
            _appointmentRepository = appointmentRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _serviceRepository = serviceRepository;
        }

        public IAppointmentRepository AppointmentRepository => _appointmentRepository;

        public ICustomerRepository CustomerRepository => _customerRepository;

        public IEmployeeRepository EmployeeRepository => _employeeRepository;

        public IServiceRepository ServiceRepository => _serviceRepository;

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        // Remove the entity from DbContext
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        // Reload the entity's data from the database
                        entry.Reload();
                        break;
                }
            }
            await SaveAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
