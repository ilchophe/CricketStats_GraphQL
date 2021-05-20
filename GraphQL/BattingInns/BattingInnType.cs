using System.Collections.Generic;
using System.Linq;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CricketStatsGraphQL.GraphQL.Players
{
    public class BattingInnType : ObjectType<BattingInn>
    {

        protected override void Configure(IObjectTypeDescriptor<BattingInn> descriptor)
        {
             descriptor
                .Description("Batting innings of a match.");

            descriptor
                .Field(p => p.Country)
                .ResolveWith<Resolvers>(p => p.GetCountry(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the country the batting innings belongs to.");

            descriptor
                .Field(p => p.Match)
                .ResolveWith<Resolvers>(p => p.GetMatch(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("The match this innings was played in.");                    

            descriptor
                .Field(p => p.Player)
                .ResolveWith<Resolvers>(p => p.GetPlayer(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("Batsman this innings was played by."); 

            descriptor
                .Field(p => p.PlayerBowler)
                .ResolveWith<Resolvers>(p => p.GetBowler(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("The bowler that took the wicket for this innings unless the batsman is not out.");   

            descriptor
                .Field(p => p.PlayerFielder)
                .ResolveWith<Resolvers>(p => p.GetFielder(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("The fielder if involved with taking the wicket for this innings unless the batsman is not out.");                     

            descriptor
                .Field(p => p.Dismissal)
                .ResolveWith<Resolvers>(p => p.GetDismissal(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("How the wicket was taken that ended this innings unless the batsman is not out.");      

        }

        private class Resolvers 
        {
            public Country GetCountry(BattingInn battingInn, [ScopedService] AppDbContext context) 
            {
                return context.Countries.FirstOrDefault(c => c.Id == battingInn.CountryId);
            }

            public Match GetMatch(BattingInn battingInn, [ScopedService] AppDbContext context) 
            {
                return context.Matches.FirstOrDefault(c => c.Id == battingInn.MatchId);
            }

            public Player GetPlayer(BattingInn battingInn, [ScopedService] AppDbContext context) 
            {
                return context.Players.FirstOrDefault(c => c.Id == battingInn.PlayerId);
            }

            public Player GetBowler(BattingInn battingInn, [ScopedService] AppDbContext context) 
            {
                return context.Players.FirstOrDefault(c => c.Id == battingInn.BowlerPlayerId);
            }

            public Player GetFielder(BattingInn battingInn, [ScopedService] AppDbContext context) 
            {
                return context.Players.FirstOrDefault(c => c.Id == battingInn.FielderPlayerId);
            }            

            public Dismissal GetDismissal(BattingInn battingInn, [ScopedService] AppDbContext context) 
            {
                return context.Dismissals.FirstOrDefault(c => c.Id == battingInn.DismissalId);
            }

        }

    }






}