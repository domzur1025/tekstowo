using System;
using System.Collections.Generic;
using System.Text;

namespace Tekstowo.Domain.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Lyrics { get; set; }
    }
}
