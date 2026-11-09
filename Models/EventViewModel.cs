namespace RaceDayMVC.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public int EventID { get; set; } // Added to match EventID in views

        public string Title { get; set; } = string.Empty;
        public string EventName { get; set; } = string.Empty; // Added to match EventName
        public string Name { get; set; } = string.Empty; // Added to match Name

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        public DateTime EventDate { get; set; } // Added to match EventDate

        public string StartTime { get; set; } = string.Empty; // Added to match StartTime
        public string Status { get; set; } = string.Empty; // Added to match Status

        public string Location { get; set; } = string.Empty;
        public decimal RegistrationFee { get; set; }
        public string EventType { get; set; } = string.Empty;
    }
}