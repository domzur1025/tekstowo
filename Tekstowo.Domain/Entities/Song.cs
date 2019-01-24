using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Tekstowo.Domain.Entities
{
    public class Song
    {
        [HiddenInput(DisplayValue=false)]
        public int SongId { get; set; }

        [HiddenInput(DisplayValue =false)]
        public int ArtistId { get; set; }

        
        public string Name { get; set; }

        public string ArtistName { get; set; }

        
        public string Lyrics { get; set; }
    }
}
