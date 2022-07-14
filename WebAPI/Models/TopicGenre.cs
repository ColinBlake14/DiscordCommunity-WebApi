using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TopicGenre
    {
        public int TopicGenreId { get; set; }

        public int TopicId { get; set; }

        public int GenreId { get; set; }
    }
}
