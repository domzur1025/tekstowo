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
    }
}
