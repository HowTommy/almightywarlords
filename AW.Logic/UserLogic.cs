namespace AW.Logic
{
    using System;
    using BCrypt.Net;

    using AW.Core;
    using AW.Core.Models;
    using AW.DataAccess.Interfaces;
    using AW.Logic.Base;
    using AW.Logic.Interfaces;
    using AW.Models;
    using AW.Resources;

    public class UserLogic : LogicBase, IUserLogic
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserLogic(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public User GetUserByEmailAndPassword(string email, string password, Context context)
        {
            try
            {
                if (!ValidateEmail(context, email, Resource.Error_EnterValidEmail) ||
                    !ValidateString(context, password, StringMaxLengths.LARGE, StringMinLengths.PASSWORD, Resource.Error_EnterValidPassword))
                {
                    return null;
                }

                var user = _userDataAccess.GetUserByEmail(email);

                if (user == null
                    || BCrypt.HashPassword(password, user.Salt) != user.HashedPassword)
                {
                    context.Errors.Add(Resource.Error_UnknownUserOrWrongPassword);
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                context.Errors.Add(Resource.Error_Generic);

                LogException(ex, context, GetType().Name, GetCurrentMethodName());

                return null;
            }
        }
    }
}
