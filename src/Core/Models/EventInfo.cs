using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int? EventTypeId { get; set; }

        [ForeignKey("EventTypeId")]
        public EventType EventType { get; set; }
        public string EventTitle { get; set; }
        public bool IsInativo { get; set; }
    }
}