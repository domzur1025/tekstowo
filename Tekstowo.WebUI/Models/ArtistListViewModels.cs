using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tekstowo.Domain.Entities;

namespace Tekstowo.WebUI.Models
{
    public class ArtistListViewModels
    {
        public IEnumerable<Artist> Artists { get; set; }
        public ArtistPagingInfo ArtistPagingInfo { get; set; }
    }
}