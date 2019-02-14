using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockLandlordRepository : ILandlordRepository
    {
        private List<Landlord> Landlords = new List<Landlord>();

        public Landlord Create(Landlord newLandlord)
        {
            //Landlord ID is a string, so not sure how to do this with a GUID since we haven't implemented yet
            newLandlord.Id = Landlords.OrderByDescending(l => l.Id).Single().Id + 1;
            Landlords.Add(newLandlord);
            return newLandlord;
        }

        public bool DeleteById(string landlordId)
        {
            var landlordToDelete = GetById(landlordId);
            Landlords.Remove(landlordToDelete);
            return true;
        }

        public Landlord GetById(string landlordId)
        {
            return Landlords.Single(l => l.Id == landlordId);
        }

        public ICollection<Landlord> GetLandlordByHomeId(int homeId)
        {

           
            return Landlords.Where(landlord => landlord.Homes.Any(home => home.Id == homeId)).ToList();
        }



        public Landlord Update(Landlord updatedLandlord)
        {
            DeleteById(updatedLandlord.Id);  
            Landlords.Add(updatedLandlord);

            return updatedLandlord;
        }
    }
}
