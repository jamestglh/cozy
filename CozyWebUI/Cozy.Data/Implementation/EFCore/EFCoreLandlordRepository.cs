using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreLandlordRepository : ILandlordRepository
    {
        public Landlord Create(Landlord newLandlord)
        {
            using (var db = new CozyDbContext())
            {
                db.Landlords.Add(newLandlord);
                db.SaveChanges();

                return newLandlord;
            }
        }
        public bool DeleteById(string landlordId)
        {
            using (var db = new CozyDbContext())
            {
                var landlordToDelete = GetById(landlordId);
                db.Remove(landlordToDelete);
                db.SaveChanges();

                if (GetById(landlordId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public Landlord GetById(string landlordId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Landlords.Single(l => l.Id == landlordId);
            }
        }

        public ICollection<Landlord> GetLandlordByHomeId(int homeId)
        {
            using (var db = new CozyDbContext())
            {
                var results = new List<Landlord>();
                foreach (var l in db.Landlords)
                {
                    foreach (var h in l.Homes)
                    {
                        if (h.Id == homeId)
                        {
                            results.Add(l);
                        }
                    }
                }
                return results;

            }
        }

        public Landlord Update(Landlord updatedLandlord)
        {
            using (var db = new CozyDbContext())
            {
                var existingLandlord = GetById(updatedLandlord.Id);
                db.Entry(existingLandlord).CurrentValues.SetValues(updatedLandlord);
                db.SaveChanges();

                return existingLandlord;
            }
        }   
    }
}
