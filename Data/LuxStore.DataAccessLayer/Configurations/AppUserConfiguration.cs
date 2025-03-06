using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuxStore.DataAccessLayer.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(50).HasColumnType("varchar(50)").IsRequired();//Name alanı 50 karakter olacak ve zorunlu olacak. HascolumnType ile veritabanında varchar(50) olarak oluşturulacak.
            builder.Property(a => a.SurName).HasMaxLength(50).HasColumnType("varchar(50)").IsRequired();//SurName alanı 50 karakter olacak ve zorunlu olacak. HascolumnType ile veritabanında varchar(50) olarak oluşturulacak.
            builder.Property(a => a.Password).HasMaxLength(50).HasColumnType("varchar(50)").IsRequired();//Password alanı 50 karakter olacak ve zorunlu olacak. HascolumnType ile veritabanında varchar(50) olarak oluşturulacak.
            builder.Property(a => a.Email).HasMaxLength(50).HasColumnType("varchar(50)").IsRequired();//Email alanı 50 karakter olacak ve zorunlu olacak. HascolumnType ile veritabanında varchar(50) olarak oluşturulacak.
            builder.Property(a => a.Phone).HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(a => a.UserName).HasMaxLength(50).HasColumnType("varchar(50)");
        }
    }
}