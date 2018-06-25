namespace AW.Core
{
    /// <summary>
    ///  Enumeration of the possible return values for the sp_releaseapplock store procedure
    /// </summary>
    public enum ReleaseLockStatus
    {
        /// <summary>
        /// Indicates a parameter validation or other call error.
        /// </summary>
        Error = -999,

        /// <summary>
        /// Lock was successfully released.
        /// </summary>
        Released = 0
    }
}
