using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL.BowlingInns;
using CricketStatsGraphQL.GraphQL.Players;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Microsoft.Extensions.Options;

namespace CricketStatsGraphQL.GraphQL {

    public partial class Mutation {

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlayerPayload> AddPlayerInnAsync(
            AddPlayerInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken) {
            
             var player = new Player{
                
                PlayerName = input.PlayerName,
                PlayerSurname = input.PlayerSurname,
                CountryId = input.CountryId,
                Retired = input.Retired,
                Dob = input.Dob,
                LastUpdated = DateTimeOffset.Now

             };

             context.Players.Add(player);

             await context.SaveChangesAsync(cancellationToken);

            // await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

             return new AddPlayerPayload(player);

        }



         [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlayerPayload> UpdatePlayerAsync (
                AddPlayerInput input,
                int playerId,
                [ScopedService] AppDbContext context)
        {
              var player = context.Players.FirstOrDefault(p => p.Id == playerId);

                player.PlayerName = input.PlayerName;
                player.PlayerSurname = input.PlayerSurname;
                player.CountryId = input.CountryId;
                player.Retired = input.Retired;
                player.Dob = input.Dob;
                player.LastUpdated = DateTimeOffset.Now;

              context.Update(player);

              await context.SaveChangesAsync();

              return new AddPlayerPayload(player);


        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePayload> DeletePlayerAsync(
                int playerId,
                [ScopedService] AppDbContext context)
        {
              var player = context.Players.FirstOrDefault(p => p.Id == playerId);

              if (player == null) return new DeletePayload($"Deletion failed due to Player ID: {playerId} not found.");

              context.Remove(player);

              await context.SaveChangesAsync();

              return new DeletePayload($"Deletion of Player ID: {playerId}, successful.");


        }


     

    }


}