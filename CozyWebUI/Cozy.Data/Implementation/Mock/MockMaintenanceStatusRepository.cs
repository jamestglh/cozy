using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    

    public class MockMaintenanceStatusRepository : IMaintenanceStatusRepository
    {

        private List<MaintenanceStatus> MaintenanceStatuses = new List<MaintenanceStatus>();

        public MaintenanceStatus Create(MaintenanceStatus newMaintenanceStatus)
        {
            newMaintenanceStatus.Id = MaintenanceStatuses.OrderByDescending(m => m.Id).Single().Id + 1;
            MaintenanceStatuses.Add(newMaintenanceStatus);
            return newMaintenanceStatus;
        }

        public bool DeleteById(int maintenanceStatusId)
        {
            var maintenanceStatusToDelete = GetById(maintenanceStatusId);
            MaintenanceStatuses.Remove(maintenanceStatusToDelete);
            return true;  
        }

        public MaintenanceStatus GetById(int maintenanceStatusId)
        {
            return MaintenanceStatuses.Single(m => m.Id == maintenanceStatusId);
        }

        public MaintenanceStatus Update(MaintenanceStatus updatedMaintenanceStatus)
        {
            DeleteById(updatedMaintenanceStatus.Id);
            MaintenanceStatuses.Add(updatedMaintenanceStatus);
            return updatedMaintenanceStatus;
        }
    }
}
