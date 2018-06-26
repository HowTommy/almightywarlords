namespace AW.Logic
{
    using AW.Core.Models;
    using AW.Logic.Base;
    using AW.DataAccess.Interfaces;
    using AW.Models;
    using AW.Logic.Interfaces;
    using AW.Core;
    using AW.Resources;
    using BCrypt.Net;
    using System;

    public class UserLogic : BaseLogic, IUserLogic
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
                if (!ValidateEmail(context, email) ||
                    !ValidateString(context, password, StringMaxLengths.LARGE, StringMinLengths.PASSWORD))
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
                // todo log error
                return null;
            }
        }
    }
}
