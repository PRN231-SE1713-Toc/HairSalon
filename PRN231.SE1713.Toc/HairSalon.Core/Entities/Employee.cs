using HairSalon.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Core.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }

        [Column("EmployeeName")]
        public string? Name { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        [StringLength(12)]
        public string CitizenId { get; set; } = null!;

        public string? Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        public EmployeeRole Role { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<StylistFeedback> StylistFeedback { get; set; } = new List<StylistFeedback>();
    }
}
