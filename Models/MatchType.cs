using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace CricketStatsGraphQL.Models 
{

    public class MatchType 
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string MatchTypeName { get; set; }
       
        public DateTimeOffset LastUpdated { get; set; }
    
        public ICollection<Match> Matches { get; set; } = new List<Match>();

    }
}