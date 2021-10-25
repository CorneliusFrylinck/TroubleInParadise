using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TroubleInParadise.Models;

namespace TroubleInParadise.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> users {  get; set; }
        public DbSet<Player> player {  get; set; }
        public DbSet<Server> servers {  get; set; }
        public DbSet<Base> bases {  get; set; }
        public DbSet<Resource> resources {  get; set; }
        public DbSet<ResourceCollection> resourceCollections {  get; set; }
        public DbSet<Building> buildings {  get; set; }
        public DbSet<BuildingType> buildingTypes { get; set; }  
        public DbSet<BuildingUpgrade> buildingUpgrades {  get; set; }
        public DbSet<Effect> effects {  get; set; } 
        public DbSet<Upgrade> upgrades {  get; set; }
        public DbSet<Location> locations {  get; set; }
        public DbSet<Event> events {  get; set; }

    }

}