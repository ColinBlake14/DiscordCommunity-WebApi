using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }

        public string FavoriteUserName { get; set; }

        public int FavoriteServerId { get; set; }
    }
}
