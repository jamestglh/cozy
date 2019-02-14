using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface IMaintenanceStatusRepository
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
}
