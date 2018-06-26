namespace AW.Logic.Base
{
    using System.ComponentModel.DataAnnotations;
    using AW.Core;
    using AW.Core.Models;
    using AW.Resources;

    public abstract class BaseLogic
    {
        protected bool ValidateEmail(Context context, string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > StringMaxLengths.EMAIL || !(new EmailAddressAttribute().IsValid(email)))
            {
                return false;
            }

            return true;
        }

        protected bool ValidateString(Context context, string text, int? maxLength = null, int? minLength = null)
        {
            if (string.IsNullOrWhiteSpace(text)
                || (maxLength != null && text.Length > maxLength)
                || (minLength != null && text.Length < minLength))
            {
                return false;
            }

            return true;
        }
    }
}