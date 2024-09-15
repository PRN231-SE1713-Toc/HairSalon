using HairSalon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairSalon.Infrastructure.Configurations
{
    public class AppointmentFeedbackConfiguration : IEntityTypeConfiguration<AppointmentFeedback>
    {
        public void Configure(EntityTypeBuilder<AppointmentFeedback> builder)
        {
            builder.HasOne(x => x.Customer)
                .WithMany(y => y.AppointmentFeedback)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(x => x.Appointment)
                .WithMany(y => y.AppointmentFeedback)
                .HasForeignKey(x => x.AppointmentId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
