using Models.EMS.Entity;
using System.Collections.Generic;

namespace DataLayer.EMS.Repository
{
    public interface IEMSRepository
    {
        List<EventEntity> GetEventDetails(string fromDate, string toDate);
        EventEntity CreateEvent(EventEntity entity);
    }
}
