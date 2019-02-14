using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface ILandlordRepository
    {
        //Read
        Landlord GetById(string landlordId);
        ICollection<Landlord> GetLandlordByHomeId(int homeId);

        //Create 
        Landlord Create(Landlord newLandlord);

        //Update
        Landlord Update(Landlord updatedLandlord);

        //Delete
        bool DeleteById(string landlordId);
    }
}
