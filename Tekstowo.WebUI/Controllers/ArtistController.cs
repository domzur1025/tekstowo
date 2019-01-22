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
    public class ArtistController : Controller
    {
        private IArtistRepository repository;
        public int PageSize = 10;

        // GET: Artist

        public ArtistController(IArtistRepository artistRepository)
        {
            this.repository = artistRepository;
        }

        public ViewResult List(int page=1)
        {
            ArtistListViewModels model = new ArtistListViewModels
            {
                Artists = repository.Artists.OrderBy(a => a.Name).Skip((page - 1) * PageSize).Take(PageSize),
                ArtistPagingInfo = new ArtistPagingInfo
                {
                    CurrentPage = page,
                    ArtistPerPage = PageSize,
                    TotalArtist = repository.Artists.Count()
                }
            };
            return View(model);
        }
    }
}