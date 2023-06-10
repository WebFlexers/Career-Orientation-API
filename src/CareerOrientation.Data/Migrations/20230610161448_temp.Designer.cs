﻿// <auto-generated />
using System;
using CareerOrientation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CareerOrientation.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230610161448_temp")]
    partial class temp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CareerOrientation.Data.Entities.Courses.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Semester")
                        .HasColumnType("integer");

                    b.Property<int?>("TrackId")
                        .HasColumnType("integer");

                    b.HasKey("CourseId");

                    b.HasIndex("TrackId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Courses.CourseSkill", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.HasKey("CourseId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CourseSkill");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Courses.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SkillId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("SkillId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Specialties.MastersDegree", b =>
                {
                    b.Property<int>("MastersDegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MastersDegreeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("MastersDegreeId");

                    b.ToTable("MastersDegrees");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Specialties.Profession", b =>
                {
                    b.Property<int>("ProfessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProfessionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ProfessionId");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Specialties.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TrackId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("TrackId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.GeneralTest", b =>
                {
                    b.Property<int>("GeneralTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GeneralTestId"));

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("GeneralTestId");

                    b.ToTable("GeneralTests");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.MultipleChoiceAnswer", b =>
                {
                    b.Property<int>("MultipleChoiceAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MultipleChoiceAnswerId"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("MultipleChoiceAnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("MultipleChoiceAnswers");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionId"));

                    b.Property<int?>("GeneralTestId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int?>("UniversityTestId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionId");

                    b.HasIndex("GeneralTestId");

                    b.HasIndex("UniversityTestId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            Text = "Hello",
                            Type = 0
                        });
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.TrueFalseAnswer", b =>
                {
                    b.Property<int>("TrueFalseAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TrueFalseAnswerId"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<bool>("Value")
                        .HasColumnType("boolean");

                    b.HasKey("TrueFalseAnswerId");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("TrueFalseAnswers");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.UniversityTest", b =>
                {
                    b.Property<int>("UniversityTestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UniversityTestId"));

                    b.Property<bool>("IsRevision")
                        .HasColumnType("boolean");

                    b.Property<int?>("Semester")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("UniversityTestId");

                    b.ToTable("UniversityTests");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsSpecialtiesRelations.QuestionMastersDegree", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("MastersDegreeId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionId", "MastersDegreeId");

                    b.HasIndex("MastersDegreeId");

                    b.ToTable("QuestionsMastersDegrees");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsSpecialtiesRelations.QuestionProfession", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionId", "ProfessionId");

                    b.HasIndex("ProfessionId");

                    b.ToTable("QuestionsProfessions");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsSpecialtiesRelations.QuestionTrack", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("TrackId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionId", "TrackId");

                    b.HasIndex("TrackId");

                    b.ToTable("QuestionsTracks");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.StudentTookUniversityTest", b =>
                {
                    b.Property<int>("UniversityTestId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("UniversityTestId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("StudentsTookUniversityTests");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.UserLikertScaleAnswer", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("QuestionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLikertScaleAnswers");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.UserMultipleChoiceAnswer", b =>
                {
                    b.Property<int>("MultipleChoiceAnswerId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("MultipleChoiceAnswerId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMultipleChoiceAnswers");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.UserTookGeneralTest", b =>
                {
                    b.Property<int>("GeneralTestId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("GeneralTestId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersTookGeneralTests");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.UserTrueFalseAnswer", b =>
                {
                    b.Property<int>("TrueFalseAnswerId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("TrueFalseAnswerId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTrueFalseAnswers");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Users.UniversityStudent", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("Semester")
                        .HasColumnType("integer");

                    b.Property<int?>("TrackId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("TrackId");

                    b.ToTable("UniversityStudents");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsProspectiveStudent")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.UsersCoursesRelations.UserCourseGrade", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("CourseId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourseGrade");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.UsersCoursesRelations.UserCourseStatistics", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("AccessCount")
                        .HasColumnType("integer");

                    b.HasKey("CourseId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourseStatistics");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Courses.Course", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Specialties.Track", "Track")
                        .WithMany("Courses")
                        .HasForeignKey("TrackId");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Courses.CourseSkill", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Courses.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Courses.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.MultipleChoiceAnswer", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Tests.Question", "Question")
                        .WithMany("MultipleChoiceAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.Question", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Tests.GeneralTest", "GeneralTest")
                        .WithMany("Questions")
                        .HasForeignKey("GeneralTestId");

                    b.HasOne("CareerOrientation.Data.Entities.Tests.UniversityTest", "UniversityTest")
                        .WithMany("Questions")
                        .HasForeignKey("UniversityTestId");

                    b.Navigation("GeneralTest");

                    b.Navigation("UniversityTest");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.TrueFalseAnswer", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Tests.Question", "Question")
                        .WithOne("TrueFalseAnswer")
                        .HasForeignKey("CareerOrientation.Data.Entities.Tests.TrueFalseAnswer", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsSpecialtiesRelations.QuestionMastersDegree", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Specialties.MastersDegree", "MastersDegree")
                        .WithMany()
                        .HasForeignKey("MastersDegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Tests.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MastersDegree");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsSpecialtiesRelations.QuestionProfession", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Specialties.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Tests.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profession");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsSpecialtiesRelations.QuestionTrack", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Tests.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Specialties.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.StudentTookUniversityTest", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Tests.UniversityTest", "UniversityTest")
                        .WithMany()
                        .HasForeignKey("UniversityTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UniversityTest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.UserLikertScaleAnswer", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Tests.Question", "Question")
                        .WithMany("UsersLikertScaleAnswers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Users.User", "User")
                        .WithMany("UserLikertScaleAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.UserMultipleChoiceAnswer", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Tests.MultipleChoiceAnswer", "MultipleChoiceAnswer")
                        .WithMany()
                        .HasForeignKey("MultipleChoiceAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MultipleChoiceAnswer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.UserTookGeneralTest", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Tests.GeneralTest", "GeneralTest")
                        .WithMany()
                        .HasForeignKey("GeneralTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GeneralTest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.TestsUsersRelations.UserTrueFalseAnswer", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Tests.TrueFalseAnswer", "TrueFalseAnswer")
                        .WithMany()
                        .HasForeignKey("TrueFalseAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrueFalseAnswer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Users.UniversityStudent", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Specialties.Track", "Track")
                        .WithMany("UniversityStudents")
                        .HasForeignKey("TrackId");

                    b.HasOne("CareerOrientation.Data.Entities.Users.User", "User")
                        .WithOne("UniversityStudent")
                        .HasForeignKey("CareerOrientation.Data.Entities.Users.UniversityStudent", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.UsersCoursesRelations.UserCourseGrade", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Courses.Course", null)
                        .WithMany("UserCourseGrades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Users.User", null)
                        .WithMany("UserCourseGrades")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.UsersCoursesRelations.UserCourseStatistics", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Courses.Course", null)
                        .WithMany("UserCourseStatistics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Users.User", null)
                        .WithMany("UserCourseStatistics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerOrientation.Data.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CareerOrientation.Data.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Courses.Course", b =>
                {
                    b.Navigation("UserCourseGrades");

                    b.Navigation("UserCourseStatistics");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Specialties.Track", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("UniversityStudents");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.GeneralTest", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.Question", b =>
                {
                    b.Navigation("MultipleChoiceAnswers");

                    b.Navigation("TrueFalseAnswer");

                    b.Navigation("UsersLikertScaleAnswers");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Tests.UniversityTest", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("CareerOrientation.Data.Entities.Users.User", b =>
                {
                    b.Navigation("UniversityStudent");

                    b.Navigation("UserCourseGrades");

                    b.Navigation("UserCourseStatistics");

                    b.Navigation("UserLikertScaleAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
