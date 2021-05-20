using System;

namespace CricketStatsGraphQL.GraphQL.BattingInns {

    public record AddBattingInnInput(
        int MatchId,
        bool FirstInns,
        int CountryId, 
        int PlayerId,
        int Runs,
        int BallsFaced,
        int Fours,
        int Sixes,
        int DismissalId,
        int? BowlerPlayerId,
        int? FielderPlayerId
        );


      



}