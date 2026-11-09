using System.ComponentModel.DataAnnotations;

namespace RaceDayMVC.Models
{
    public class CreateEventViewModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime EventDate { get; set; } = DateTime.Now;
        public string Location { get; set; } = string.Empty;
        public decimal RegistrationFee { get; set; }
        public string EventType { get; set; } = string.Empty;
    }
}