using System.ComponentModel.DataAnnotations;

namespace Models.EMS.Dto.Contract
{
    public class CreateEventRequest
    {
        [Required]
        public string Event { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventDate { get; set; }
        [Required]
        public string EventTime { get; set; }
        [Required]
        public string EventColor { get; set; }
    }
}
