using System;
using System.Collections.Generic;
using System.Text;
using Tekstowo.Domain.Entities;

namespace Tekstowo.Domain.Abstract
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> Artists { get; }
        void SaveArtist(Artist artist);
        void IncreseSongCounter(Artist artist);
    }
}
