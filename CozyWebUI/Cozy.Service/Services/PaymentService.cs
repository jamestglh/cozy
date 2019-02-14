using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;

namespace Cozy.Service.Services
{
    public interface IPaymentService
    {
        //Read
        Payment GetById(int paymentId);
        ICollection<Payment> GetPaymentsByTenantId(string tenantId);
        ICollection<Payment> GetPaymentsByLeaseId(int leaseId);

        //Create 
        Payment Create(Payment newPayment);

        //Update
        Payment Update(Payment updatedPayment);

        //Delete
        bool DeleteById(int paymentId);
    }
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public Payment Create(Payment newPayment)
        {
            return _paymentRepository.Create(newPayment);
        }

        public bool DeleteById(int paymentId)
        {
            return _paymentRepository.DeleteById(paymentId);
        }

        public Payment GetById(int paymentId)
        {
            return _paymentRepository.GetById(paymentId);
        }

        public ICollection<Payment> GetPaymentsByLeaseId(int leaseId)
        {
            return _paymentRepository.GetPaymentsByLeaseId(leaseId);
        }

        public ICollection<Payment> GetPaymentsByTenantId(string tenantId)
        {
            return _paymentRepository.GetPaymentsByTenantId(tenantId);
        }

        public Payment Update(Payment updatedPayment)
        {
            return _paymentRepository.Update(updatedPayment);
        }
    }
}
