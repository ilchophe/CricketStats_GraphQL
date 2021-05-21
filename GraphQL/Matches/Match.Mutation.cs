
using System;
using System.Linq;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL.Matches;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CricketStatsGraphQL.GraphQL
 {   
    public partial class Mutation {
    
    [UseDbContext(typeof(AppDbContext))]
        public async Task<AddMatchPayload> AddMatchAsync(
                AddMatchInput input,
                [ScopedService] AppDbContext context) {

            var match = new Match {
                
                MatchNumber = input.MatchNumber,
                HomeCountryId = input.HomeCountryId,
                AwayCountryId = input.HomeCountryId,
                VenueId  = input.VenueId,
                MatchTypeId = input.MatchTypeId,
                MatchStartDate  = input.MatchStartDate, 
                TossWinnerCountryId = input.TossWinnerCountryId,
                LastUpdated = DateTimeOffset.Now

            };

            context.Matches.Add(match);

            await context.SaveChangesAsync();

            return new AddMatchPayload(match);

        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddMatchPayload> UpdateMatchAsync(
                AddMatchInput input,
                int matchId,
                [ScopedService] AppDbContext context)
        {
              var match = context.Matches.FirstOrDefault(m => m.Id == matchId);

                match.MatchNumber = input.MatchNumber;
                match.HomeCountryId = input.HomeCountryId;
                match.AwayCountryId = input.HomeCountryId;
                match.VenueId  = input.VenueId;
                match.MatchTypeId = input.MatchTypeId;
                match.MatchStartDate  = input.MatchStartDate; 
                match.TossWinnerCountryId = input.TossWinnerCountryId;
                match.LastUpdated = DateTimeOffset.Now;              

              context.Update(match);

              await context.SaveChangesAsync();

              return new AddMatchPayload(match);


        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePayload> DeleteMatchAsync(
                int matchId,
                [ScopedService] AppDbContext context)
        {
              var match = context.Matches.FirstOrDefault(m => m.Id == matchId);

              if (match == null) return new DeletePayload($"Deletion failed due to Match ID: {matchId} not found.");

              context.Remove(match);

              await context.SaveChangesAsync();

              return new DeletePayload($"Deletion of Match ID: {matchId}, successful.");


        }



    }

 }