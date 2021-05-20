using System.Collections.Generic;
using System.Linq;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CricketStatsGraphQL.GraphQL.BowlingInns
{
    public class BowlingInnType : ObjectType<BowlingInn>
    {

        protected override void Configure(IObjectTypeDescriptor<BowlingInn> descriptor)
        {
             descriptor
                .Description("Bowling innings of a match.");

        

            descriptor
                .Field(p => p.Country)
                .ResolveWith<Resolvers>(p => p.GetCountry(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the country the player is from.");

            descriptor
                .Field(p => p.Match)
                .ResolveWith<Resolvers>(p => p.GetMatch(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("Thisa is the match this bowling innings belongs to."); 

            descriptor
                .Field(p => p.Player)
                .ResolveWith<Resolvers>(p => p.GetPlayer(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the bowler that this innings was played by.");   

      

        }

        private class Resolvers 
        {
            public Country GetCountry(BowlingInn bowlingInn, [ScopedService] AppDbContext context) 
            {
                return context.Countries.FirstOrDefault(c => c.Id == bowlingInn.CountryId);
            }

            public Match GetMatch(BowlingInn bowlingInn, [ScopedService] AppDbContext context)   
            {
                return context.Matches.FirstOrDefault(b => b.Id == bowlingInn.MatchId);
            }

            public Player GetPlayer(BowlingInn bowlingInn, [ScopedService] AppDbContext context)   
            {
                return context.Players.FirstOrDefault(b => b.Id == bowlingInn.PlayerId);
            }

                         

        }

    }






}