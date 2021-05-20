using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace CricketStatsGraphQL.Models 
{
    public class Dismissal
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string DismissalCode { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string DismissalDesc { get; set; }
        
        public DateTimeOffset LastUpdated { get; set; }
    
        public ICollection<BattingInn> BattingInns { get; set; } = new List<BattingInn>();

    }
}