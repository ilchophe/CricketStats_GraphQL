using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories.Interfaces;
using CricketStatsGraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace CricketStatsGraphQL.Repositories
{

    public class PlayerRepository : IPlayer
    {

        private readonly AppDbContext _appDataContext;

        public PlayerRepository(AppDbContext context)
        {
            _appDataContext = context;
        }

        async public Task<List<Player>> GetPlayers()
        {
            return await _appDataContext.Players.ToListAsync();
        }
    }
}