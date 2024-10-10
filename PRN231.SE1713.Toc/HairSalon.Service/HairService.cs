using HairSalon.Core.Contracts.Repositories;
using HairSalon.Core.Contracts.Services;
using HairSalon.Core.Contracts;
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

        public Core.Entities.Service CreateService(Core.Entities.Service service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            if (string.IsNullOrWhiteSpace(service.Name) || service.Name.Length > 100)
                throw new ArgumentException("Service Name is required and cannot exceed 100 characters.");


            if (!string.IsNullOrEmpty(service.Description) && service.Description.Length > 500)
                throw new ArgumentException("Description cannot exceed 500 characters.");

            if (!string.IsNullOrEmpty(service.Duration))
            {
                var regex = new System.Text.RegularExpressions.Regex(@"^\d{1,3}:\d{2}$");
                if (!regex.IsMatch(service.Duration))
                    throw new ArgumentException("Duration must be in the format of HH:mm.");
            }

            if (service.Price < 0)
                throw new ArgumentException("Price must be greater than 0.");

            _serviceRepository.Add(service);

            return service;
        }

        public List<Core.Entities.Service> GetServices()
        {
            return _serviceRepository.GetAll().ToList();
        }

        public async Task<Core.Entities.Service> GetServicesById(int id)
        {
            return await _serviceRepository.Get(e => e.Id == id);
        }
    }
}
