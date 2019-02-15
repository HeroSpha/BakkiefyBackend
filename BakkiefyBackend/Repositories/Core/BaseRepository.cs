using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BakkiefyBackend.Models;

namespace BakkiefyBackend.Repositories.Core
{
    public class BaseRepository
    {
        protected BakkieDbContext _bakkieDbContext { get; private set; }
        public BaseRepository(BakkieDbContext bakkieDbContext)
        {
            _bakkieDbContext = bakkieDbContext;
        }
    }
}