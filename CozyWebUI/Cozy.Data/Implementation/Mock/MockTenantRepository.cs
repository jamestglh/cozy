using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockTenantRepository : ITenantRepository
    {
        public List<Tenant> Tenants = new List<Tenant>();
        public Tenant Create(Tenant newTenant)
        {
            //Just like LandlordId, this one is a string and will be a guid, so this is probably implemented wrong
            newTenant.Id = Tenants.OrderByDescending(t => t.Id).Single().Id + 1;
            Tenants.Add(newTenant);
            return newTenant;
        }

        public bool DeleteById(string tenantId)
        {
            var tenantToDelete = GetById(tenantId);
            Tenants.Remove(tenantToDelete);
            return true;
        }

        public Tenant GetById(string tenantId)
        {
            return Tenants.Single(l => l.Id == tenantId);
        }

        public ICollection<Tenant> GetTenantsByPaymentId(int paymentId)
        {
            var results = new List<Tenant>();
            foreach (var tenant in Tenants)
            {
                foreach (var payment in tenant.Payments)
                {
                    if (payment.Id == paymentId)
                    {
                        results.Add(tenant);
                    }
                }
            }
            return results;
        }

        public Tenant Update(Tenant updatedTenant)
        {
            DeleteById(updatedTenant.Id);
            Tenants.Add(updatedTenant);

            return updatedTenant;
        }
    }
}
