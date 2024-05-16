﻿// <auto-generated />
using ApiDBlayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiDBlayer.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbModels.DtoEvent", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Det er et sejt event som alle gerne vil være med til",
                            EventInfoId = 1,
                            ImageUrl = "https://www.blivgladnu.dk/wp-content/uploads/2018/06/Messe_Luzern_Corporate_Event.jpg",
                            OwnerId = 3,
                            Title = "Sejt event",
                            VoluntaryId = 0,
                            WantedVolunteers = 0
                        });
                });

            modelBuilder.Entity("DbModels.DtoEventInfo", b =>
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

                    b.HasKey("Id");

                    b.ToTable("EventsInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Herning",
                            CoordinateX = 56.137632000000004,
                            CoordinateY = 8.9738469999999992
                        });
                });

            modelBuilder.Entity("DbModels.DtoEventInfoInterests", b =>
                {
                    b.Property<int>("EventInfoId")
                        .HasColumnType("int");

                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.HasKey("EventInfoId", "InterestsId");

                    b.HasIndex("InterestsId");

                    b.ToTable("EventInfoInterests");
                });

            modelBuilder.Entity("DbModels.DtoEventInfoSkills", b =>
                {
                    b.Property<int>("EventInfoId")
                        .HasColumnType("int");

                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.HasKey("EventInfoId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("EventInfoSkills");
                });

            modelBuilder.Entity("DbModels.DtoInterests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Interest")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Interest = "Udendørs"
                        },
                        new
                        {
                            Id = 2,
                            Interest = "Sport"
                        },
                        new
                        {
                            Id = 3,
                            Interest = "Moter"
                        });
                });

            modelBuilder.Entity("DbModels.DtoRatings", b =>
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

            modelBuilder.Entity("DbModels.DtoSkills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Skill = "Lave mad"
                        },
                        new
                        {
                            Id = 2,
                            Skill = "Kører bil"
                        },
                        new
                        {
                            Id = 3,
                            Skill = "Kundeservice"
                        });
                });

            modelBuilder.Entity("DbModels.DtoUser", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventId = 0,
                            IsVoluntary = true,
                            UserCredebtialsId = 1,
                            UserInfoId = 1,
                            Username = "test1"
                        },
                        new
                        {
                            Id = 2,
                            EventId = 0,
                            IsVoluntary = true,
                            UserCredebtialsId = 2,
                            UserInfoId = 2,
                            Username = "test2"
                        },
                        new
                        {
                            Id = 3,
                            EventId = 0,
                            IsVoluntary = false,
                            UserCredebtialsId = 3,
                            UserInfoId = 3,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("DbModels.DtoUserCredentials", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "$2a$12$7nLP/OJ.RafjttMu9yC8jOntDE1b0mnEKiy0UzGvUlGh5DgQBt0rO"
                        },
                        new
                        {
                            Id = 2,
                            Password = "$2a$12$06vfmlMA4hTPDA1WPKxe4eRGv1oE.r7NSyfZasKUCJL0R.4VXnH12"
                        },
                        new
                        {
                            Id = 3,
                            Password = "$2a$12$C2YIlWVnVjko847ttKeB.ekm6StFHU0CvXiDaKbtRg32svt.6Bozi"
                        });
                });

            modelBuilder.Entity("DbModels.DtoUserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("LocationX")
                        .HasMaxLength(50)
                        .HasColumnType("float");

                    b.Property<double>("LocationY")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationX = 56.073746,
                            LocationY = 8.7916690000000006
                        },
                        new
                        {
                            Id = 2,
                            LocationX = 8.7916690000000006,
                            LocationY = 56.073746
                        },
                        new
                        {
                            Id = 3,
                            LocationX = 52.073746,
                            LocationY = 10.791669000000001
                        });
                });

            modelBuilder.Entity("DbModels.DtoUserInfoInterests", b =>
                {
                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.Property<int>("UserInfoId")
                        .HasColumnType("int");

                    b.HasKey("InterestsId", "UserInfoId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("UserInfoInterests");
                });

            modelBuilder.Entity("DbModels.DtoUserInfoSkills", b =>
                {
                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.Property<int>("UserInfoId")
                        .HasColumnType("int");

                    b.HasKey("SkillsId", "UserInfoId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("UserInfoSkills");
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

            modelBuilder.Entity("DbModels.DtoEvent", b =>
                {
                    b.HasOne("DbModels.DtoEventInfo", "EventInfo")
                        .WithMany()
                        .HasForeignKey("EventInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventInfo");
                });

            modelBuilder.Entity("DbModels.DtoEventInfoInterests", b =>
                {
                    b.HasOne("DbModels.DtoEventInfo", "EventInfo")
                        .WithMany()
                        .HasForeignKey("EventInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModels.DtoInterests", "Interests")
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventInfo");

                    b.Navigation("Interests");
                });

            modelBuilder.Entity("DbModels.DtoEventInfoSkills", b =>
                {
                    b.HasOne("DbModels.DtoEventInfo", "EventInfo")
                        .WithMany()
                        .HasForeignKey("EventInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModels.DtoSkills", "Skills")
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventInfo");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("DbModels.DtoRatings", b =>
                {
                    b.HasOne("DbModels.DtoUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModels.DtoUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DbModels.DtoUser", b =>
                {
                    b.HasOne("DbModels.DtoUserCredentials", "UserCredebtials")
                        .WithMany()
                        .HasForeignKey("UserCredebtialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModels.DtoUserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCredebtials");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("DbModels.DtoUserInfoInterests", b =>
                {
                    b.HasOne("DbModels.DtoInterests", "Interests")
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModels.DtoUserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interests");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("DbModels.DtoUserInfoSkills", b =>
                {
                    b.HasOne("DbModels.DtoSkills", "Skills")
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModels.DtoUserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skills");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("DtoEventDtoUser", b =>
                {
                    b.HasOne("DbModels.DtoEvent", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModels.DtoUser", null)
                        .WithMany()
                        .HasForeignKey("VolunteersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
