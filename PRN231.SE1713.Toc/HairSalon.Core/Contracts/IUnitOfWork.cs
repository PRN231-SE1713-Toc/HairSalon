using HairSalon.Core.Contracts.Repositories;

namespace HairSalon.Core.Contracts
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task SaveAsync(CancellationToken cancellationToken = default);

        Task RollbackAsync(CancellationToken cancellationToken = default);

        IAppointmentRepository AppointmentRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        IEmployeeRepository EmployeeRepository { get; }

        IServiceRepository ServiceRepository { get; }
    }
}
