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
        public int PageSize = 4;

        // GET: Song
        public SongController(ISongRepository songRepository)
        {
            this.repository = songRepository;
        }

        public ViewResult List(int page=1)
        {
            return View(repository.Songs.OrderBy(p=>p.SongId).Skip((page-1)*PageSize).Take(PageSize));
        }
    }
}