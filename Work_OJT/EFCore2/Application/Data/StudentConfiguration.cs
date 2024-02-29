using EFCore2.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore2.Application.Data
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("tbl_student");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(250).IsRequired();
            builder.Property(s => s.Birthday).IsRequired();
            builder.Property(s => s.Gender).IsRequired().HasDefaultValue(0);
            builder.Property(s => s.Status).IsRequired().HasDefaultValue(true);
        }
    }
}