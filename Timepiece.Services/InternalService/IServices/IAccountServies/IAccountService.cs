using Timepiece.Common.DTOs.AccountDTOs;
using Timepiece.Services.Base;

namespace Timepiece.Services.InternalService.IServices.IAccountServies
{
    public interface IAccountService
    {
        Task<IserviceResult> GetAccounByIdAsync(Guid id);
        Task<IserviceResult> GetAllAccountsAsync();
        Task<IserviceResult> CreateAccountAsync(CreateAccountDto account);
        Task<IserviceResult> UpdateAccountAsync(Guid id, UpdateAccountDto account);
        Task<IserviceResult> DeleteAccountAsync(Guid id);
    }
}
