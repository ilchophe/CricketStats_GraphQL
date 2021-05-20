using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories.Interfaces;
using CricketStatsGraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CricketStatsGraphQL.Repositories
{

    public class BowlingInnRepository : IBowlingInn
    {

        private readonly AppDbContext _appDataContext;

        public BowlingInnRepository(AppDbContext context)
        {
            _appDataContext = context;
        }

        async public Task<List<BowlingInn>> GetBowlingInns()
        {
            return await _appDataContext.BowlingInns.ToListAsync();
        }
    }
}