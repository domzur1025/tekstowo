using System;
using System.Collections.Generic;
using System.Text;

namespace Tekstowo.Domain.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int SongCounter { get; set; }
    }
}
