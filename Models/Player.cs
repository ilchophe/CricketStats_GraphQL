using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate.Types;

namespace CricketStatsGraphQL.Models 
{

    public class Player
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string PlayerName { get; set; }

        [Required]
        [MaxLength(255)]
        public string PlayerSurname { get; set; }

        [Required]
        public int CountryId { get; set; }

        public DateTime Dob { get; set; }

        [DefaultValue(0)]
        public bool Retired { get; set; }

        public DateTimeOffset LastUpdated { get; set; }
    
        public Country Country { get; set; }
        public ICollection<BowlingInn> BowlingInns { get; set; } = new List<BowlingInn>();
        public ICollection<BattingInn> BattingInns { get; set; } = new List<BattingInn>();

        [InverseProperty("PlayerBowler")]
        public ICollection<BattingInn> BowlerInns { get; set; } = new List<BattingInn>();

        [InverseProperty("PlayerFielder")]
        public ICollection<BattingInn> FielderInns { get; set; } = new List<BattingInn>();

    }

}