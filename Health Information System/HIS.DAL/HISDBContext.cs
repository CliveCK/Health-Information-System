using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Health_Information_System.Models;

namespace Health_Information_System.HIS.DAL
{
    public class HISDBContext : DbContext
    {

        public HISDBContext() : base("HIS")
        {
            Database.SetInitializer<HISDBContext>(null);
        }

        public DbSet<Members> Members { get; set; }
        public DbSet<BillingGroups> BillingGroups { get; set; }
        public DbSet<SegregatedFunds> SegregatedFunds { get; set; }
        public DbSet<CategoryHeader> CategoryHeader { get; set; }
        public DbSet<CategoryDetails> CategoryDetails { get; set; }
        public DbSet<Companies> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // Configure MemberID as PK for MemberCategories

           //modelBuilder.Entity<MemberCategories>()
           //    .HasKey(e => e.MemberID);

           // Configure MemberID as PK for MemberCategories

           //modelBuilder.Entity<Members>()
           //            .HasRequired(s => s.MemberCategories)
           //            .WithRequiredPrincipal(ad => ad.Member);

        }

        public System.Data.Entity.DbSet<Health_Information_System.Models.Nationalities> Nationalities { get; set; }

        public System.Data.Entity.DbSet<Health_Information_System.Models.Addresses> Addresses { get; set; }

        public System.Data.Entity.DbSet<Health_Information_System.Models.Cities> Cities { get; set; }
    }
}