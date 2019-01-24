using System;
using System.Collections.Generic;
using System.Text;
using Tekstowo.Domain.Abstract;
using Tekstowo.Domain.Entities;

namespace Tekstowo.Domain.Concrete
{
    public class EFArtistRepository :IArtistRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Artist> Artists
        {
            get { return context.Artists; }
        }

        public void SaveArtist(Artist artist)
        {
            if (artist.ArtistId==0)
            {
                context.Artists.Add(artist);
            }
            context.SaveChanges();
            IncreseSongCounter(artist);
        }

        public void IncreseSongCounter(Artist artist)
        {
            Artist dbEntry = context.Artists.Find(artist.ArtistId);
            if (dbEntry == null)
            {
                SaveArtist(artist);
            }
            else
            {
                dbEntry.SongCounter++;
                context.SaveChanges();
            }
        }
    }
}
