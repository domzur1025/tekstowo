using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Tekstowo.Domain.Entities;

namespace Tekstowo.Domain.Concrete
{
    class EFDbContext:DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
