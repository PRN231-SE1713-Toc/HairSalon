using HairSalon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairSalon.Infrastructure.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasOne(x => x.Customer)
                .WithMany(y => y.Appointments)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(x => x.Stylist)
                .WithMany(y => y.Appointments)
                .HasForeignKey(x => x.StylistId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
