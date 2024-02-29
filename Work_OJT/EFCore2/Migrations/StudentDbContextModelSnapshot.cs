﻿// <auto-generated />
using System;
using EFCore2.Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCore2.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCore2.Application.Entities.Mark", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("Scores")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasDefaultValue(0);

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("tbl_mark", (string)null);
                });

            modelBuilder.Entity("EFCore2.Application.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR2(250)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(1)")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("tbl_student", (string)null);
                });

            modelBuilder.Entity("EFCore2.Application.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(1)")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("tbl_subject", (string)null);
                });

            modelBuilder.Entity("EFCore2.Application.Entities.Mark", b =>
                {
                    b.HasOne("EFCore2.Application.Entities.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore2.Application.Entities.Subject", "Subject")
                        .WithMany("Marks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("EFCore2.Application.Entities.Student", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("EFCore2.Application.Entities.Subject", b =>
                {
                    b.Navigation("Marks");
                });
#pragma warning restore 612, 618
        }
    }
}