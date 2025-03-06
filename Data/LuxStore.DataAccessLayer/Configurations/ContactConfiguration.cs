using LuxStore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuxStore.DataAccessLayer.Configurations
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.SurName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Email)
                .HasMaxLength(100);
            builder.Property(c => c.Phone)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");
            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}