using Microsoft.EntityFrameworkCore.Storage;
using Timepiece.Repositories.IRepositories;
using Timepiece.Repositories.Models;

namespace Timepiece.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VintageWatchDbContext _context;

        private IAccountRepository accountRepository;


        //Dependency Injection (Constructor Injection)
        public UnitOfWork(VintageWatchDbContext context)
        {
            _context = context;
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
        public IAccountRepository AccountRepository
        {
            get
            {
               return accountRepository ??= new Repositories.AccountRepository(_context);
            }
        }
    }
}
