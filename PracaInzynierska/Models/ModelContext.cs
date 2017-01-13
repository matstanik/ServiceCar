using PracaInzynierska.Models.Entities;
using PracaInzynierska.Models.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("name=CarService") 
        {
           Database.SetInitializer<ModelContext>(null);
           //Database.SetInitializer<ModelContext>(new DropCreateDatabaseIfModelChanges<ModelContext>());
           //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ModelContext, Configuration>("CarService"));
        }
       
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Login> logins { get; set; }
        public DbSet<Worker> workers { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<CarInquery> carRequests { get; set; }
        public DbSet<ReplacementCar> servicesCars { get; set; }
        public DbSet<SalaryReport> salaryReport { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Defect> defects { get; set; }
        public DbSet<Part> parts { get; set; }
        public DbSet<PostalCode> postalCodes { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<WorkersView> workersView { get; set; }
        public DbSet<OrdersView> ordersView { get; set; }
        public DbSet<ClientView> clientsView { get; set; }
        public DbSet<WorkersOrderView> workerOrderView { get; set; }
        public DbSet<DefectsView> defectView { get; set; }
        public DbSet<ClientsOrderView> clientOrderView { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
        
    }
    internal sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ModelContext context)
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
        }
    }
}
