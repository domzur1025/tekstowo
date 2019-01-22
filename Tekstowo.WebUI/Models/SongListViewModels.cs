using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tekstowo.Domain.Entities;

namespace Tekstowo.WebUI.Models
{
    public class SongListViewModels
    {
        public IEnumerable<Song> Songs { get; set; }
        public SongPagingInfo SongPagingInfo { get; set; }
        public int CurrentArtistId { get; set; }
    }
}