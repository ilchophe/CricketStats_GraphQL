using System.Collections.Generic;
using System.Linq;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CricketStatsGraphQL.GraphQL.Dismissals
{
    public class DismissalType : ObjectType<Dismissal>
    {

        protected override void Configure(IObjectTypeDescriptor<Dismissal> descriptor)
        {
             descriptor
                .Description("Type of dismissal when a wicket is taken.");

            descriptor
                .Field(p => p.BattingInns)
                .ResolveWith<Resolvers>(p => p.GetBattingInns(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("Get all batting innings where this dismissal has taken place.");

                     

        }

        private class Resolvers 
        {

            public IQueryable<BattingInn> GetBattingInns(Dismissal dismissal, [ScopedService] AppDbContext context)   
            {
                return context.BattingInns.Where(b => b.DismissalId == dismissal.Id);
            }


        }

    }






}