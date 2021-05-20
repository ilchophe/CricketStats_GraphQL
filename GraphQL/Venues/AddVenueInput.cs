using System;

namespace CricketStatsGraphQL.GraphQL.Venues {

    public record AddVenueInput(
            
            string VenueName,
            string VenueCity,
            int CountryId
            
        );


      



}