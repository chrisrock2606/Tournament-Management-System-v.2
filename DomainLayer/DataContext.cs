namespace DomainLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=ConnectionSettings")
        {
        }

        public virtual DbSet<LEAGUE> LEAGUEs { get; set; }
        public virtual DbSet<MATCH> MATCHes { get; set; }
        public virtual DbSet<PLAYER> PLAYERs { get; set; }
        public virtual DbSet<ROUND> ROUNDs { get; set; }
        public virtual DbSet<TEAM> TEAMs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LEAGUE>()
                .HasMany(e => e.ROUNDs1)
                .WithRequired(e => e.LEAGUE)
                .HasForeignKey(e => e.LeagueID_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LEAGUE>()
                .HasMany(e => e.TEAMs)
                .WithRequired(e => e.LEAGUE)
                .HasForeignKey(e => e.LeagueID_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PLAYER>()
                .HasMany(e => e.TEAMs)
                .WithMany(e => e.PLAYERs)
                .Map(m => m.ToTable("PLAYERS_IN_TEAM", "db_owner").MapLeftKey("PlayerID_FK").MapRightKey("TeamID_FK"));

            modelBuilder.Entity<ROUND>()
                .HasMany(e => e.MATCHes)
                .WithRequired(e => e.ROUND)
                .HasForeignKey(e => e.RoundID_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROUND>()
                .HasMany(e => e.TEAMs)
                .WithMany(e => e.ROUNDs)
                .Map(m => m.ToTable("TEAMS_IN_ROUND", "db_owner").MapLeftKey("RoundID_FK").MapRightKey("TeamID_FK"));

            modelBuilder.Entity<TEAM>()
                .HasMany(e => e.MATCHes)
                .WithRequired(e => e.TEAM)
                .HasForeignKey(e => e.Winner)
                .WillCascadeOnDelete(false);
        }
    }
}
