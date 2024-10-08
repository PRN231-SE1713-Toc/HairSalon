using HairSalon.Core.Contracts;
using HairSalon.Core.Contracts.Repositories;
using HairSalon.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Service
{
    public class HairService : IHairServce
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HairService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }
        public List<Core.Entities.Service> GetServices()
        {
            return _serviceRepository.GetAll().ToList();
        }

        public async Task<Core.Entities.Service> GetServicesById(int id)
        {
            return await _serviceRepository.FindAsync(id);
        }
    }
}
