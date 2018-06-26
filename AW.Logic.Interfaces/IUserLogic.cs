namespace AW.Logic.Interfaces
{
    using AW.Core;
    using AW.Models;

    public interface IUserLogic
    {
        User GetUserByEmailAndPassword(string email, string password, Context context);
    }
}