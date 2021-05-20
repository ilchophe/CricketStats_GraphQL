using System.Collections.Generic;
using System.Linq;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CricketStatsGraphQL.GraphQL.Players
{
    public class PlayerType : ObjectType<Player>
    {

        protected override void Configure(IObjectTypeDescriptor<Player> descriptor)
        {
             descriptor
                .Description("Cricket player.");

            descriptor
                .Field(p => p.Country)
                .ResolveWith<Resolvers>(p => p.GetCountry(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the country the player is from.");

            descriptor
                .Field(p => p.BowlingInns)
                .ResolveWith<Resolvers>(p => p.GetBowlingInns(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the bowling innings that the player has bowled in."); 

            descriptor
                .Field(p => p.BattingInns)
                .ResolveWith<Resolvers>(p => p.GetBattingInns(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the batting innings that the player has batted in.");   

            descriptor
                .Field(p => p.BowlerInns)
                .ResolveWith<Resolvers>(p => p.GetBowlerInns(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the batting innings that the player has taken a wicket.");                     

            descriptor
                .Field(p => p.FielderInns)
                .ResolveWith<Resolvers>(p => p.GetFielderInns(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("These are all the batting innings that the player has been the fielder in a wicket taken.");      

        }

        private class Resolvers 
        {
            public Country GetCountry(Player player, [ScopedService] AppDbContext context) 
            {
                return context.Countries.FirstOrDefault(c => c.Id == player.CountryId);
            }

            public IQueryable<BowlingInn> GetBowlingInns(Player player, [ScopedService] AppDbContext context)   
            {
                return context.BowlingInns.Where(b => b.PlayerId == player.Id);
            }

            public IQueryable<BattingInn> GetBattingInns(Player player, [ScopedService] AppDbContext context)   
            {
                return context.BattingInns.Where(b => b.PlayerId == player.Id);
            }

            public IQueryable<BattingInn> GetBowlerInns(Player player, [ScopedService] AppDbContext context)   
            {
                return context.BattingInns.Where(b => b.BowlerPlayerId == player.Id);
            }

            public IQueryable<BattingInn> GetFielderInns(Player player, [ScopedService] AppDbContext context)   
            {
                return context.BattingInns.Where(b => b.FielderPlayerId == player.Id);
            }                               

        }

    }






}