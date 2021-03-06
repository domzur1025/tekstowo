﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekstowo.Domain.Abstract;
using Tekstowo.Domain.Entities;

namespace Tekstowo.WebUI.Controllers
{
    public class AdminController : Controller
    {
        ISongRepository songRepository;
        IArtistRepository artistRepository;
        IUserRepository userRepository;

        // GET: Admin
        public AdminController(ISongRepository songRepository, IArtistRepository artistRepository, IUserRepository userRepository)
        {
            this.songRepository = songRepository;
            this.artistRepository = artistRepository;
            this.userRepository = userRepository;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult SongList()
        {
            return View(songRepository.Songs);
        }

        public ViewResult ArtistList()
        {
            return View(artistRepository.Artists);
        }

        public ViewResult EditSong(int songId)
        {
            Song song = songRepository.Songs.FirstOrDefault(s => s.SongId == songId);
            return View(song);
        }

        [HttpPost]
        public ActionResult EditSong(Song song)
        {
            if (ModelState.IsValid)
            {
                Song tempSong = songRepository.Songs.FirstOrDefault(s => s.SongId == song.SongId);
                
                if (tempSong.ArtistName != song.ArtistName)
                {
                    artistRepository.DecreseSongCounter(new Artist { ArtistId = tempSong.ArtistId });
                    int id = 0;
                    Artist tempArtist = artistRepository.Artists.FirstOrDefault(a => a.Name == song.ArtistName);
                    if (tempArtist != null) id = tempArtist.ArtistId;
                    if (id == 0)
                    {
                        artistRepository.SaveArtist(new Artist { Name = song.ArtistName, ArtistId = 0, SongCounter = 0 });
                        tempArtist = artistRepository.Artists.FirstOrDefault(a => a.Name == song.ArtistName);
                        song.ArtistId = tempArtist.ArtistId;
                        artistRepository.IncreseSongCounter(new Artist { ArtistId = song.ArtistId });
                    }
                    else
                    {
                        song.ArtistId = id;
                        artistRepository.IncreseSongCounter(new Artist { Name = song.ArtistName, ArtistId = song.ArtistId, SongCounter = 0 });
                    }
                        
                }
                songRepository.SaveSong(song);
                TempData["message"] = string.Format("Zapisano {0} - {1}", song.ArtistName, song.Name);
                return RedirectToAction("SongList");
            }
            else
            {
                return View(song);
            }
        }

        public ActionResult DeleteSong(int SongId)
        {
            Song song = songRepository.Songs.First(s => s.SongId == SongId);
            if (song != null)
            {
                artistRepository.DecreseSongCounter(new Artist { ArtistId = song.ArtistId });
                songRepository.DeleteSong(song);
            }
            return RedirectToAction("SongList","Admin");
        }

        public ViewResult UsersList()
        {
            return View(userRepository.Users);
        }

        public ViewResult EditUser(int userId)
        {
            User user = userRepository.Users.First(u => u.UserId == userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if(ModelState.IsValid)
            {
                userRepository.UpdateUser(user);
                TempData["message"] = "Zaktualizowano dane użytkownika";
            }
            return RedirectToAction("UsersList", "Admin");
        }
    }
}