using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tekstowo.Domain.Entities;

namespace Tekstowo.WebUI.Models
{
    public class UserListViewModels
    {
        public IEnumerable<User> Users { get; set; }
    }
}