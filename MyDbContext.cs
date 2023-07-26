using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface2
{
    public class MyDbContext : DbContext
    {

        public MyDbContext()
        {
            //Database.EnsureDeleted();            
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=Diplom.sqlite");
        }

        public DbSet<PlanRoom> PlanRooms { get; set; }
        public DbSet<NetEquipments> NetEquipments { get; set; }
        public DbSet<UseNetEquipments> UseNetEquipments { get; set; }
        public DbSet<CoordinatesAccessPoints> CoordinatesAccessPoints { get; set; }
        public DbSet<Project> Projects { get; set; }
 
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UseNetEquipments>()
            .HasKey(u => new { u.PointId, u.ProjectId });
        }


    }
}
