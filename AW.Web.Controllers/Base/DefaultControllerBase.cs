using System.Collections.Generic;
using AW.Core;

namespace AW.Web.Controllers.Base
{
    using System.Web.Mvc;

    public abstract class DefaultControllerBase : Controller
    {
        protected Context CreateContext()
        {
            return new Context() { Errors = new List<string>(), UserId = null };
        }
    }
}
