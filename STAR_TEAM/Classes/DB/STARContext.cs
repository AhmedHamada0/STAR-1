using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace STAR_TEAM
{
    public class STARContext : DbContext
    {
        public STARContext() : base("MyDBContext")
        {

        }

        //public static void Init()
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<STARContext, Configuration>());
        //}


        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }







        //public DbSet<Teacher> Teachers { get; set; }

        //modelBuilder.Entity<Users>().HasMany(u => u.Users_Levels).WithRequired(u => u.User).WillCascadeOnDelete(false);
        //modelBuilder.Entity<Levels>().HasMany(u => u.Users_Levels).WithRequired(u => u.Levels).WillCascadeOnDelete(false);
    }
}
