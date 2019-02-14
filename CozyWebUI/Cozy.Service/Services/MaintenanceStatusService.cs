using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;

namespace Cozy.Service.Services
{
    public interface IMaintenanceStatusService
    {
        //Read
        MaintenanceStatus GetById(int maintenanceStatusId);

        //Create 
        MaintenanceStatus Create(MaintenanceStatus newMaintenanceStatus);

        //Update
        MaintenanceStatus Update(MaintenanceStatus updatedMaintenanceStatus);

        //Delete
        bool DeleteById(int maintenanceStatusId);
    }

    public class MaintenanceStatusService : IMaintenanceStatusService
    {
        private readonly IMaintenanceStatusRepository _maintenanceStatusRepository;

        public MaintenanceStatusService(IMaintenanceStatusRepository maintenanceStatusRepository)
        {
            _maintenanceStatusRepository = maintenanceStatusRepository;
        }

        public MaintenanceStatus Create(MaintenanceStatus newMaintenanceStatus)
        {
            return _maintenanceStatusRepository.Create(newMaintenanceStatus);
        }

        public bool DeleteById(int maintenanceStatusId)
        {
            return _maintenanceStatusRepository.DeleteById(maintenanceStatusId);
        }

        public MaintenanceStatus GetById(int maintenanceStatusId)
        {
            return _maintenanceStatusRepository.GetById(maintenanceStatusId);
        }

        public MaintenanceStatus Update(MaintenanceStatus updatedMaintenanceStatus)
        {
            return _maintenanceStatusRepository.Update(updatedMaintenanceStatus);
        }
    }
}
