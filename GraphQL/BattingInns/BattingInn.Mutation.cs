using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL.BattingInns;
using CricketStatsGraphQL.GraphQL.Countries;
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

     

    }


}