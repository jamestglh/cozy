using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface IMaintenanceRepository
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
        bool DeleteById(int maintenanceId);
    }
}
