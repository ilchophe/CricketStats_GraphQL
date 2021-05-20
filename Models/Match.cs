using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate.Types;

namespace CricketStatsGraphQL.Models 
{

    public class Match
    {

        [Key]
        public int Id { get; set; }


        public short MatchNumber { get; set; }

        [Required]
        public int HomeCountryId { get; set; }

        [Required]
        public int AwayCountryId { get; set; }

        [Required]
        public int VenueId { get; set; }

        [Required]
        public int MatchTypeId { get; set; }

        public DateTimeOffset MatchStartDate { get; set; }

        public int TossWinnerCountryId { get; set; }

        public DateTimeOffset LastUpdated { get; set; }
    
        public ICollection<BattingInn> BattingInns { get; set; } = new List<BattingInn>();
        public ICollection<BowlingInn> BowlingInns { get; set; } = new List<BowlingInn>();

        public virtual Country CountryHome { get; set; }

        public virtual Country CountryAway { get; set; }

        public virtual Country CountryTossWon { get; set; }

        public MatchType MatchType { get; set; }
        public Venue Venue { get; set; }

    }

}