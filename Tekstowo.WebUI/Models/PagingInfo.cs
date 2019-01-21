using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tekstowo.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalSongs { get; set; }
        public int SongPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get { return (int)Math.Ceiling((decimal)TotalSongs / SongPerPage); } }
    }
}