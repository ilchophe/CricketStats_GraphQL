using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketStatsGraphQL.Data;
using CricketStatsGraphQL.GraphQL;
using CricketStatsGraphQL.GraphQL.BowlingInns;
using CricketStatsGraphQL.GraphQL.Countries;
using CricketStatsGraphQL.GraphQL.Dismissals;
using CricketStatsGraphQL.GraphQL.Matches;
using CricketStatsGraphQL.GraphQL.MatchTypes;
using CricketStatsGraphQL.GraphQL.Players;
using CricketStatsGraphQL.GraphQL.Venues;
using CricketStatsGraphQL.Models;
using CricketStatsGraphQL.Repositories;
using CricketStatsGraphQL.Repositories.Interfaces;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CricketStatsGraphQL
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration) {
              Configuration = configuration;  
        }


        public void ConfigureServices(IServiceCollection services)
        {
             services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("CricketStatsConnStr")));

            //   services
            //     .AddScoped<IBattingInn,BattingInnRepository>();
                // .AddScoped<IBowlingInn,BowlingInnRepository>()
                // .AddScoped<ICountry,CountryRepository>()
                // .AddScoped<IDismissal,DismissalRepository>()
                // .AddScoped<IMatch,MatchRepository>()
                // .AddScoped<IMatchType,MatchTypeRepository>()
                // .AddScoped<IPlayer,PlayerRepository>()
                // .AddScoped<IVenue,VenueRepository>();

             services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<PlayerType>()
                .AddType<VenueType>()
                .AddType<MatchTypeType>()
                .AddType<CountryType>()
                .AddType<DismissalType>()
                .AddType<BowlingInnType>()
                .AddType<BattingInnType>()
                .AddType<MatchesType>()
                .AddFiltering()
                .AddSorting()            
                .AddInMemorySubscriptions();

          

        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions() {
                GraphQLEndPoint = "/graphql"
            },"/graphql-voyager");
        }
    }
}
