using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories;
using CricketStatsGraphQL.Repositories.Interfaces;
using HotChocolate;
using HotChocolate.Data;

namespace CricketStatsGraphQL.GraphQL
{

    public class Query
    {

        // private readonly IBattingInn _battingInnRepository;

        // public Query(IBattingInn battingInnsRepo)
        // {
        //      _battingInnRepository = battingInnsRepo;   
        // }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<BattingInn> GetBattingInn([ScopedService] AppDbContext context)
        {
            //return await _battingInnRepository.GetBattingInns(context);
             return context.BattingInns;   
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<BowlingInn> GetBowlingInn([ScopedService] AppDbContext context)
        {
             return context.BowlingInns;   
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Country> GetCountry([ScopedService] AppDbContext context)
        {
             return context.Countries;   
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Dismissal> GetDismissal([ScopedService] AppDbContext context)
        {
             return context.Dismissals;   
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Match> GetMatch([ScopedService] AppDbContext context)
        {
             return context.Matches;   
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<MatchType> GetMatchType([ScopedService] AppDbContext context)
        {
             return context.MatchTypes;   
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Player> GetPlayer([ScopedService] AppDbContext context)
        {
             return context.Players;   
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Venue> GetVenue([ScopedService] AppDbContext context)
        {
             return context.Venues;   
        }                                                   

    }

}