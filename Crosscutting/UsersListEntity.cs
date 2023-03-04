﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscutting
{
    public class UsersListEntity : BaseEntity
    {
        public string Username { get; set; }

        public List<int> FavouriteMealsIds { get; set; } = new List<int>();
    }
}