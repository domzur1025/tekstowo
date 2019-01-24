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

        public int CheckIdArtist(string Name)
        {
            IEnumerable<Artist> artist= repository.Artists.Where(a => a.Name == Name);
            int id=0;
            if (artist.Count() == 1)
            {
                Artist tempArtist = artist.First();
                id = tempArtist.ArtistId;
            }
            
            return id;
        }

        public int AddArtist(string Name)
        {
            int id = CheckIdArtist(Name);
            if(id==0)
            {
                //Dodanie do bazy danych.
            }
            return id;
        }
    }
}