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
        public DbSet<PredictionGroupEntity> PredictionGroups { get; set; }
        public DbSet<BetEntity> Bets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.Company)
            .WithMany(c => c.Members)
            .HasForeignKey(u => u.CompanyEntityId);

            modelBuilder.Entity<PredictionGroupEntity>()
            .HasOne(u => u.Company)
            .WithMany(c => c.PredictionGroups)
            .HasForeignKey(u => u.CompanyEntityId);

            modelBuilder.Entity<PredictionGroupEntity>()
            .HasOne(u => u.Event)
            .WithMany(c => c.PredictionGroups)
            .HasForeignKey(u => u.EventEntityId);

            modelBuilder.Entity<GameEntity>()
            .HasOne(u => u.Event)
            .WithMany(c => c.Games)
            .HasForeignKey(u => u.EventEntityId);

            modelBuilder.Entity<BetEntity>()
            .HasOne(u => u.User)
            .WithMany(c => c.Bets)
            .HasForeignKey(u => u.UserEntityId);
        }
    }
}