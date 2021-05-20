using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories.Interfaces;
using CricketStatsGraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CricketStatsGraphQL.Repositories
{

    public class CountryRepository : ICountry
    {

        private readonly AppDbContext _appDataContext;

        public CountryRepository(AppDbContext context)
        {
            _appDataContext = context;
        }

        async public Task<List<Country>> GetCountries()
        {
            return await _appDataContext.Countries.ToListAsync();
        }
    }
}