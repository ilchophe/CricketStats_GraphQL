
using System;
using System.Linq;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL.Countries;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CricketStatsGraphQL.GraphQL
 {   
    public partial class Mutation {
    
    [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCountryPayload> AddCountryAsync(AddCountryInput input, [ScopedService] AppDbContext context) {

            var country = new Country{
                CountryCode = input.CountryCode,
                CountryDesc = input.CountryDesc,
                LastUpdated = DateTimeOffset.Now
            };

            context.Countries.Add(country);

            await context.SaveChangesAsync();

            return new AddCountryPayload(country);

        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCountryPayload> UpdateCountryAsync(
                AddCountryInput input,
                int countryID,
                [ScopedService] AppDbContext context)
        {
              var country = context.Countries.FirstOrDefault(c => c.Id == countryID);

              country.CountryCode = input.CountryCode;
              country.CountryDesc = input.CountryDesc;
              country.LastUpdated = DateTimeOffset.Now;

              context.Update(country);

              await context.SaveChangesAsync();

              return new AddCountryPayload(country);


        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePayload> DeleteCountryAsync(
                int countryID,
                [ScopedService] AppDbContext context)
        {
              var country = context.Countries.FirstOrDefault(c => c.Id == countryID);

              if (country == null) return new DeletePayload($"Deletion failed due to Country ID: {countryID} not found.");

              context.Remove(country);

              await context.SaveChangesAsync();

              return new DeletePayload($"Deletion of Country ID: {countryID}, successful.");


        }



    }

 }