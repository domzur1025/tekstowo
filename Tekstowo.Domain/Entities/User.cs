using System;
using System.Collections.Generic;
using System.Text;

namespace Tekstowo.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserNickname { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
    }
}
