using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.EMS.Repository;
using Mappers.EMS.EntityToDomain;
using Models.EMS.Domain;

namespace BusinessLayer.EMS
{
   public  class EMSManager : IEMSManager
    {
        IEMSRepository _repository;
        public EMSManager()
        {
            _repository = new EMSRepository();
        }

        public EventDomain CreateEvent(EventDomain domain)
        {
            var response = _repository.CreateEvent(domain.ToEntity());
            if (response == null)
            {
                throw new Exception($"Failed to save event {domain.EventName}");
            }
            return response.ToDomain();
        }

        public List<EventDomain> GetEventDetails(string fromDate, string toDate)
        {
            var response = _repository.GetEventDetails(fromDate, toDate);
            if (response == null)
            {
                throw new Exception($"Failed to get event details from {fromDate} to {toDate}");
            }
            return response.Select(x => x.ToDomain()).ToList();
        }
    }
}
