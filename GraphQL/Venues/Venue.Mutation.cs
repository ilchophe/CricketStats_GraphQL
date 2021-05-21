
using System;
using System.Linq;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL.Venues;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CricketStatsGraphQL.GraphQL
 {   
    public partial class Mutation {
    
    [UseDbContext(typeof(AppDbContext))]
        public async Task<AddVenuePayload> AddVenueAsync(
                AddVenueInput input,
                [ScopedService] AppDbContext context) {

            var venue = new Venue {

                CountryId = input.CountryId,
                VenueName = input.VenueName,
                VenueCity = input.VenueCity,
                LastUpdated = DateTimeOffset.Now

            };

            context.Venues.Add(venue);

            await context.SaveChangesAsync();

            return new AddVenuePayload(venue);

        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddVenuePayload> UpdateVenueAsync(
                AddVenueInput input,
                int venueId,
                [ScopedService] AppDbContext context)
        {
              var venue = context.Venues.FirstOrDefault(v => v.Id == venueId);

                venue.CountryId = input.CountryId;
                venue.VenueName = input.VenueName;
                venue.VenueCity = input.VenueCity;
                venue.LastUpdated = DateTimeOffset.Now;

              context.Update(venue);

              await context.SaveChangesAsync();

              return new AddVenuePayload(venue);


        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePayload> DeleteVenueAsync(
                int venueId,
                [ScopedService] AppDbContext context)
        {
              var venue = context.Venues.FirstOrDefault(v => v.Id == venueId);

              if (venue == null) return new DeletePayload($"Deletion failed due to Venue ID: {venueId} not found.");

              context.Remove(venue);

              await context.SaveChangesAsync();

              return new DeletePayload($"Deletion of Venue ID: {venueId}, successful.");


        }



    }

 }