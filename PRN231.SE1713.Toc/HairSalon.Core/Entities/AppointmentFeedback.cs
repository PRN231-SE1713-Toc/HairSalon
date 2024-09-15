namespace HairSalon.Core.Entities
{
    public class AppointmentFeedback : IEntity
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int CustomerId { get; set; }

        public int AppointmentId { get; set; }
        
        public short Rating { get; set; }
        
        public DateTime FeedbackDate { get; set; }

        public Appointment Appointment { get; set; } = null!;

        public Customer Customer { get; set; } = null!;
    }
}
