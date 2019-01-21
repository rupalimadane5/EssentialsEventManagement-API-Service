using Models.EMS.Domain;
using System.Collections.Generic;

namespace BusinessLayer.EMS
{
    public interface IEMSManager
    {
        List<EventDomain> GetEventDetails(string fromDate, string toDate);
        EventDomain CreateEvent(EventDomain domain);
    }
}
