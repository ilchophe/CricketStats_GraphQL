
using System;
using System.Linq;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL.Dismissals;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CricketStatsGraphQL.GraphQL
 {   
    public partial class Mutation {
    
    [UseDbContext(typeof(AppDbContext))]
        public async Task<AddDismissalPayload> AddDismissalAsync(AddDismissalInput input, [ScopedService] AppDbContext context) {

            var dismissal = new Dismissal{
                DismissalCode = input.DismissalCode,
                DismissalDesc = input.DismissalDesc,
                LastUpdated = DateTimeOffset.Now
            };

            context.Dismissals.Add(dismissal);

            await context.SaveChangesAsync();

            return new AddDismissalPayload(dismissal);

        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddDismissalPayload> UpdateDismissalyAsync(
                AddDismissalInput input,
                int dismissalId,
                [ScopedService] AppDbContext context)
        {
              var dismissal = context.Dismissals.FirstOrDefault(d => d.Id == dismissalId);

              dismissal.DismissalCode = input.DismissalCode;
              dismissal.DismissalDesc = input.DismissalDesc;
              dismissal.LastUpdated = DateTimeOffset.Now;

              context.Update(dismissal);

              await context.SaveChangesAsync();

              return new AddDismissalPayload(dismissal);


        }


        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeletePayload> DeleteDismissalAsync(
                int dismissalID,
                [ScopedService] AppDbContext context)
        {
              var dismissal = context.Dismissals.FirstOrDefault(d => d.Id == dismissalID);

              if (dismissal == null) return new DeletePayload($"Deletion failed due to Dismissal ID: {dismissalID} not found.");

              context.Remove(dismissal);

              await context.SaveChangesAsync();

              return new DeletePayload($"Deletion of Dismissal ID: {dismissalID}, successful.");


        }



    }

 }