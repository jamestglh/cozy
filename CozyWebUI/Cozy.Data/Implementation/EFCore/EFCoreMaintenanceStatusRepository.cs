using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreMaintenanceStatusRepository : IMaintenanceStatusRepository
    {
        public MaintenanceStatus Create(MaintenanceStatus newMaintenanceStatus)
        {
            using (var db = new CozyDbContext())
            {
                db.MaintenanceStatuses.Add(newMaintenanceStatus);
                db.SaveChanges();

                return newMaintenanceStatus;
            }
        }

        public bool DeleteById(int maintenanceStatusId)
        {
            using (var db = new CozyDbContext())
            {
                var maintenanceStatusIdToDelete = GetById(maintenanceStatusId);
                db.Remove(maintenanceStatusIdToDelete);
                db.SaveChanges();

                if (GetById(maintenanceStatusId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public MaintenanceStatus GetById(int maintenanceStatusId)
        {
            using (var db = new CozyDbContext())
            {
                return db.MaintenanceStatuses.Single(l => l.Id == maintenanceStatusId);
            }
        }

        public MaintenanceStatus Update(MaintenanceStatus updatedMaintenanceStatus)
        {
            using (var db = new CozyDbContext())
            {
                var existingMaintenanceStatus = GetById(updatedMaintenanceStatus.Id);
                db.Entry(existingMaintenanceStatus).CurrentValues.SetValues(updatedMaintenanceStatus);
                db.SaveChanges();

                return existingMaintenanceStatus;
            }
        }
    }
}