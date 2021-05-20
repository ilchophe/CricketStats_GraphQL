using System;
using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace CricketStatsGraphQL.Models 
{
    public class BowlingInn
    {
        [Key]    
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        public bool FirstInns { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [DefaultValue(0)]
        public int Runs { get; set; }

        [DefaultValue(0)]
        public int Wickets { get; set; }

        [DefaultValue(0)]
        public int Maidens { get; set; }

        [DefaultValue(0)]
        public int Overs { get; set; }

        [DefaultValue(0)]
        public int Extras { get; set; }

        public DateTimeOffset LastUpdated { get; set; }
    
        public Country Country { get; set; }
        public Match Match { get; set; }
        public Player Player { get; set; }
    }
}