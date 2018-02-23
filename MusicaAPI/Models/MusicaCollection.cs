using System.Collections.Generic;

namespace MusicaAPI.Models
{
    public class MusicaCollection
    {
        public int ResultCount { get; set; }
        public List<Musica> Results { get; set; }
    }
}