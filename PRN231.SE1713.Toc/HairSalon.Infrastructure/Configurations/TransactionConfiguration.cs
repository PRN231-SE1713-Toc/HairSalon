using HairSalon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairSalon.Infrastructure.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(x => x.Customer)
                .WithMany(y => y.Transactions)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(x => x.Appointment)
                .WithMany(y => y.Transactions)
                .HasForeignKey(x => x.Appointment)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
