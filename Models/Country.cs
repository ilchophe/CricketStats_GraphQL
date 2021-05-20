using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate.Types;

namespace CricketStatsGraphQL.Models 
{
    public class Country
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string CountryCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string CountryDesc { get; set; }

        public DateTimeOffset LastUpdated { get; set; }
    
        public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<Venue> Venues { get; set; } = new List<Venue>();
        public ICollection<BattingInn> BattingInns { get; set; } = new List<BattingInn>();
        public ICollection<BowlingInn> BowlingInns { get; set; } = new List<BowlingInn>();

        [InverseProperty(nameof(Match.CountryHome))]
        public ICollection<Match> MatchesHomeCountries { get; set; } = new List<Match>();

        [InverseProperty(nameof(Match.CountryAway))]
        public ICollection<Match> MatchesAwayCountries { get; set; } = new List<Match>();

         [InverseProperty(nameof(Match.CountryTossWon))]
        public ICollection<Match> MatchesTossCountries { get; set; } = new List<Match>();

    }
}