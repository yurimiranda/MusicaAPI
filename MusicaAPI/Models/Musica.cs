using System.ComponentModel.DataAnnotations;

namespace MusicaAPI.Models
{
    public class Musica
    {
        [Key]
        public int Id { get; set; }

        public bool Favorita { get; set; }
        public int TrackId { get; set; }
        public string ArtistName { get; set; }
        public string TrackName { get; set; }
        public string ArtworkUrl60 { get; set; }
        public string TrackTimeMillis { get; set; }
    }
}