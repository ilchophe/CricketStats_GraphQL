using System.Collections.Generic;
using System.Linq;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CricketStatsGraphQL.GraphQL.Countries
{
    public class CountryType : ObjectType<Country>
    {

        protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
        {
             descriptor
                .Description("Cricketing Country.");

            descriptor
                .Field(p => p.Players)
                .ResolveWith<Resolvers>(p => p.GetPlayers(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("All the players from this country.");

            descriptor
                .Field(p => p.Venues)
                .ResolveWith<Resolvers>(p => p.GetVenues(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the venues belonging to this country."); 

            descriptor
                .Field(p => p.BattingInns)
                .ResolveWith<Resolvers>(p => p.GetBattingInns(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the batting innings for this country.");   

            descriptor
                .Field(p => p.BowlingInns)
                .ResolveWith<Resolvers>(p => p.GetBowlingInns(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the bowling innings for this country.");                     

            descriptor
                .Field(p => p.MatchesHomeCountries)
                .ResolveWith<Resolvers>(p => p.GetHomeMatches(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the home matches played by this country.");   

            descriptor
                .Field(p => p.MatchesAwayCountries)
                .ResolveWith<Resolvers>(p => p.GetAwayMatches(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the away matches played by this country."); 

            descriptor
                .Field(p => p.MatchesTossCountries)
                .ResolveWith<Resolvers>(p => p.GetTossWonMatches(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the matches where this country has won the toss.");                                        

        }

        private class Resolvers 
        {
            public IQueryable<Player> GetPlayers(Country country, [ScopedService] AppDbContext context) 
            {
                return context.Players.Where(c => c.CountryId == country.Id);
            }

            public IQueryable<Venue> GetVenues(Country country, [ScopedService] AppDbContext context)   
            {
                return context.Venues.Where(b => b.CountryId == country.Id);
            }

            public IQueryable<BattingInn> GetBattingInns(Country country, [ScopedService] AppDbContext context)   
            {
                return context.BattingInns.Where(b => b.CountryId == country.Id);
            }

            public IQueryable<BowlingInn> GetBowlingInns(Country country, [ScopedService] AppDbContext context)   
            {
                return context.BowlingInns.Where(b => b.CountryId == country.Id);
            }

            public IQueryable<Match> GetHomeMatches(Country country, [ScopedService] AppDbContext context)   
            {
                return context.Matches.Where(b => b.HomeCountryId == country.Id);
            }

            public IQueryable<Match> GetAwayMatches(Country country, [ScopedService] AppDbContext context)   
            {
                return context.Matches.Where(b => b.AwayCountryId == country.Id);
            }

            public IQueryable<Match> GetTossWonMatches(Country country, [ScopedService] AppDbContext context)   
            {
                return context.Matches.Where(b => b.TossWinnerCountryId == country.Id);
            }                                                            

        }

    }






}