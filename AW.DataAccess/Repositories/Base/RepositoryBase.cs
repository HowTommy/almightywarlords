namespace AW.DataAccess.Repositories.Base
{
    using AW.DataAccess.Interfaces;

    public class RepositoryBase<TEntity>
    {
        protected IDbContext CurrentContext { get; }
        
        protected RepositoryBase(IDbContext dbContext)
        {
            CurrentContext = dbContext;
        }
    }
}
