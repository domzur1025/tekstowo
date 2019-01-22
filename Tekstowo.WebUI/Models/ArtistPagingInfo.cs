using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tekstowo.WebUI.Models
{
    public class ArtistPagingInfo
    {
        public int TotalArtist { get; set; }
        public int ArtistPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get { return (int)Math.Ceiling((decimal)TotalArtist / ArtistPerPage); } }
    }
}