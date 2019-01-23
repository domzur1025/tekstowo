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
    }
}
