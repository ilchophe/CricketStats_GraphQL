using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories.Interfaces;
using CricketStatsGraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CricketStatsGraphQL.Repositories
{

    public class VenueRepository : IVenue
    {

        private readonly AppDbContext _appDataContext;

        public VenueRepository(AppDbContext context)
        {
            _appDataContext = context;
        }

        async public Task<List<Venue>> GetVenues()
        {
            return await _appDataContext.Venues.ToListAsync();
        }
    }
}