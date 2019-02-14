using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;

namespace Cozy.Service.Services
{
    public interface ILeaseService
    {
        //Read
        Lease GetById(int leaseId);
        ICollection<Lease> GetByHomeId(int homeId);
        ICollection<Lease> GetByTenantId(string tenantId);

        //Create 
        Lease Create(Lease newLease);

        //Update
        Lease Update(Lease updatedLease);

        //Delete
        bool DeleteById(int leaseId);
    }


    public class LeaseService : ILeaseService
    {
        private readonly ILeaseRepository _leaseRepository;

        public LeaseService(ILeaseRepository leaseRepository)
        {
            _leaseRepository = leaseRepository;
        }


        public Lease Create(Lease newLease)
        {
            return _leaseRepository.Create(newLease);
        }

        public bool DeleteById(int leaseId)
        {
            return _leaseRepository.DeleteById(leaseId);
        }
        public ICollection<Lease> GetByHomeId(int homeId)
        {
            return _leaseRepository.GetByHomeId(homeId);
        }

        public Lease GetById(int leaseId)
        {
            return _leaseRepository.GetById(leaseId);
        }

        public ICollection<Lease> GetByTenantId(string tenantId)
        {
            return _leaseRepository.GetByTenantId(tenantId);
        }

        public Lease Update(Lease updatedLease)
        {
            return _leaseRepository.Update(updatedLease);
        }
    }
}
