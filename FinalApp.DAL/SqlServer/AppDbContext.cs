using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Domain.Models.Entities.Persons.WorkTeams;
using FinalApp.Domain.Models.Entities.Requests.EcoBoxInfo;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using Microsoft.EntityFrameworkCore;

namespace FinalApp.DAL.SqlServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<SupportOperator> SupportOperators { get; set; }
        public DbSet<TechnicalTeam> TechnicalTeams { get; set;}
        public DbSet<Worker> Workers { get; set; }
        public DbSet<EcoBox> EcoBoxes { get; set; }
        public DbSet<EcoBoxTemplate> EcoBoxTemplates { get; set;}
        public DbSet<SupplierCompany> SuppliersCompanies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RecyclingPlant> RecyclingPlants { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                 .HasMany(client => client.Rrequests)
                 .WithOne(request => request.Client)
                 .HasForeignKey(request => request.ClientId);

            modelBuilder.Entity<SupportOperator>()
                 .HasMany(support => support.Requests)
                 .WithOne(request => request.SupportOperator)
                 .HasForeignKey(request => request.OperatorId);

            modelBuilder.Entity<RecyclingPlant>()
                .HasMany(plant => plant.Requests)
                .WithOne(request => request.RecyclingPlant)
                .HasForeignKey(request => request.PlantId);

            modelBuilder.Entity<Review>()
                 .HasOne(review => review.Request)
                 .WithOne(request => request.Review)
                 .HasForeignKey<Request>(request => request.ReviewId);

            modelBuilder.Entity<TechnicalTeam>()
                .HasOne(team =>  team.Request)
                .WithOne(request =>  request.TechnicalTeam)
                .HasForeignKey<Request>(request => request.TeamId);


            modelBuilder.Entity<TechnicalTeamWorker>()
                 .HasKey(ttw => new { ttw.TechnicalTeamId, ttw.WorkerId });

            modelBuilder.Entity<TechnicalTeamWorker>()
                .HasOne(ttw => ttw.TechnicalTeam)
                .WithMany(tt => tt.Workers)
                .HasForeignKey(ttw => ttw.TechnicalTeamId);

            modelBuilder.Entity<TechnicalTeamWorker>()
                .HasOne(ttw => ttw.Worker)
                .WithMany(w => w.TechnicalTeams)
                .HasForeignKey(ttw => ttw.WorkerId);






        }


    }
}
