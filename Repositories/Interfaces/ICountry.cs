using System.Collections.Generic;  
using System.Threading.Tasks;  
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;

namespace CricketStatsGraphQL.Repositories.Interfaces
{
    public interface ICountry
    {
        Task<List<Country>> GetCountries();
        
    }
}