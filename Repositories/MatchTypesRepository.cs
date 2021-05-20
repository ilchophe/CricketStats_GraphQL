using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories.Interfaces;
using CricketStatsGraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CricketStatsGraphQL.Repositories
{

    public class MatchTypeRepository : IMatchType
    {

        private readonly AppDbContext _appDataContext;

        public MatchTypeRepository(AppDbContext context)
        {
            _appDataContext = context;
        }

        async public Task<List<MatchType>> GetMatchTypes()
        {
            return await _appDataContext.MatchTypes.ToListAsync();
        }
    }
}