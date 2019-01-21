using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EMS.Domain
{
    public class EventDomain
    {
        public string Event { get; set; }
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public string EventColor { get; set; }
    }
}
