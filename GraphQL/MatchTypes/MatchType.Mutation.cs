
using System;
using System.Linq;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL.Countries;
using CricketStatsGraphQL.GraphQL.MatcheTypes;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CricketStatsGraphQL.GraphQL
 {   
    public partial class Mutation {
    
    [UseDbContext(typeof(AppDbContext))]
        public async Task<AddMatchTypePayload> AddMatchTypeAsync(
                AddMatchTypeInput input,
                [ScopedService] AppDbContext context) {

            var matchType = new MatchType{
                MatchTypeName = input.MatchTypeName,
                LastUpdated = DateTimeOffset.Now
            };

            context.MatchTypes.Add(matchType);

            await context.SaveChangesAsync();

            return new AddMatchTypePayload(matchType);

        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddMatchTypePayload> UpdateMatchTypeAsync(
                AddMatchTypeInput input,
                int matchTypeId,
                [ScopedService] AppDbContext context)
        {
              var matchType = context.MatchTypes.FirstOrDefault(m => m.Id == matchTypeId);

              matchType.MatchTypeName = input.MatchTypeName;
              matchType.LastUpdated = DateTimeOffset.Now;

              context.Update(matchType);

              await context.SaveChangesAsync();

              return new AddMatchTypePayload(matchType);


        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePayload> DeleteMatchTypeAsync(
                int matchTypeId,
                [ScopedService] AppDbContext context)
        {
              var matchType = context.MatchTypes.FirstOrDefault(m => m.Id == matchTypeId);

              if (matchType == null) return new DeletePayload($"Deletion failed due to MatchType ID: {matchTypeId} not found.");

              context.Remove(matchType);

              await context.SaveChangesAsync();

              return new DeletePayload($"Deletion of MatchType ID: {matchTypeId}, successful.");


        }



    }

 }