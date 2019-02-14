using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCoreTenantRepository : ITenantRepository
    {
        public Tenant Create(Tenant newTenant)
        {
            using (var db = new CozyDbContext())
            {
                db.Tenants.Add(newTenant);
                db.SaveChanges();

                return newTenant;
            }
        }

        public bool DeleteById(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
                var tenantToDelete = GetById(tenantId);
                db.Remove(tenantToDelete);
                db.SaveChanges();

                if (GetById(tenantId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public Tenant GetById(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Tenants.Single(l => l.Id == tenantId);
            }
        }

        public ICollection<Tenant> GetTenantsByPaymentId(int paymentId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Tenants.Where(tenant => tenant.Payments.Any(p => p.Id == paymentId)).ToList();
            }

        }

        public Tenant Update(Tenant updatedTenant)
        {
            using (var db = new CozyDbContext())
            {
                var existingTenant = GetById(updatedTenant.Id);
                db.Entry(existingTenant).CurrentValues.SetValues(updatedTenant);
                db.SaveChanges();

                return existingTenant;
            }
        }
    }
}