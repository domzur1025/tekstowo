using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekstowo.Domain.Abstract;
using Tekstowo.Domain.Entities;
using Tekstowo.WebUI.Models;

namespace Tekstowo.WebUI.Controllers
{
    public class SongController : Controller
    {
        private ISongRepository repository;
        private IArtistRepository artistRepository;
        public int PageSize = 4;

        // GET: Song

        public SongController(ISongRepository songRepository, IArtistRepository artistRepository)
        {
            this.repository = songRepository;
            this.artistRepository = artistRepository;
        }

        public ViewResult Lyrics(int SongId)
        {
            SongListViewModels model = new SongListViewModels
            {
                Songs = repository.Songs.Where(m => m.SongId == SongId).Take(1)
            };
            
            return View(model);
        }
        
        public ViewResult List(int? ArtistId, int page = 1)
        {
            SongListViewModels model;
            if (ArtistId != null)
            {
                model = new SongListViewModels
                {
                    Songs = repository.Songs.Where(m =>  m.ArtistId == ArtistId).
                    OrderBy(s => s.Name),
                    
                    CurrentArtistId = (int)ArtistId
                };
            }
            else
            {
                model = new SongListViewModels
                {
                    Songs = repository.Songs.OrderByDescending(s => s.SongId).Take(10)
                };
            }
            return View(model);
        }

        public ViewResult AddLyrics()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddLyrics(Song song)
        {
            ArtistController artistController = new ArtistController(artistRepository);
            int id = artistController.CheckIdArtist(song.ArtistName);
            if (id == 0)
            {
                id = artistController.AddArtist(song.ArtistName);
            }
            repository.SaveSong(new Song { SongId = 0, ArtistId = id, ArtistName = song.ArtistName, Lyrics = song.Lyrics, Name = song.Name });
            int songId = repository.Songs.Last().SongId;
            TempData["message"] = "Dodano";
            return RedirectToAction("Index", "Home");
           
        }

    }
}
        