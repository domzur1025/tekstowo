﻿using System;
using System.Collections.Generic;
using Tekstowo.Domain.Entities;
using System.Text;

namespace Tekstowo.Domain.Abstract
{
    public interface ISongRepository
    {
        IEnumerable<Song> Songs { get; }
        void SaveSong(Song song);
        void DeleteSong(Song song);
    }
}
