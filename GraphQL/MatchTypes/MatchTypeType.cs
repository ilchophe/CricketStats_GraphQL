using System.Collections.Generic;
using System.Linq;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CricketStatsGraphQL.GraphQL.MatchTypes
{
    public class MatchTypeType : ObjectType<MatchType>
    {

        protected override void Configure(IObjectTypeDescriptor<MatchType> descriptor)
        {
             descriptor
                .Description("Type of match such as test match.");

               


            descriptor
                .Field(p => p.Matches)
                .ResolveWith<Resolvers>(p => p.GetMatches(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are the matches of this type."); 

                       

        }

        private class Resolvers 
        {
            public IQueryable<Match> GetMatches(MatchType matchType, [ScopedService] AppDbContext context)   
            {
                return context.Matches.Where(b => b.MatchTypeId == matchType.Id);
            }


        }

    }






}