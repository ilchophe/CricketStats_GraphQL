using System;

namespace CricketStatsGraphQL.GraphQL.Matches {

    public record AddMatchInput(
        short MatchNumber,
        int HomeCountryId,
        int AwayCountryId,
        int VenueId,
        int MatchTypeId,
        DateTimeOffset MatchStartDate,
        int TossWinnerCountryId
        );


      



}