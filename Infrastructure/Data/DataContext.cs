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
        public DbSet<BetEntity> Bets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
            .HasOne(u => u.Company)
            .WithMany(c => c.Members)
            .HasForeignKey(u => u.CompanyEntityId);

            modelBuilder.Entity<GameEntity>()
            .HasOne(u => u.Event)
            .WithMany(c => c.Games)
            .HasForeignKey(u => u.EventEntityId);

            modelBuilder.Entity<BetEntity>()
            .HasOne(u => u.User)
            .WithMany(u => u.Bets)
            .HasForeignKey(u => u.UserEntityId);

            modelBuilder.Entity<BetEntity>()
            .HasOne(b => b.Game).WithMany(g => g.Bets).HasForeignKey(b => b.GameEntityId);
        }
    }
}