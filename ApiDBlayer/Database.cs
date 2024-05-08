using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModels;
using Microsoft.EntityFrameworkCore;

namespace ApiDBlayer
{
    public class Database : DbContext
    {
        public DbSet<DtoEvent> Events { get; set; }
        public DbSet<DtoEventInfo> EventsInfo { get; set; }
        public DbSet<DtoInterests> Interests { get; set; }
        public DbSet<DtoRatings> Ratings { get; set; }
        public DbSet<DtoSkills> Skills { get; set; }
        public DbSet<DtoUser> Users { get; set; }
        public DbSet<DtoUserCredentials> UserCredentials { get; set; }
        public DbSet<DtoUserInfo> UserInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;DataBase=FrivilligDatabase;Integrated Security=True; TrustServerCertificate=true;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DtoRatings>().HasOne(x => x.Sender).WithMany().HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DtoUserInfo>().HasMany(x => x.Skills).WithMany(x => x.UserInfo);
            modelBuilder.Entity<DtoUserInfo>().HasMany(x => x.Interests).WithMany(x => x.UserInfo);
            modelBuilder.Entity<DtoEventInfo>().HasMany(x => x.Skills).WithMany(x => x.EventInfo);
            modelBuilder.Entity<DtoEventInfo>().HasMany(x => x.Interests).WithMany(x => x.EventInfo);

            modelBuilder.Entity<DtoSkills>().HasData(new DtoSkills { Id = 1, Skill = "Lave mad" });
            modelBuilder.Entity<DtoSkills>().HasData(new DtoSkills { Id = 2, Skill = "Kører bil" });
            modelBuilder.Entity<DtoSkills>().HasData(new DtoSkills { Id = 3, Skill = "Kundeservice" });

            modelBuilder.Entity<DtoInterests>().HasData(new DtoInterests { Id = 1, Interest = "Udendørs" });
            modelBuilder.Entity<DtoInterests>().HasData(new DtoInterests { Id = 2, Interest = "Sport" });
            modelBuilder.Entity<DtoInterests>().HasData(new DtoInterests { Id = 3, Interest = "Moter" });

            modelBuilder.Entity<DtoUserInfo>().HasData(new DtoUserInfo { Id = 1, LocationX = 56.073746, LocationY = 8.791669 });
            modelBuilder.Entity<DtoUserInfo>().HasData(new DtoUserInfo { Id = 2, LocationX = 8.791669, LocationY = 56.073746 });
            modelBuilder.Entity<DtoUserInfo>().HasData(new DtoUserInfo { Id = 3, LocationX = 52.073746, LocationY = 10.791669 });

            modelBuilder.Entity<DtoUserCredentials>().HasData(new DtoUserCredentials { Id = 1, Password = "$2a$12$7nLP/OJ.RafjttMu9yC8jOntDE1b0mnEKiy0UzGvUlGh5DgQBt0rO" });
            modelBuilder.Entity<DtoUserCredentials>().HasData(new DtoUserCredentials { Id = 2, Password = "$2a$12$06vfmlMA4hTPDA1WPKxe4eRGv1oE.r7NSyfZasKUCJL0R.4VXnH12" });
            modelBuilder.Entity<DtoUserCredentials>().HasData(new DtoUserCredentials { Id = 3, Password = "$2a$12$C2YIlWVnVjko847ttKeB.ekm6StFHU0CvXiDaKbtRg32svt.6Bozi" });

            modelBuilder.Entity<DtoUser>().HasData(
                new DtoUser
                {
                    Id = 1,
                    IsVoluntary = true,
                    Username = "test1",
                    UserInfoId = 1,
                    UserCredebtialsId = 1
                });
            modelBuilder.Entity<DtoUser>().HasData(
                new DtoUser
                {
                    Id = 2,
                    IsVoluntary = true,
                    Username = "test2",
                    UserInfoId = 2,
                    UserCredebtialsId = 2
                });

            modelBuilder.Entity<DtoUser>().HasData(
                new DtoUser
                {
                    Id = 3,
                    IsVoluntary = false,
                    Username = "admin",
                    UserInfoId = 3,
                    UserCredebtialsId = 3
                });

            modelBuilder.Entity<DtoEventInfo>().HasData(new DtoEventInfo { Id = 1, Address = "Herning", CoordinateX = 56.137632, CoordinateY = 8.973847 });
            modelBuilder.Entity<DtoEvent>().HasData(
                new DtoEvent
                {
                    Id = 1,
                    OwnerId = 3,
                    Title = "Sejt event",
                    Description = "Det er et sejt event som alle gerne vil være med til",
                    ImageUrl = "https://www.blivgladnu.dk/wp-content/uploads/2018/06/Messe_Luzern_Corporate_Event.jpg",
                    EventInfoId = 1,
                });

        }
    }
}
