using CricketStatsGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CricketStatsGraphQL.Data 
{

    public class AppDbContext : DbContext 
    {

        public AppDbContext(DbContextOptions options) :base(options)  {}

            public DbSet<BattingInn> BattingInns { get; set; }
            public DbSet<BowlingInn> BowlingInns { get; set; }
            public DbSet<Country> Countries { get; set; }
            public DbSet<Dismissal> Dismissals { get; set; }
            public DbSet<Match> Matches { get; set; }
            public DbSet<MatchType> MatchTypes { get; set; }
            public DbSet<Player> Players { get; set; }
            public DbSet<Venue> Venues { get; set; }    

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            modelBuilder.Entity<BattingInn>().Property(c => c.LastUpdated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            modelBuilder.Entity<BowlingInn>().Property(c => c.LastUpdated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            modelBuilder.Entity<Country>().Property(c => c.LastUpdated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            modelBuilder.Entity<Dismissal>().Property(c => c.LastUpdated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            modelBuilder.Entity<Match>().Property(c => c.LastUpdated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            modelBuilder.Entity<MatchType>().Property(c => c.LastUpdated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            modelBuilder.Entity<Player>().Property(c => c.LastUpdated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
            modelBuilder.Entity<Venue>().Property(c => c.LastUpdated).HasDefaultValueSql("SYSDATETIMEOFFSET()");

                //Countries
                modelBuilder
                    .Entity<Country>()
                    .HasMany(c => c.Players)
                    .WithOne(c => c.Country!)
                    .HasForeignKey(c => c.CountryId);

                // modelBuilder
                //     .Entity<Country>()
                //     .HasMany(c => c.Matches)
                //     .WithOne(c => c.Country!)
                //     .HasForeignKey(c => c.HomeCountryId);

                // modelBuilder
                //     .Entity<Country>()
                //     .HasMany(c => c.Matches)
                //     .WithOne(c => c.Country!)
                //     .HasForeignKey(c => c.AwayCountryId);

                // modelBuilder
                //     .Entity<Country>()
                //     .HasMany(c => c.Matches)
                //     .WithOne(c => c.Country!)
                //     .HasForeignKey(c => c.TossWinnerCountryId);

                modelBuilder
                    .Entity<Country>()
                    .HasMany(c => c.Venues)
                    .WithOne(c => c.Country!)
                    .HasForeignKey(c => c.CountryId);

                modelBuilder
                    .Entity<Country>()
                    .HasMany(c => c.BattingInns)
                    .WithOne(c => c.Country!)
                    .HasForeignKey(c => c.CountryId);

                modelBuilder
                    .Entity<Country>()
                    .HasMany(c => c.BowlingInns)
                    .WithOne(c => c.Country!)
                    .HasForeignKey(c => c.CountryId);    


                //BattingInns
                modelBuilder
                    .Entity<BattingInn>()
                    .HasOne(b => b.Match)
                    .WithMany(b => b.BattingInns)
                    .HasForeignKey(b => b.MatchId).OnDelete(DeleteBehavior.NoAction);

                modelBuilder
                    .Entity<BattingInn>()
                    .HasOne(b => b.Player)
                    .WithMany(b => b.BattingInns)
                    .HasForeignKey(b => b.PlayerId).OnDelete(DeleteBehavior.NoAction);

                // modelBuilder
                //     .Entity<BattingInn>()
                //     .HasOne(b => b.PlayerBowler!)
                //     .WithMany(b => b.BowlerInns)
                //     .HasForeignKey(b => b.BowlerPlayerId!);

                // modelBuilder
                //     .Entity<BattingInn>()
                //     .HasOne(b => b.PlayerFielder!)
                //     .WithMany(b => b.FielderInns)
                //     .HasForeignKey(b => b.FielderPlayerId!);


                modelBuilder
                    .Entity<BattingInn>()
                    .HasOne(b => b.Country)
                    .WithMany(b => b.BattingInns)
                    .HasForeignKey(b => b.CountryId);

                modelBuilder
                    .Entity<BattingInn>()
                    .HasOne(b => b.Dismissal!)
                    .WithMany(b => b.BattingInns)
                    .HasForeignKey(b => b.DismissalId);

                //BowlingInns
                modelBuilder
                    .Entity<BowlingInn>()
                    .HasOne(b => b.Player)
                    .WithMany(b => b.BowlingInns)
                    .HasForeignKey(b => b.PlayerId).OnDelete(DeleteBehavior.NoAction);    

                modelBuilder
                    .Entity<BowlingInn>()
                    .HasOne(b => b.Country)
                    .WithMany(b => b.BowlingInns)
                    .HasForeignKey(b => b.CountryId);

                modelBuilder
                    .Entity<BowlingInn>()
                    .HasOne(b => b.Match)
                    .WithMany(b => b.BowlingInns)
                    .HasForeignKey(b => b.MatchId).OnDelete(DeleteBehavior.NoAction);

                //Dimissals
                modelBuilder
                    .Entity<Dismissal>()
                    .HasMany(d => d.BattingInns)
                    .WithOne(d => d.Dismissal!)
                    .HasForeignKey(d => d.DismissalId);

                //Matches
                modelBuilder
                    .Entity<Match>()
                    .HasMany(m => m.BattingInns)
                    .WithOne(m => m.Match)
                    .HasForeignKey(m => m.MatchId);

                modelBuilder
                    .Entity<Match>()
                    .HasMany(m => m.BowlingInns)
                    .WithOne(m => m.Match)
                    .HasForeignKey(m => m.MatchId);                 

                // modelBuilder
                //     .Entity<Match>()
                //     .HasOne(m => m.Country)
                //     .WithMany(m => m.Matches)
                //     .HasForeignKey(m => m.AwayCountryId);

                // modelBuilder
                //     .Entity<Match>()
                //     .HasOne(m => m.Country)
                //     .WithMany(m => m.Matches)
                //     .HasForeignKey(m => m.HomeCountryId);

                // modelBuilder
                //     .Entity<Match>()
                //     .HasOne(m => m.Country)
                //     .WithMany(m => m.Matches)
                //     .HasForeignKey(m => m.TossWinnerCountryId);

                modelBuilder
                    .Entity<Match>()
                    .HasOne(m => m.Venue)
                    .WithMany(m => m.Matches)
                    .HasForeignKey(m => m.VenueId).OnDelete(DeleteBehavior.NoAction);

                modelBuilder
                    .Entity<Match>()
                    .HasOne(m => m.MatchType)
                    .WithMany(m => m.Matches)
                    .HasForeignKey(m => m.MatchTypeId);  

                //MatchTypes
                modelBuilder
                    .Entity<MatchType>()
                    .HasMany(m => m.Matches)
                    .WithOne(m => m.MatchType)
                    .HasForeignKey(m => m.MatchTypeId);

                //Players
                modelBuilder
                    .Entity<Player>()
                    .HasOne(p => p.Country)
                    .WithMany(p => p.Players)
                    .HasForeignKey(p => p.CountryId);

                 modelBuilder
                    .Entity<Player>()
                    .HasMany(p => p.BowlingInns)
                    .WithOne(p => p.Player!)
                    .HasForeignKey(p => p.PlayerId);                      

                 modelBuilder
                    .Entity<Player>()
                    .HasMany(p => p.BattingInns)
                    .WithOne(p => p.Player!)
                    .HasForeignKey(p => p.PlayerId);    

                //Venues
                 modelBuilder
                    .Entity<Venue>()
                    .HasMany(v => v.Matches)
                    .WithOne(v => v.Venue!)
                    .HasForeignKey(v => v.VenueId);                                                                       

                modelBuilder
                    .Entity<Venue>()
                    .HasOne(v => v.Country)
                    .WithMany(v => v.Venues)
                    .HasForeignKey(v => v.CountryId); 




            }

    }

}