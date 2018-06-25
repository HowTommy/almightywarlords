namespace AW.Core
{
    public static class ApplicationSettings
    {
        private const string APPLICATION_CONNECTIONSTRING_SETTING_NAME = "Application.ConnectionString";

        public static string ApplicationConnectionString => APPLICATION_CONNECTIONSTRING_SETTING_NAME;
    }
}
