using EFCore2.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore2.Application.Data
{
    public class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.ToTable("tbl_mark");
            builder.HasKey(m => new { m.StudentId, m.SubjectId });
            builder.Property(m => m.Scores).IsRequired().HasDefaultValue(0);
            builder.Property(m => m.CreateDate).IsRequired();

            builder.HasOne(m => m.Student)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Subject)
                .WithMany(s => s.Marks)
                .HasForeignKey(m => m.SubjectId);
        }
    }
}