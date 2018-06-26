namespace AW.Logic.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using AW.Core;
    using AW.Core.Models;

    public abstract class LogicBase
    {
        protected bool ValidateEmail(Context context, string email, string errorMessage = null)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > StringMaxLengths.EMAIL || !(new EmailAddressAttribute().IsValid(email)))
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    context.Errors.Add(errorMessage);
                }
                return false;
            }

            return true;
        }

        protected bool ValidateString(Context context, string text, int? maxLength = null, int? minLength = null, string errorMessage = null)
        {
            if (string.IsNullOrWhiteSpace(text)
                || (maxLength != null && text.Length > maxLength)
                || (minLength != null && text.Length < minLength))
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    context.Errors.Add(errorMessage);
                }
                return false;
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected string GetCurrentMethodName()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        protected void LogException(Exception ex, Context context, string className = null, string methodName = null)
        {
            throw new NotImplementedException();
        }
    }
}