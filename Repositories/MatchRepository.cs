using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories.Interfaces;
using CricketStatsGraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CricketStatsGraphQL.Repositories
{

    public class MatchRepository : IMatch
    {

        private readonly AppDbContext _appDataContext;

        public MatchRepository(AppDbContext context)
        {
            _appDataContext = context;
        }

        async public Task<List<Match>> GetMatches()
        {
            return await _appDataContext.Matches.ToListAsync();
        }
    }
}