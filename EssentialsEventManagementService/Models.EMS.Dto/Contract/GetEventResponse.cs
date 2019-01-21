using System.Collections.Generic;

namespace Models.EMS.Dto.Contract
{
    public class GetEventResponse
    {
        public List<EventDto> Events { get; set; }
    }
}
