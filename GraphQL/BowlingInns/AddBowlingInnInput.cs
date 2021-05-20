using System;

namespace CricketStatsGraphQL.GraphQL.BowlingInns {

    public record AddBowlingInnInput(
        int MatchId,
        bool FirstInns,
        int CountryId,
        int PlayerId,
        int Runs,
        int Wickets,
        int Maidens,
        int Overs,
        int Extras
        );


      



}