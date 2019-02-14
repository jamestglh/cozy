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
        private List<Lease> Leases = new List<Lease>();

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
