using System.Collections.Generic;  
using System.Threading.Tasks;  
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.Models;

namespace CricketStatsGraphQL.Repositories.Interfaces
{
    public interface IBattingInn
    {
        Task<List<BattingInn>> GetBattingInns(AppDbContext context);
        
    }
}