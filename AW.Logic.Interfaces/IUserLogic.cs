namespace AW.Logic.Interfaces
{
    using System.Runtime.Remoting.Contexts;
    using AW.Models;

    public interface IUserLogic
    {
        User GetUserByEmailAndPassword(string email, string password, Context context);
    }
}