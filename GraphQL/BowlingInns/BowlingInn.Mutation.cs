using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL.BowlingInns;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Microsoft.Extensions.Options;

namespace CricketStatsGraphQL.GraphQL {

    public partial class Mutation {

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddBowlingInnPayload> AddBowlingInnAsync(
            AddBowlingInnInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken) {
            
             var bowlingInn = new BowlingInn{
                
                MatchId = input.MatchId,
                FirstInns = input.FirstInns,
                CountryId = input.CountryId,
                PlayerId = input.PlayerId,
                Runs = input.Runs,
                Wickets = input.Wickets,
                Maidens  = input.Maidens,
                Overs = input.Overs,
                Extras = input.Extras,
                LastUpdated = DateTimeOffset.Now

             };

             context.BowlingInns.Add(bowlingInn);

             await context.SaveChangesAsync(cancellationToken);

            // await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

             return new AddBowlingInnPayload(bowlingInn);

        }



         [UseDbContext(typeof(AppDbContext))]
        public async Task<AddBowlingInnPayload> UpdateBowlingInnAsync(
                AddBowlingInnInput input,
                int bowlingInnId,
                [ScopedService] AppDbContext context)
        {
              var bowlingInn = context.BowlingInns.FirstOrDefault(b => b.Id == bowlingInnId);

                bowlingInn.MatchId = input.MatchId;
                bowlingInn.FirstInns = input.FirstInns;
                bowlingInn.CountryId = input.CountryId;
                bowlingInn.PlayerId = input.PlayerId;
                bowlingInn.Runs = input.Runs;
                bowlingInn.Wickets = input.Wickets;
                bowlingInn.Maidens  = input.Maidens;
                bowlingInn.Overs = input.Overs;
                bowlingInn.Extras = input.Extras;
                bowlingInn.LastUpdated = DateTimeOffset.Now;

              context.Update(bowlingInn);

              await context.SaveChangesAsync();

              return new AddBowlingInnPayload(bowlingInn);


        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePayload> DeleteBowlingInnAsync(
                int bowlingInnId,
                [ScopedService] AppDbContext context)
        {
              var bowlingInn = context.BowlingInns.FirstOrDefault(b => b.Id == bowlingInnId);

              if (bowlingInn == null) return new DeletePayload($"Deletion failed due to BowlingInn ID: {bowlingInnId} not found.");

              context.Remove(bowlingInn);

              await context.SaveChangesAsync();

              return new DeletePayload($"Deletion of BowlingInn ID: {bowlingInnId}, successful.");


        }


     

    }


}