namespace AW.DataAccess.DatabaseInitialization
{
    using System.Data.Entity;
    using System.Diagnostics;
    using AW.Core;
    using AW.Core.Migration;
    using AW.DataAccess.DataContext;
    using AW.DataAccess.Migrations;

    public static class ApplicationDatabaseInitializer
    {
        /// <summary>
        /// Database lock name.
        /// </summary>
        private const string LOCK_NAME = "ApplicationLock";

        /// <summary>
        /// Initialize the application database.
        /// </summary>
        public static void InitializeDatabase()
        {
            using (var databaseUpdateLock = new ApplicationLock(LOCK_NAME, ApplicationSettings.ApplicationConnectionString))
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Try to obtain the lock on the database. If not obtained during the specified interval, retry.
                while (!databaseUpdateLock.TryGetLock(ApplicationSettings.DatabaseInitializationRetryInterval))
                {
                    // After the specified timeout, if the lock is still not obtained, throw an exception to stop the application starting
                    if (stopwatch.Elapsed.TotalMilliseconds >= ApplicationSettings.DatabaseInitializationTimeout)
                    {
                        throw new DatabaseUpdateException("Timeout trying to get the lock on the application database.");
                    }
                }

                stopwatch.Stop();

                // If the the lock is obtained, initialize the database
                try
                {
                    Database.SetInitializer(new MigrateDatabaseToLatestVersion<AWContext, Configuration>());

                    using (var context = new AWContext())
                    {
                        context.Database.Initialize(force: true);
                    }
                }
                finally
                {
                    databaseUpdateLock.ReleaseLock();
                }
            }
        }
    }
}
