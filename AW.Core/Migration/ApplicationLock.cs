namespace AW.Core.Migration
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Class that represent an application lock against an SQL server database.
    /// <para>It must be instantiated in a "using", and guaranty that multiple
    /// instantiations of the code inside the using are synchronized against the database.</para>
    /// </summary>
    public class ApplicationLock : IDisposable
    {
        /// <summary>
        /// Value to use to disable timeout when getting a lock
        /// </summary>
        public const int GET_LOCK_NO_TIMEOUT = -1;

        /// <summary>
        /// SQL command to get the lock.
        /// </summary>
        public const string GET_LOCK_COMMAND = @"DECLARE @result int; EXEC @result = sp_getapplock @Resource, @LockMode, @LockOwner, @LockTimeout SELECT @result";

        /// <summary>
        /// SQL command to release the lock.
        /// </summary>
        private const string RELEASE_LOCK_COMMAND = @"DECLARE @result int; EXEC @result = sp_releaseapplock @Resource SELECT @result";

        /// <summary>
        /// Lock used to avoid calling TryGetLock and ReleaseLock at the same time.
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLock"/> class.
        /// </summary>
        /// <param name="lockName">The name of the application lock.</param>
        /// <param name="connectionString">The connection string to contact the database.</param>
        public ApplicationLock(string lockName, string connectionString)
        {
            LockName = lockName;
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ApplicationLock"/> class.
        /// </summary>
        ~ApplicationLock()
        {
            DisposeConnectionTransaction();
        }

        /// <summary>
        /// Gets the name of the lock
        /// </summary>
        public string LockName { get; private set; }

        /// <summary>
        /// Gets the connection string that will be used to obtain the lock
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Gets a value indicating whether we are actually owner of the lock
        /// </summary>
        public bool IsLockedByMe { get; private set; }

        /// <summary>
        /// Gets or sets the transaction used to maintain the lock
        /// </summary>
        private SqlTransaction Transaction { get; set; }

        /// <summary>
        /// Gets or sets the connection used to maintain the lock
        /// </summary>
        private SqlConnection Connection { get; set; }

        /// <summary>
        /// Try to obtain the lock.
        /// If <see cref="IsLockedByMe"/> is true just return true without re-request the database.
        /// </summary>
        /// <param name="timeoutInMilliseconds">The maximal time to wait to obtain the lock.
        /// <para>By default this is GET_LOCK_NO_TIMEOUT (-1), but even without specifying a timeout at this level,
        /// an sql timeout to obtain a response from the server or a deadlock cancelation could occur</para>
        /// </param>
        /// <returns>True if the lock was obtained, false otherwise.
        /// <para>This information is also exposed by the <see cref="IsLockedByMe"/> property.</para>
        /// </returns>
        public bool TryGetLock(int timeoutInMilliseconds = GET_LOCK_NO_TIMEOUT)
        {
            lock (_lock)
            {
                if (!IsLockedByMe)
                {
                    InitializeConnectionTransaction();

                    GetApplicationLockStatus status = CallGetLock(timeoutInMilliseconds);

                    if (status >= 0)
                    {
                        IsLockedByMe = true;
                    }
                    else
                    {
                        DisposeConnectionTransaction();
                    }
                }
            }

            return IsLockedByMe;
        }

        /// <summary>
        /// Explicitly release the application lock.
        /// <para>If <see cref="IsLockedByMe"/> is false, do nothing.</para>
        /// <para>nb: if the lock is not explicitly released, it will be released when the object will be disposed.</para>
        /// </summary>
        public void ReleaseLock()
        {
            lock (_lock)
            {
                if (IsLockedByMe)
                {
                    ReleaseLockStatus status = CallReleaseLock();

                    if (status >= 0)
                    {
                        IsLockedByMe = false;
                        DisposeConnectionTransaction();
                    }
                }
            }
        }

        /// <summary>
        /// Release the connection and transaction that are keeping alive the lock.
        /// As we define the transaction as owner of the lock, this will cause the lock to be released at SQL server side.
        /// </summary>
        public void Dispose()
        {
            DisposeConnectionTransaction();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Initialize the connection and transaction objects
        /// </summary>
        private void InitializeConnectionTransaction()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        /// <summary>
        /// Dispose the connection and transaction objects if they are existing
        /// </summary>
        private void DisposeConnectionTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }

            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }
        }

        /// <summary>
        /// Call the sp_getapplock store procedure.
        /// The connection and transaction should be initialized before calling this method.
        /// </summary>
        /// <param name="timeoutInMilliseconds">The maximal time to wait to obtain the lock.</param>
        /// <returns>The status of the lock acquisition</returns>
        private GetApplicationLockStatus CallGetLock(long timeoutInMilliseconds)
        {
            using (var command = new SqlCommand(GET_LOCK_COMMAND, Connection))
            {
                command.Transaction = Transaction;

                command.Parameters.AddWithValue("@Resource", LockName);
                command.Parameters.AddWithValue("@LockMode", "Exclusive");
                command.Parameters.AddWithValue("@LockOwner", "Transaction");
                command.Parameters.AddWithValue("@LockTimeout", timeoutInMilliseconds);

                var status = (GetApplicationLockStatus)(int)command.ExecuteScalar();

                return status;
            }
        }

        /// <summary>
        /// Call the sp_releaseapplock store procedure.
        /// The connection and transaction should be initialized before calling this method.
        /// </summary>
        /// <returns>The status of the lock release</returns>
        private ReleaseLockStatus CallReleaseLock()
        {
            using (var command = new SqlCommand(RELEASE_LOCK_COMMAND, Connection))
            {
                command.Transaction = Transaction;

                command.Parameters.AddWithValue("@Resource", LockName);

                var status = (ReleaseLockStatus)(int)command.ExecuteScalar();

                return status;
            }
        }
    }
}
