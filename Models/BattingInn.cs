using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate.Types;

namespace CricketStatsGraphQL.Models 
{

    public class BattingInn 
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
        public int BallsFaced { get; set; }

        [DefaultValue(0)]
        public int Fours { get; set; }

        [DefaultValue(0)]
        public int Sixes { get; set; }

       
        public int? BowlerPlayerId { get; set; }

        public int? FielderPlayerId { get; set; }

        public int DismissalId { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
    
        public Dismissal Dismissal { get; set; }
        public Country Country { get; set; }
        public Match Match { get; set; }
        public Player Player { get; set; }

        [ForeignKey("BowlerPlayerId")]
        public virtual Player PlayerBowler { get; set; }

        [ForeignKey("FielderPlayerId")]
        public virtual Player PlayerFielder { get; set; }

    }

}