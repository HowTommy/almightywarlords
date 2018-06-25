namespace AW.Core
{
    /// <summary>
    /// Enumeration of the possible return values for the sp_getapplock store procedure
    /// </summary>
    public enum GetApplicationLockStatus
    {
        /// <summary>
        /// Indicates a parameter validation or other call error.
        /// </summary>
        Error = -999,

        /// <summary>
        /// The lock request was chosen as a deadlock victim.
        /// </summary>
        DeadlockVictim = -3,

        /// <summary>
        /// The lock request was cancelled.
        /// </summary>
        Cancelled = -2,

        /// <summary>
        /// The lock request timed out.
        /// </summary>
        Timeout = -1,

        /// <summary>
        /// The lock was successfully granted synchronously.
        /// </summary>
        GrantedSynchronously = 0,

        /// <summary>
        /// The lock was granted successfully after waiting for other incompatible locks to be released.
        /// </summary>
        GrantedAfterADelay = 1
    }
}
