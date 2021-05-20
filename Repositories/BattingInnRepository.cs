using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories.Interfaces;
using CricketStatsGraphQL.Data;
using Microsoft.EntityFrameworkCore;
using HotChocolate.Data;
using HotChocolate;

namespace CricketStatsGraphQL.Repositories
{

    public class BattingInnRepository : IBattingInn
    {

        // private readonly AppDbContext _appDataContext;

        // public BattingInnRepository(AppDbContext context) 
        // {
        //     _appDataContext = context;
        // }

        [UseDbContext(typeof(AppDbContext))]
        async public Task<List<BattingInn>> GetBattingInns([ScopedService] AppDbContext context)
        {
           // return await _appDataContext.BattingInns.ToListAsync();
           return await context.BattingInns.ToListAsync();
        }
    }
}