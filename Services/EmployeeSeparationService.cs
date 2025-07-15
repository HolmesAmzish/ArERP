using ArERP.Models.Entity;
using ArERP.Repository;
using System;
using System.Collections.Generic;

namespace ArERP.Services
{
    public class EmployeeSeparationService
    {
        private readonly IEmployeeSeparationRepository _repository;

        public EmployeeSeparationService(IEmployeeSeparationRepository repository)
        {
            _repository = repository;
        }

        public List<EmployeeSeparation> GetAllSeparations()
        {
            return _repository.GetAllEmployeeSeparations();
        }

        public EmployeeSeparation GetSeparationById(int id)
        {
            return _repository.GetEmployeeSeparationById(id);
        }

        public void AddSeparation(EmployeeSeparation separation)
        {
            _repository.AddEmployeeSeparation(separation);
        }

        public void UpdateSeparation(EmployeeSeparation separation)
        {
            _repository.UpdateEmployeeSeparation(separation);
        }

        public List<SeparationStatistics> GetSeparationStatistics(DateTime? startDate, DateTime? endDate, int? departmentId)
        {
            // Validate date range
            if (startDate.HasValue && endDate.HasValue && startDate > endDate)
            {
                throw new ArgumentException("开始日期不能晚于结束日期");
            }

            return _repository.GetSeparationStatistics(startDate, endDate, departmentId);
        }
    }
}
