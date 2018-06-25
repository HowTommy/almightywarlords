namespace AW.DataAccess.Interfaces
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    /// <summary>
    /// Interface to a DbContext
    /// Allows IoC
    /// </summary>
    public interface IDbContext : IDisposable, IObjectContextAdapter
    {
        /// <summary>
        /// Creates a Database instance for this context that allows for creation/deletion/existence checks
        /// for the underlying database.
        /// </summary>
        Database Database { get; }

        /// <summary>
        /// Returns a DbSet instance for access to entities of the given type in the context, the ObjectStateManager, and the underlying store.
        /// </summary>
        /// <remarks>See the DbSet class for more details.</remarks>
        /// <typeparam name="TEntity">The type entity for which a set should be returned.</typeparam>
        /// <returns>A set for the given entity type.</returns>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        /// <summary>
        /// Gets a <see cref="T:System.Data.Entity.Infrastructure.DbEntityEntry`1"/> object for the given entity providing access to
        /// information about the entity and the ability to perform actions on the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity. </typeparam><param name="entity">The entity.</param>
        /// <returns>An entry for the entity.</returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>The number of objects written to the underlying database.</returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        int SaveChanges();

        /// <summary>
        /// Returns a non-generic DbSet instance for access to entities of the given
        /// type in the context, the ObjectStateManager, and the underlying store.
        /// </summary>
        /// <param name="entityType">The type of entity for which a set should be returned.</param>
        /// <returns>A set for the given entity type.</returns>
        DbSet Set(Type entityType);
    }
}
