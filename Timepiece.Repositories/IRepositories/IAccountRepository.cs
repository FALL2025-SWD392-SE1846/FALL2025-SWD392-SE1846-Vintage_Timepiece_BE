using Timepiece.Repositories.Base;
using Timepiece.Repositories.Models;

namespace Timepiece.Repositories.IRepositories
{
    public interface IAccountRepository : IGenericRepository<account>
    {
        Task<account?>  GetAccountByUsernameAsync(string username);
        Task<account?> GetAccountByPhoneNumberAsync(string phoneNumber);
        Task<List<account>> GetAccountsByRoleIdAsync();
        Task<List<account>> GetAllAccount();
    }
}
