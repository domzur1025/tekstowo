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

        public ViewResult List(int page = 1)
        {
            SongListViewModelcs model = new SongListViewModelcs
            {
                Songs = repository.Songs.OrderBy(s => s.SongId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    SongPerPage = PageSize,
                    TotalSongs = repository.Songs.Count()
                }
            };
            return View(model);
        }

    }
}
        