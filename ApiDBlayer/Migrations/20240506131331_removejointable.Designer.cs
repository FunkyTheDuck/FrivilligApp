﻿// <auto-generated />
using System;
using ApiDBlayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiDBlayer.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20240506131331_removejointable")]
    partial class removejointable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackendModels.DtoEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("EventInfoId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(101)
                        .HasColumnType("nvarchar(101)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VoluntaryId")
                        .HasColumnType("int");

                    b.Property<int>("WantedVolunteers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventInfoId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BackendModels.DtoEventInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("CoordinateX")
                        .HasColumnType("float");

                    b.Property<double>("CoordinateY")
                        .HasColumnType("float");

                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EventsInfo");
                });

            modelBuilder.Entity("BackendModels.DtoInterests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DtoEventInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("DtoUserInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Interest")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("DtoEventInfoId");

                    b.HasIndex("DtoUserInfoId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("BackendModels.DtoRatings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("BackendModels.DtoSkills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DtoEventInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("DtoUserInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("DtoEventInfoId");

                    b.HasIndex("DtoUserInfoId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("BackendModels.DtoUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsVoluntary")
                        .HasColumnType("bit");

                    b.Property<int>("UserCredebtialsId")
                        .HasColumnType("int");

                    b.Property<int>("UserInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("UserCredebtialsId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BackendModels.DtoUserCredentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserCredentials");
                });

            modelBuilder.Entity("BackendModels.DtoUserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.Property<double>("LocationX")
                        .HasMaxLength(50)
                        .HasColumnType("float");

                    b.Property<double>("LocationY")
                        .HasColumnType("float");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("DtoEventDtoUser", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.Property<int>("VolunteersId")
                        .HasColumnType("int");

                    b.HasKey("EventsId", "VolunteersId");

                    b.HasIndex("VolunteersId");

                    b.ToTable("DtoEventDtoUser");
                });

            modelBuilder.Entity("BackendModels.DtoEvent", b =>
                {
                    b.HasOne("BackendModels.DtoEventInfo", "EventInfo")
                        .WithMany()
                        .HasForeignKey("EventInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventInfo");
                });

            modelBuilder.Entity("BackendModels.DtoInterests", b =>
                {
                    b.HasOne("BackendModels.DtoEventInfo", null)
                        .WithMany("Interests")
                        .HasForeignKey("DtoEventInfoId");

                    b.HasOne("BackendModels.DtoUserInfo", null)
                        .WithMany("Interests")
                        .HasForeignKey("DtoUserInfoId");
                });

            modelBuilder.Entity("BackendModels.DtoRatings", b =>
                {
                    b.HasOne("BackendModels.DtoUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendModels.DtoUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("BackendModels.DtoSkills", b =>
                {
                    b.HasOne("BackendModels.DtoEventInfo", null)
                        .WithMany("Skills")
                        .HasForeignKey("DtoEventInfoId");

                    b.HasOne("BackendModels.DtoUserInfo", null)
                        .WithMany("Skills")
                        .HasForeignKey("DtoUserInfoId");
                });

            modelBuilder.Entity("BackendModels.DtoUser", b =>
                {
                    b.HasOne("BackendModels.DtoUserCredentials", "UserCredebtials")
                        .WithMany()
                        .HasForeignKey("UserCredebtialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendModels.DtoUserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCredebtials");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("DtoEventDtoUser", b =>
                {
                    b.HasOne("BackendModels.DtoEvent", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendModels.DtoUser", null)
                        .WithMany()
                        .HasForeignKey("VolunteersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackendModels.DtoEventInfo", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("BackendModels.DtoUserInfo", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}