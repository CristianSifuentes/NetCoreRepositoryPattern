﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositorypattern.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipeCode { get; set; }
        public int Seating { get; set; }
        public bool ServesAlcohol { get; set; }
    }
}