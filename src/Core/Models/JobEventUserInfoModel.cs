namespace Core.Models
{
    public class JobEventUserInfoModel
    {
        public int JobID { get; set; }

        public DateTime JobCreationDate { get; set; }

        public string? JobTitle { get; set; }

        public string? JobDescription { get; set; }

        public string? JobCategory { get; set; }

        public string? JobAddress { get; set; }

        public bool IsInativo { get; set; }

        public int UserID { get; set; }

        public string? CompanyName { get; set; }

        public int EventID { get; set; }

        public DateTime EventCreationDate { get; set; }

        public DateTime EventDate { get; set; }

        public string? EventDescription { get; set; }

        public string? EventAddress { get; set; }

        public string? EventType { get; set; }

        public string? EventTitle { get; set; }
    }
}
