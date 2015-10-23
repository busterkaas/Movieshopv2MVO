﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieShopDAL
{
    public static class DBInitializer
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MovieShopDBInitializer());
        }
    }
}
