using System;
using System.Collections.Generic;
using System.Text;
using Tekstowo.Domain.Entities;

namespace Tekstowo.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void RegisterUser(User user);
        void UpdateUser(User user);
    }
}
