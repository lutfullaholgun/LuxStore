using LuxStore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxStore.DataAccessLayer.Configurations
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(s => s.Title)
                .HasMaxLength(250);
            builder.Property(s => s.Description).HasMaxLength(500);
            builder.Property(s => s.Image)
                .HasMaxLength(100);
            builder.Property(s => s.Link).HasMaxLength(150);
        }
    }
}