using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockHomeRepository : IHomeRepository
    {

        private List<Home> Homes = new List<Home>()
        {
            new Home { Id = 1, Address = "123 main street", City = "Austin"}
        }
        ;

        

        public Home Create(Home newHome)
        {

            newHome.Id = Homes.OrderByDescending(h => h.Id).Single().Id + 1;
            Homes.Add(newHome);
            return newHome;
        }

        public bool DeleteById(int homeId)
        {
            var homeToDelete = GetById(homeId);
            Homes.Remove(homeToDelete);
            return true;
        }

        public Home GetById(int homeId)
        {
            return Homes.Single(h => h.Id == homeId);
        }

        public ICollection<Home> GetHomesByLandlordId(string landlordId)
        {
            return Homes.FindAll(h => h.LandlordId == landlordId);

        }

        public Home Update(Home updatedHome)
        {
            DeleteById(updatedHome.Id); //delete the existing home
            Homes.Add(updatedHome);

            return updatedHome;

        }
    }
}