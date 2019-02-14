using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;

namespace Cozy.Data.Implementation.Mock
{
    public class MockMaintenanceRepository : IMaintenanceRepository
    {
        private List<Maintenance> Maintenances = new List<Maintenance>();

        public Maintenance Create(Maintenance newMaintenance)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int maintenanceId)
        {
            var maintenanceToDelete = GetById(maintenanceId);
            Maintenances.Remove(maintenanceToDelete);
            return true;
        }

        public Maintenance GetById(int maintenanceId)
        {
            return Maintenances.Single(m => m.Id == maintenanceId);
        }

        public ICollection<Maintenance> GetMaintenancesByHomeId(int homeId)
        {
            return Maintenances.FindAll(m => m.HomeId == homeId);
        }

        public ICollection<Maintenance> GetMaintenancesByMaintenanceStatusId(int maintenanceStatusId)
        {
            return Maintenances.FindAll(m => m.MaintenanceStatusId == maintenanceStatusId);
        }

        public ICollection<Maintenance> GetMaintenancesByTenantId(string tenantId)
        {
            return Maintenances.FindAll(m => m.TenantId == tenantId);
        }

        public Maintenance Update(Maintenance updatedMaintenance)
        {
            DeleteById(updatedMaintenance.Id);
            Maintenances.Add(updatedMaintenance);
            return updatedMaintenance;
        }
    }
}
