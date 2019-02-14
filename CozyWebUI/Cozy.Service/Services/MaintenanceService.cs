using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;

namespace Cozy.Service.Services
{

    public interface IMaintenanceService
    {
        //Read
        Maintenance GetById(int maintenanceId);
        ICollection<Maintenance> GetMaintenancesByHomeId(int homeId);
        ICollection<Maintenance> GetMaintenancesByTenantId(string tenantId);
        ICollection<Maintenance> GetMaintenancesByMaintenanceStatusId(int maintenanceStatusId);

        //Create 
        Maintenance Create(Maintenance newMaintenance);

        //Update
        Maintenance Update(Maintenance updatedMaintenance);

        //Delete
        bool DeleteById(int MaintenanceId);
    }
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        private MaintenanceService(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public Maintenance Create(Maintenance newMaintenance)
        {


            return _maintenanceRepository.Create(newMaintenance);
        }

        public bool DeleteById(int maintenanceId)
        {
            return _maintenanceRepository.DeleteById(maintenanceId);
        }

        public Maintenance GetById(int maintenanceId)
        {
            return _maintenanceRepository.GetById(maintenanceId);
        }

        public ICollection<Maintenance> GetMaintenancesByHomeId(int homeId)
        {
            return _maintenanceRepository.GetMaintenancesByHomeId(homeId);
        }

        public ICollection<Maintenance> GetMaintenancesByMaintenanceStatusId(int maintenanceStatusId)
        {
            return _maintenanceRepository.GetMaintenancesByMaintenanceStatusId(maintenanceStatusId);
        }

        public ICollection<Maintenance> GetMaintenancesByTenantId(string tenantId)
        {
            return _maintenanceRepository.GetMaintenancesByTenantId(tenantId);
        }

        public Maintenance Update(Maintenance updatedMaintenance)
        {
            return _maintenanceRepository.Update(updatedMaintenance);
        }
    }
}
