namespace AW.Core.Models
{
    public static class StringMaxLengths
    {
        /// <summary>
        /// A very short string, like a language code
        /// </summary>
        public const int VERY_SMALL = 10;

        /// <summary>
        /// A short string like a label or a color
        /// </summary>
        public const int SMALL = 50;

        /// <summary>
        /// Maximum size for an Account password
        /// </summary>
        public const int PASSWORD = 128;

        /// <summary>
        /// A string which represents a name
        /// </summary>
        public const int NAME = 255;

        /// <summary>
        /// A string which represents an email address
        /// </summary>
        public const int EMAIL = 255;

        /// <summary>
        /// A large string like an address
        /// </summary>
        public const int LARGE = 500;

        /// <summary>
        /// A very long string displayed in a single line like a comment
        /// </summary>
        public const int ONE_LINE = 1024;

        /// <summary>
        /// The max length of an Url
        /// </summary>
        public const int URL = 2048;

        /// <summary>
        /// The max length of a long text
        /// </summary>
        public const int LONGTEXT = 4000;

        /// <summary>
        /// The max length of an extra large text (like some CSS or ToS)
        /// </summary>
        public const int EXTRA_LARGE = 10000;
    }
}
