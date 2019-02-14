using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Data.Interfaces
{
    public interface IHomeRepository
    {
        //Read
        Home GetById(int homeId);
        ICollection<Home> GetHomesByLandlordId(string landlordId);

        //Create 
        Home Create(Home newHome);

        //Update
        Home Update(Home updatedHome);

        //Delete
        bool DeleteById(int homeId);

    }
}
