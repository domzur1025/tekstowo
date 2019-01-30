using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tekstowo.Domain.Abstract;
using Tekstowo.WebUI.Models;

namespace Tekstowo.WebUI.Controllers
{
    public class NavController : Controller
    {
        private ISongRepository songRepository;
        private IArtistRepository artistRepository;

        public NavController(ISongRepository SongRepository,IArtistRepository ArtistRepository)
        {
            songRepository = SongRepository;
            artistRepository = ArtistRepository;
        }

        // GET: Nav
        public PartialViewResult SideMenuNewest()
        {
            SongListViewModels model = new SongListViewModels
            {
                Songs = songRepository.Songs.OrderByDescending(s => s.SongId).Take(5)
            };
            /*IEnumerable<string> newestSongArtistName =repository.Songs.OrderByDescending(s => s.SongId).Select(s => s.ArtistName).Take(5);
            string[] newestSongsArtistNameArray = newestSongArtistName.ToArray();
            IEnumerable<string> newestSonsgName = repository.Songs.OrderByDescending(s=>s.SongId).Select(s => s.Name).Take(5);
            string[] newestSongsNameArray = newestSonsgName.ToArray();
            string[] newestSongsArray = new string[5];
            for(int i = 0; i < newestSongsArtistNameArray.Count(); i++)
            {
                newestSongsArray[i] = newestSongsArtistNameArray[i] + " - " + newestSongsNameArray[i];
            }
            IEnumerable<string> newestSongs = newestSongsArray;*/
            
            return PartialView(model);
        }

        public PartialViewResult SideMenuPopular()
        {
            ArtistListViewModels model = new ArtistListViewModels
            {
                Artists = artistRepository.Artists.OrderByDescending(m => m.SongCounter).Take(5)
            };
            return PartialView(model);
        }

    }
}