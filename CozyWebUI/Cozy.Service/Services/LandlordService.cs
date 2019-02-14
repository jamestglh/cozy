using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;

namespace Cozy.Service.Services
{

    public interface ILandlordService
    {
        //Read
        Landlord GetById(string landlordId);
        ICollection<Landlord> GetLandlordByHomeId(int homeId);

        //Create 
        Landlord Create(Landlord newLandlord);

        //Update
        Landlord Update(Landlord updatedLandlord);

        //Delete
        bool DeleteById(string landlordId);
    }

    public class LandlordService : ILandlordService
    {
        private readonly ILandlordRepository _landlordRepository;

        public LandlordService(ILandlordRepository landlordRepository)
        {
            _landlordRepository = landlordRepository;
        }


        public Landlord Create(Landlord newLandlord)
        {
            return _landlordRepository.Create(newLandlord);
        }

        public bool DeleteById(string landlordId)
        {
            return _landlordRepository.DeleteById(landlordId);
        }

        public Landlord GetById(string landlordId)
        {
            return _landlordRepository.GetById(landlordId);
        }

        public ICollection<Landlord> GetLandlordByHomeId(int homeId)
        {
            return _landlordRepository.GetLandlordByHomeId(homeId);
        }

        public Landlord Update(Landlord updatedLandlord)
        {
            return _landlordRepository.Update(updatedLandlord);
        }
    }
}
