using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekstowo.Domain.Abstract;
using Tekstowo.Domain.Entities;

namespace Tekstowo.WebUI.Controllers
{
    public class SongController : Controller
    {
        private ISongRepository repository;

        // GET: Song
        public SongController(ISongRepository songRepository)
        {
            this.repository = songRepository;
        }

        public ViewResult List()
        {
            return View(repository.Songs);
        }
    }
}