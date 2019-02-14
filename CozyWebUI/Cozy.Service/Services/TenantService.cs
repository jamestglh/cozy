using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;

namespace Cozy.Service.Services
{
    public interface ITenantService
    {
        //Read
        Tenant GetById(string tenantId);
        ICollection<Tenant> GetTenantsByPaymentId(int paymentId);

        //Create 
        Tenant Create(Tenant newTenant);

        //Update
        Tenant Update(Tenant updatedTenant);

        //Delete
        bool DeleteById(string tenantId);
    }

    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        private TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public Tenant Create(Tenant newTenant)
        {
            return _tenantRepository.Create(newTenant);

        }

        public bool DeleteById(string tenantId)
        {
            return _tenantRepository.DeleteById(tenantId);
        }

        public Tenant GetById(string tenantId)
        {
            return _tenantRepository.GetById(tenantId);
        }

        public ICollection<Tenant> GetTenantsByPaymentId(int paymentId)
        {
            return _tenantRepository.GetTenantsByPaymentId(paymentId);
        }

        public Tenant Update(Tenant updatedTenant)
        {
            return _tenantRepository.Update(updatedTenant);
        }
    }
}
