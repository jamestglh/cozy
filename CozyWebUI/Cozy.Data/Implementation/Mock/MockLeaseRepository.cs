using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockLeaseRepository : ILeaseRepository
    {
        private List<Lease> Leases = new List<Lease>()
        {
            new Lease { Id = 1, HomeId = 1, StartDate = DateTime.Now.AddMonths(-5), EndDate = DateTime.Now.AddMonths(6), RentPrice = 800 },
            new Lease { Id = 2, HomeId = 1, StartDate = DateTime.Now.AddMonths(-10), EndDate = DateTime.Now.AddMonths(-6), RentPrice = 700 },
            new Lease { Id = 3, HomeId = 1, StartDate = DateTime.Now.AddMonths(-15), EndDate = DateTime.Now.AddMonths(-11), RentPrice = 600 }
        };

        public Lease Create(Lease newLease)
        {
            newLease.Id = Leases.OrderByDescending(l => l.Id).Single().Id + 1;
            Leases.Add(newLease);
            return newLease;
        }

        public bool DeleteById(int leaseId)
        {
            var leaseToDelete = GetById(leaseId);
            Leases.Remove(leaseToDelete);
            return true;
        }

        public ICollection<Lease> GetByHomeId(int homeId)
        {
            return Leases.FindAll(l => l.HomeId == homeId);
        }

        public Lease GetById(int leaseId)
        {
            return Leases.Single(l => l.Id == leaseId);
        }

        public ICollection<Lease> GetByTenantId(string tenantId)
        {
            return Leases.FindAll(l => l.TenantId == tenantId);
        }

        public Lease Update(Lease updatedLease)
        {
            DeleteById(updatedLease.Id);  
            Leases.Add(updatedLease);
            return updatedLease;
        }

    }
}
