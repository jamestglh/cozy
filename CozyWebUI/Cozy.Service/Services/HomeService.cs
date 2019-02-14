using System;
using System.Collections.Generic;
using System.Text;
using Cozy.Data.Interfaces;
using Cozy.Domain.Models;

namespace Cozy.Service.Services
{
    public interface IHomeService
    {
        Home GetById(int homeId);
        ICollection<Home> GetHomesByLandlordId(string landlordId);

        Home Create(Home newHome);
        Home Update(Home updatedHome);
        bool DeleteById(int homeId);
    }

    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public Home Create(Home newHome)
        {
            return _homeRepository.Create(newHome);
        }

        public bool DeleteById(int homeId)
        {
            return _homeRepository.DeleteById(homeId);
           
        }

        public Home GetById(int homeId)
        {
            return _homeRepository.GetById(homeId);
        }

        public ICollection<Home> GetHomesByLandlordId(string landlordId)
        {
            return _homeRepository.GetHomesByLandlordId(landlordId);
        }

        public Home Update(Home updatedHome)
        {
            return _homeRepository.Update(updatedHome);
        }
    }
}
