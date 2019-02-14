using Cozy.Data.Interfaces;
using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cozy.Data.Implementation.Mock
{
    public class MockPaymentRepository : IPaymentRepository
    {
        private List<Payment> Payments = new List<Payment>();

        public Payment Create(Payment newPayment)
        {
            newPayment.Id = Payments.OrderByDescending(l => l.Id).Single().Id + 1;
            Payments.Add(newPayment);
            return newPayment;
        }

        public bool DeleteById(int paymentId)
        {
            var paymentToDelete = GetById(paymentId);
            Payments.Remove(paymentToDelete);
            return true;
        }

        public Payment GetById(int paymentId)
        {
            return Payments.Single(l => l.Id == paymentId);
        }

        public ICollection<Payment> GetPaymentsByTenantId(string tenantId)
        {
            return Payments.FindAll(p => p.TenantId == tenantId);
        }

        public ICollection<Payment> GetPaymentsByLeaseId(int leaseId)
        {
            return Payments.FindAll(p => p.LeaseId == leaseId);
        }

        public Payment Update(Payment updatedPayment)
        {
            DeleteById(updatedPayment.Id);  
            Payments.Add(updatedPayment);

            return updatedPayment;
        }
    }
}
