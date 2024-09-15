using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSalon.Core.Entities
{
    public class Service : IEntity
    {
        public int Id { get; set; }

        [Column("ServiceName")]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Column("ServiceDescription")]
        [StringLength(255)]
        public string Description { get; set; } = null!;

        [Column("EstimatedDuration")]
        public string? Duration { get; set; }

        [Column(TypeName = "decimal(10)")]
        public decimal Price { get; set; }

        public ICollection<AppointmentService> AppointmentServices { get; set; } = null!;
    }
}
