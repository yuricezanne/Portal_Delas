using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class UserFavoriteEvent
    {
        [Key]
        public int UserFavoriteEventID { get; set; }

        public int UserInfoID { get; set; }

        [ForeignKey("UserInfoID")]
        public UserInfo UserInfo { get; set; }

        public int EventID { get; set; }

        [ForeignKey("EventID")]
        public EventInfo EventInfo { get; set; }
    }
}