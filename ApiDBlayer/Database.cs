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
        }
    }
}
