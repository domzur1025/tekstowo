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
        public int PageSize = 4;

        // GET: Song

        public SongController(ISongRepository songRepository)
        {
            this.repository = songRepository;
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
                    Songs = repository.Songs.Where(m => ArtistId == null || m.ArtistId == ArtistId).
                    OrderBy(s => s.SongId).
                    Skip((page - 1) * PageSize).
                    Take(PageSize),
                    
                    CurrentArtistId = (int)ArtistId
                };
            }
            else
            {
                model = new SongListViewModels();
            }

            return View(model);
        }

    }
}
        