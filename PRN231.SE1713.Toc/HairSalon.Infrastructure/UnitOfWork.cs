using HairSalon.Core.Contracts;

namespace HairSalon.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
