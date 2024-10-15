using HairSalon.Core.Contracts;
using HairSalon.Core.Contracts.Repositories;
using HairSalon.Core.Contracts.Services;
using HairSalon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Service
{
    public class EmployeeScheduleService : IEmployeeScheduleService
    {
        private readonly IEmployeeScheduleRepository _employeeScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeScheduleService(IEmployeeScheduleRepository employeeScheduleRepository, IUnitOfWork unitOfWork)
        {
            _employeeScheduleRepository = employeeScheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Core.Entities.EmployeeSchedule> GetAll()
        {
            return _employeeScheduleRepository.GetAll().ToList();
        }

        public async Task<Core.Entities.EmployeeSchedule> GetScheduleById(int id)
        {
            return await _employeeScheduleRepository.Get(s => s.Id == id);
        }
    }
}
