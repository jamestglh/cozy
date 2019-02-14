using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreMaintenanceRepository : IMaintenanceRepository
    {
        public Maintenance Create(Maintenance newMaintenance)
        {
            using (var db = new CozyDbContext())
            {
                db.Maintenances.Add(newMaintenance);
                db.SaveChanges();

                return newMaintenance;
            }
        }

        public bool DeleteById(int maintenanceId)
        {
            using (var db = new CozyDbContext())
            {
                var maintenanceToDelete = GetById(maintenanceId);
                db.Remove(maintenanceToDelete);
                db.SaveChanges();

                if (GetById(maintenanceId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public Maintenance GetById(int maintenanceId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Maintenances.Single(l => l.Id == maintenanceId);
            }
        }

        public ICollection<Maintenance> GetMaintenancesByHomeId(int homeId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Maintenances
                    .Where(m => m.HomeId == homeId)
                    .ToList();
            }
        }

        public ICollection<Maintenance> GetMaintenancesByMaintenanceStatusId(int maintenanceStatusId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Maintenances
                    .Where(m => m.MaintenanceStatusId == maintenanceStatusId)
                    .ToList();
            }
        }

        public ICollection<Maintenance> GetMaintenancesByTenantId(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Maintenances
                    .Where(m => m.TenantId == tenantId)
                    .ToList();
            }
        }

        public Maintenance Update(Maintenance updatedMaintenance)
        {
            using (var db = new CozyDbContext())
            {
                var existingMaintenance = GetById(updatedMaintenance.Id);
                db.Entry(existingMaintenance).CurrentValues.SetValues(updatedMaintenance);
                db.SaveChanges();

                return existingMaintenance;
            }
        }
    }
}
