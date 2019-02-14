using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreLeaseRepository : ILeaseRepository
    {
        public Lease Create(Lease newLease)
        {
            using (var db = new CozyDbContext())
            {
                db.Leases.Add(newLease);
                db.SaveChanges();

                return newLease;
            }
        }

        public bool DeleteById(int leaseId)
        {
            using (var db = new CozyDbContext())
            {
                var leaseToDelete = GetById(leaseId);
                db.Remove(leaseToDelete);
                db.SaveChanges();

                if (GetById(leaseId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public ICollection<Lease> GetByHomeId(int homeId)
        {
            using (var db = new CozyDbContext())
            {
                var results = new List<Lease>();
                foreach (var l in db.Leases)
                {
                    if (l.HomeId == homeId)
                    {
                        results.Add(l);
                    }
                }
                return results;
            }
        }

        public Lease GetById(int leaseId)
        {
            using (var db = new CozyDbContext()) 
            {
                return db.Leases.Single(l => l.Id == leaseId);
            }
        }

        public ICollection<Lease> GetByTenantId(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Leases
                    .Where(l => l.TenantId == tenantId)
                    .ToList();
            }
        }

        public Lease Update(Lease updatedLease)
        {
            using (var db = new CozyDbContext())
            {
                var existingLease = GetById(updatedLease.Id);
                db.Entry(existingLease).CurrentValues.SetValues(updatedLease);
                db.SaveChanges();

                return existingLease;
            }
        }
    }
}