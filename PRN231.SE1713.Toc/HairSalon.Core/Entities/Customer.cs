﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Core.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        [Column("CustomerName")]
        [StringLength(255)]
        public string Name { get; set; } = null!;

        [Column("CustomerAddress")]
        [StringLength(300)]
        public string? Address { get; set; }

        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        [StringLength(125)]
        public string Email { get; set; } = null!;

        [StringLength(75, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "varchar(max)")]        
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        public ICollection<AppointmentFeedback> AppointmentFeedback { get; set; } = new List<AppointmentFeedback>();
        
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        
        public ICollection<StylistFeedback> StylistFeedback { get; set; } = new List<StylistFeedback>();
    }
}
