﻿// <auto-generated />
using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entity_Framework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Entity_Framework.Models.Enrollment", b =>
                {
                    b.Property<string>("EnrollmentID")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentID")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectID")
                        .HasColumnType("TEXT");

                    b.HasKey("EnrollmentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Entity_Framework.Models.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entity_Framework.Models.Subject", b =>
                {
                    b.Property<string>("SubjectID")
                        .HasColumnType("TEXT");

                    b.Property<string>("HourPerSession")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumberOfSession")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
