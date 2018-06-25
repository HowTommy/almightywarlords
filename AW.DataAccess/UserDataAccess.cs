using AW.DataAccess.Repositories.Base;

namespace AW.DataAccess
{
    using System;
    using AW.DataAccess.Interfaces;
    using AW.Models;

    public class UserDataAccess : RepositoryBase<User>, IUserDataAccess
    {
        public UserDataAccess(IDbContext dbContext) : base(dbContext) { }

        public User GetUserById(long userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public bool Create(User user)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long userId)
        {
            throw new NotImplementedException();
        }
    }
}