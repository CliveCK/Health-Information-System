namespace Health_Information_System.Migrations
{
    using EfEnumToLookup.LookupGenerator;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Health_Information_System.HIS.DAL.HISDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "Health_Information_System.HIS.DAL.HISDBContext";
        }

        protected override void Seed(Health_Information_System.HIS.DAL.HISDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var enumToLookup = new EnumToLookup();
            enumToLookup.Apply(context);

            context.BillingGroups.AddOrUpdate(
                b => b.Name,
                new Models.BillingGroups { Name = "Principal Member", AgeMin = 18, AgeMax = 60},
                new Models.BillingGroups { Name = "Spouse", AgeMin = 18, AgeMax = 60 },
                new Models.BillingGroups { Name = "Child Under 18", AgeMin = 0, AgeMax = 18 },
                new Models.BillingGroups { Name = "Child Above 18", AgeMin = 18, AgeMax = 60 },
                new Models.BillingGroups { Name = "Other Dependant", AgeMin = 0, AgeMax = 60 }
                );

            context.Cities.AddOrUpdate(
                a => a.Name,
                new Models.Cities { Name = "Harare"},
                new Models.Cities { Name = "Gweru" },
                new Models.Cities { Name = "Bulawayo" },
                new Models.Cities { Name = "Mutare" },
                new Models.Cities { Name = "Bindura" },
                new Models.Cities { Name = "Masvingo" }
                );

            context.Nationalities.AddOrUpdate(
                c => c.Name,
                new Models.Nationalities { Name = "Zimbabwean" },
                new Models.Nationalities { Name = "British" },
                new Models.Nationalities { Name = "American" },
                new Models.Nationalities { Name = "Indian" }
                );

            context.SaveChanges();
        }
    }
}
