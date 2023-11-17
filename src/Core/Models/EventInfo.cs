using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class EventInfo
    {
        [Key]
        public int EventID { get; set; }
        public DateTime EventCreationDate { get; set; }

        public DateTime EventDate { get; set; }

        [MaxLength(1024)]
        public string EventDescription { get; set; }

        [MaxLength(1024)]
        public string EventAddress { get; set; }

        public string EventType { get; set; }
        public string EventTitle { get; set; }
        public bool IsInativo { get; set; }
    }
}