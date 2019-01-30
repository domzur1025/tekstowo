using System;
using System.Collections.Generic;
using System.Text;
using Tekstowo.Domain.Abstract;
using Tekstowo.Domain.Entities;

namespace Tekstowo.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public void RegisterUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User dbEntry = context.Users.Find(user.UserId);
            if(dbEntry!=null)
            {
                dbEntry.UserNickname = user.UserNickname;
                dbEntry.UserType = user.UserType;
                context.SaveChanges();
            }
            
        }
    }
}
