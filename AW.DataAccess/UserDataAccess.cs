namespace AW.DataAccess
{
    using AW.DataAccess.Repositories.Base;
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

        public User GetUserByEmail(string login)
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