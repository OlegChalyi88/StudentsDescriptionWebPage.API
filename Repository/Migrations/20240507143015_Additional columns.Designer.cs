﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Data;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240507143015_Additional columns")]
    partial class Additionalcolumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Repository.Models.Domain.AdditionalInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hobbies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ResumeId");

                    b.ToTable("AdditionalInfos");
                });

            modelBuilder.Entity("Repository.Models.Domain.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdditionalInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentCourse")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateOfCourse")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleOfCourse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalInfoId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Repository.Models.Domain.Resume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("Repository.Models.Domain.StudentProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdditionalInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGraduated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsProfileVisible")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalInfoId");

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("Repository.Models.Domain.AdditionalInfo", b =>
                {
                    b.HasOne("Repository.Models.Domain.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Models.Domain.Resume", "Resume")
                        .WithMany()
                        .HasForeignKey("ResumeId");

                    b.Navigation("Course");

                    b.Navigation("Resume");
                });

            modelBuilder.Entity("Repository.Models.Domain.Course", b =>
                {
                    b.HasOne("Repository.Models.Domain.AdditionalInfo", null)
                        .WithMany("AllCourses")
                        .HasForeignKey("AdditionalInfoId");
                });

            modelBuilder.Entity("Repository.Models.Domain.StudentProfile", b =>
                {
                    b.HasOne("Repository.Models.Domain.AdditionalInfo", "AdditionalInfo")
                        .WithMany()
                        .HasForeignKey("AdditionalInfoId");

                    b.Navigation("AdditionalInfo");
                });

            modelBuilder.Entity("Repository.Models.Domain.AdditionalInfo", b =>
                {
                    b.Navigation("AllCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
