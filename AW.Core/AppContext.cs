namespace AW.Core
{
    using System.Collections.Generic;

    public class Context
    {
        public List<string> Errors { get; set; }

        public long? UserId { get; set; }
    }
}
