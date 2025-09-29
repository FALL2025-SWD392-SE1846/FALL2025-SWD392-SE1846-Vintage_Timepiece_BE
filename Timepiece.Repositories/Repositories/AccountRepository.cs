using Microsoft.EntityFrameworkCore;
using Timepiece.Repositories.Base;
using Timepiece.Repositories.IRepositories;
using Timepiece.Repositories.Models;

namespace Timepiece.Repositories.Repositories
{
    public class AccountRepository : GenericRepository<account>, IAccountRepository
    {
        private readonly VintageWatchDbContext _context;

        public AccountRepository()
        {
            
        }

        public AccountRepository(VintageWatchDbContext context)
        {
            _context = context;
        }

        public async Task<account?> GetAccountByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.accounts
                .Include(a => a.role)
                .FirstOrDefaultAsync(a => a.phone_number == phoneNumber);
        }

        public async Task<account?> GetAccountByUsernameAsync(string username)
        {
            return await _context.accounts
                .Include(a => a.role)
                .FirstOrDefaultAsync(a => a.full_name == username);
        }

        public async Task<List<account>> GetAccountsByRoleIdAsync()
        {
            return await _context.accounts
                .Include(a => a.role)
                .ToListAsync();
        }

        public async Task<List<account>> GetAllAccount()
        {
            return await _context.accounts
                .Include(a => a.role)
                .ToListAsync();
        }
    }
}
