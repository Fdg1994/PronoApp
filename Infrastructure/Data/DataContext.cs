using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<CompanyUserEntity> CompanyMembers { get; set; }
        public DbSet<PredictionGroupEntity> PredictionGroups { get; set; }
        public DbSet<BetEntity> Bets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyEntity>()
             .HasMany(a => a.Users)
             .WithMany(b => b.Companies)
             .UsingEntity<CompanyUserEntity>(jt => {
                 jt.ToTable("CompanyMembers");
                 jt.HasKey(jt => jt.Id);
                 jt.Property(jt => jt.Role);
             });
        }
    }
}