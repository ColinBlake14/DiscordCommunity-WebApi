﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Preference
    {
        public int PreferenceId { get; set; }

        public int UserId { get; set; }

        public int GenreId { get; set; }
    }
}
