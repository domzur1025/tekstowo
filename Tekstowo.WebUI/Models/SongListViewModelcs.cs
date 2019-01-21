using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tekstowo.Domain.Entities;

namespace Tekstowo.WebUI.Models
{
    public class SongListViewModelcs
    {
        public IEnumerable<Song> Songs { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}