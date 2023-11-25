using System.Collections.Generic;
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

        public string EventType { get; set; }

        public string EventTitle { get; set; }
        public bool IsInativo { get; set; }

        // Adicione a chave estrangeira para o criador do evento
        public int CreatedByUserId { get; set; }

        [ForeignKey("CreatedByUserId")]
        public UserInfo EventCreatedByUser { get; set; }

        public List<UserFavoriteEvent> UsersWhoFavorited { get; set; }
    }
}