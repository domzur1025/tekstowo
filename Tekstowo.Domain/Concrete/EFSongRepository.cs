using System;
using System.Collections.Generic;
using System.Text;
using Tekstowo.Domain.Abstract;
using Tekstowo.Domain.Entities;

namespace Tekstowo.Domain.Concrete
{
    public class EFSongRepository : ISongRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Song> Songs {
            get { return context.Songs; }
        }
        
        public void SaveSong(Song song)
        {
            if (song.SongId == 0)
            {
                context.Songs.Add(song);
            }
            else
            {
                Song dbEntry = context.Songs.Find(song.SongId);
                if (dbEntry != null)
                {
                    dbEntry.Name = song.Name;
                    dbEntry.ArtistName = song.ArtistName;
                    dbEntry.ArtistId = song.ArtistId;
                    dbEntry.Lyrics = song.Lyrics;
                }
            }
            context.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            Song dbEntry = context.Songs.Find(song.SongId);
            if (dbEntry != null)
            {
                context.Songs.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
