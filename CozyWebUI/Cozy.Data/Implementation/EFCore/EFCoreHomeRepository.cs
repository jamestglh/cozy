using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreHomeRepository : IHomeRepository
    {
        public Home Create(Home newHome)
        {
            using (var db = new CozyDbContext())
            {
                db.Homes.Add(newHome); //like a commit
                db.SaveChanges(); // like git push

                return newHome; // find out if this is enough to get 
                                // the id generated in DB
            }
        }

        public bool DeleteById(int homeId)
        {
            using (var db = new CozyDbContext())
            {
                var homeToDelete = GetById(homeId);
                db.Remove(homeToDelete);
                db.SaveChanges();

                if (GetById(homeId) == null) 
                {
                    return true;
                }

                return false;
            }
        }

        public Home GetById(int homeId)
        {
            using (var db = new CozyDbContext()) //similar to mock list
            {
                return db.Homes.Single(h => h.Id == homeId);
            }
        }

        public ICollection<Home> GetHomesByLandlordId(string landlordId)
        {
            using (var db = new CozyDbContext())
            {
                 
                return db.Homes
                    .Where(h => h.LandlordId == landlordId)
                    .ToList();

            }
        }

        public Home Update(Home updatedHome)
        {
            using (var db = new CozyDbContext())
            {
                var existingHome = GetById(updatedHome.Id);
                db.Entry(existingHome).CurrentValues.SetValues(updatedHome);
                db.SaveChanges();

                return existingHome;
            }
        }
    }
}
