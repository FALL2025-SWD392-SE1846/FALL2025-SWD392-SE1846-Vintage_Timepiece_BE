using Microsoft.EntityFrameworkCore.Storage;
using Timepiece.Repositories.IRepositories;

namespace Timepiece.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        IAccountRepository AccountRepository { get; }
    }
}
