using Cozy.Data.Context;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.EFCore
{
    public class EFCorePaymentRepository : IPaymentRepository
    {
        public Payment Create(Payment newPayment)
        {
            using (var db = new CozyDbContext())
            {
                db.Payments.Add(newPayment);
                db.SaveChanges();

                return newPayment;
            }
        }

        public bool DeleteById(int paymentId)
        {
            using (var db = new CozyDbContext())
            {
                var paymentToDelete = GetById(paymentId);
                db.Remove(paymentToDelete);
                db.SaveChanges();

                if (GetById(paymentId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public Payment GetById(int paymentId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Payments.Single(l => l.Id == paymentId);
            }
        }

        public ICollection<Payment> GetPaymentsByLeaseId(int leaseId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Payments
                    .Where(l => l.LeaseId == leaseId)
                    .ToList();
            }
        }

        public ICollection<Payment> GetPaymentsByTenantId(string tenantId)
        {
            using (var db = new CozyDbContext())
            {
                return db.Payments
                    .Where(l => l.TenantId == tenantId)
                    .ToList();
            }
        }

        public Payment Update(Payment updatedPayment)
        {
            using (var db = new CozyDbContext())
            {
                var existingPayment = GetById(updatedPayment.Id);
                db.Entry(existingPayment).CurrentValues.SetValues(updatedPayment);
                db.SaveChanges();

                return existingPayment;
            }
        }
    }
}
