namespace AW.DataAccess.Interfaces
{
    using AW.Models;

    public interface IUserDataAccess
    {
        User GetUserById(long userId);

        User GetUserByEmail(string login);

        bool Create(User user);

        bool Update(User user);

        bool Delete(long userId);
    }
}
