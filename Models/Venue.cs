using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace CricketStatsGraphQL.Models 
{

    public class Venue
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string VenueName { get; set; }

        [MaxLength(150)]
        public string VenueCity { get; set; }

        public int CountryId { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
    
        public Country Country { get; set; }
        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }

}