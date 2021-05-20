using System;

namespace CricketStatsGraphQL.GraphQL.Players {

    public record AddPlayerInput(
            
        string PlayerName,
        string PlayerSurname,
        int CountryId,
        DateTime Dob,
        bool Retired
            
    );


      



}