using System.Collections.Generic;
using System.Linq;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CricketStatsGraphQL.GraphQL.Venues
{
    public class VenueType : ObjectType<Venue>
    {

        protected override void Configure(IObjectTypeDescriptor<Venue> descriptor)
        {
             descriptor
                .Description("Venue where games are played.");

            descriptor
                .Field(p => p.Country)
                .ResolveWith<Resolvers>(p => p.GetCountry(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("Country where venue is located.");

            descriptor
                .Field(p => p.Matches)
                .ResolveWith<Resolvers>(p => p.GetMatches(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are the matches that have taken place at this venue."); 

                       

        }

        private class Resolvers 
        {
            public Country GetCountry(Venue venue, [ScopedService] AppDbContext context) 
            {
                return context.Countries.FirstOrDefault(c => c.Id == venue.CountryId);
            }

            public IQueryable<Match> GetMatches(Venue venue, [ScopedService] AppDbContext context)   
            {
                return context.Matches.Where(b => b.VenueId == venue.Id);
            }


        }

    }






}