using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL.BattingInns;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Microsoft.Extensions.Options;

namespace CricketStatsGraphQL.GraphQL {

    public partial class Mutation {

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddBattingInnPayload> AddBattingInnAsync(
            AddBattingInnInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken) {
            
             var battingInn = new BattingInn{
                 CountryId = input.CountryId,
                 BallsFaced = input.BallsFaced,
                 DismissalId = input.DismissalId,
                 FielderPlayerId = input.FielderPlayerId,
                 BowlerPlayerId = input.BowlerPlayerId,
                 FirstInns = input.FirstInns,
                 Fours = input.Fours,
                 LastUpdated = DateTimeOffset.Now,
                 PlayerId = input.PlayerId,
                 Runs = input.Runs,
                 Sixes = input.Sixes,
                 MatchId = input.MatchId
             };

             context.BattingInns.Add(battingInn);

             await context.SaveChangesAsync(cancellationToken);

            // await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

             return new AddBattingInnPayload(battingInn);

        }



         [UseDbContext(typeof(AppDbContext))]
        public async Task<AddBattingInnPayload> UpdateBattingInnAsync(
                AddBattingInnInput input,
                int battingInnId,
                [ScopedService] AppDbContext context)
        {
              var battingInn = context.BattingInns.FirstOrDefault(b => b.Id == battingInnId);

              battingInn.BallsFaced = input.BallsFaced;
              battingInn.BowlerPlayerId = input.BowlerPlayerId;
              battingInn.CountryId = input.CountryId;
              battingInn.DismissalId = input.DismissalId;
              battingInn.FielderPlayerId = input.FielderPlayerId;
              battingInn.FirstInns = input.FirstInns;
              battingInn.Fours = input.Fours;
              battingInn.MatchId = input.MatchId;
              battingInn.PlayerId = input.PlayerId;
              battingInn.Runs = input.Runs;
              battingInn.Sixes = input.Sixes;
              battingInn.LastUpdated = DateTimeOffset.Now;

              context.Update(battingInn);

              await context.SaveChangesAsync();

              return new AddBattingInnPayload(battingInn);


        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePayload> DeleteBattingInnAsync(
                int battingInnId,
                [ScopedService] AppDbContext context)
        {
              var battingInn = context.BattingInns.FirstOrDefault(b => b.Id == battingInnId);

              if (battingInn == null) return new DeletePayload($"Deletion failed due to BattingInn ID: {battingInnId} not found.");

              context.Remove(battingInn);

              await context.SaveChangesAsync();

              return new DeletePayload($"Deletion of BattingInn ID: {battingInnId}, successful.");


        }


     

    }


}