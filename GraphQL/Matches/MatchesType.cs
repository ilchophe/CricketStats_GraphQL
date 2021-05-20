using System.Collections.Generic;
using System.Linq;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CricketStatsGraphQL.GraphQL.Matches
{
    public class MatchesType : ObjectType<Match>
    {

        protected override void Configure(IObjectTypeDescriptor<Match> descriptor)
        {
             descriptor
                .Description("Cricket match.");


            descriptor
                .Field(p => p.BattingInns)
                .ResolveWith<Resolvers>(p => p.GetBattingInns(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("All the batting innings for this match.");

            descriptor
                .Field(p => p.BowlingInns)
                .ResolveWith<Resolvers>(p => p.GetBowlingInns(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("All the bowling innings for this match."); 

            descriptor
                .Field(p => p.CountryHome)
                .ResolveWith<Resolvers>(p => p.GetHomeCountry(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("The country that hosted this match.");   

            descriptor
                .Field(p => p.CountryAway)
                .ResolveWith<Resolvers>(p => p.GetAwayCountry(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("The visiting country for this match.");                     

            descriptor
                .Field(p => p.CountryTossWon)
                .ResolveWith<Resolvers>(p => p.GetTossWonCountry(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("The country that won the toss for this match.");   

            descriptor
                .Field(p => p.MatchType)
                .ResolveWith<Resolvers>(p => p.GetMatchType(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("The type of match that was played."); 

            descriptor
                .Field(p => p.Venue)
                .ResolveWith<Resolvers>(p => p.GetVenue(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("The venue where this match was played.");                                        

        }

        private class Resolvers 
        {
            public IQueryable<BattingInn> GetBattingInns(Match match, [ScopedService] AppDbContext context) 
            {
                return context.BattingInns.Where(c => c.MatchId == match.Id);
            }

            public IQueryable<BowlingInn> GetBowlingInns(Match match, [ScopedService] AppDbContext context)   
            {
                return context.BowlingInns.Where(b => b.MatchId == match.Id);
            }

            public Country GetHomeCountry(Match match, [ScopedService] AppDbContext context)   
            {
                return context.Countries.FirstOrDefault(b => b.Id == match.HomeCountryId);
            }

            public Country GetAwayCountry(Match match, [ScopedService] AppDbContext context)   
            {
                return context.Countries.FirstOrDefault(b => b.Id == match.AwayCountryId);
            }

            public Country GetTossWonCountry(Match match, [ScopedService] AppDbContext context)   
            {
                return context.Countries.FirstOrDefault(b => b.Id == match.TossWinnerCountryId);
            } 

            public MatchType GetMatchType(Match match, [ScopedService] AppDbContext context)   
            {
                return context.MatchTypes.FirstOrDefault(b => b.Id == match.MatchTypeId);
            }

            public Venue GetVenue(Match match, [ScopedService] AppDbContext context)   
            {
                return context.Venues.FirstOrDefault(b => b.Id == match.VenueId);
            }                                   

        }

    }






}