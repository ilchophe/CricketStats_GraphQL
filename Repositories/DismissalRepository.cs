using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories.Interfaces;
using CricketStatsGraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CricketStatsGraphQL.Repositories
{

    public class DismissalRepository : IDismissal
    {

        private readonly AppDbContext _appDataContext;

        public DismissalRepository(AppDbContext context)
        {
            _appDataContext = context;
        }

        async public Task<List<Dismissal>> GetDismissals()
        {
            return await _appDataContext.Dismissals.ToListAsync();
        }
    }
}