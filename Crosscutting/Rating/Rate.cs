﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscutting.Rating
{
    public class Rate
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string OwnerUsername { get; set; }

        public string MembersUsernamesList { get; set; }

        public double Rating { get; set; }

        public string RatesList { get; set; }
    }
}
