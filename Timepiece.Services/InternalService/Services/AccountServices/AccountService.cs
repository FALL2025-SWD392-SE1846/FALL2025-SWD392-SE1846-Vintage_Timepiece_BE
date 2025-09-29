using Timepiece.Common.DTOs.AccountDTOs;
using Timepiece.Common.Enum.ServiceResult;
using Timepiece.Repositories.Mapper;
using Timepiece.Repositories.UnitOfWork;
using Timepiece.Services.Base;
using Timepiece.Services.InternalService.IServices.IAccountServies;

namespace Timepiece.Services.InternalService.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<IserviceResult> CreateAccountAsync(CreateAccountDto account)
        {
            try
            {
                if(account == null)
                {
                    return new ServiceResult
                    {
                        StatusCode = Const.ERROR_NOT_FOUND_CODE,
                        Message = Const.ERROR_NOT_FOUND_MSG,
                    };
                }
                var newAccount = account.ToCreate();
                await _unitOfWork.AccountRepository.CreateAsync(newAccount);
                return new ServiceResult
                {
                    StatusCode = Const.SUCCESS_CREATE_CODE,
                    Message = Const.SUCCESS_CREATE_MSG,
                    Data = newAccount.ToView()
                };
            }
            catch (Exception)
            {

                return new ServiceResult
                {
                    StatusCode = Const.ERROR_EXEPTION_CODE,
                    Message = Const.ERROR_EXEPTION_MSG,
                };
            }
        }

        public async Task<IserviceResult> DeleteAccountAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return new ServiceResult
                    {
                        StatusCode = Const.ERROR_NOT_FOUND_CODE,
                        Message = Const.ERROR_NOT_FOUND_MSG,
                    };
                }
                var existingAccount = await _unitOfWork.AccountRepository.GetByIdAsync(id);
                if (existingAccount == null)
                {
                    return new ServiceResult
                    {
                        StatusCode = Const.FAIL_READ_CODE,
                        Message = Const.FAIL_READ_MSG,
                    };
                }

                await _unitOfWork.AccountRepository.RemoveAsync(existingAccount);
                return new ServiceResult
                {
                    StatusCode = Const.SUCCESS_DELETE_CODE,
                    Message = Const.SUCCESS_DELETE_MSG,
                };
            }
            catch (Exception)
            {

                return new ServiceResult
                {
                    StatusCode = Const.ERROR_EXEPTION_CODE,
                    Message = Const.ERROR_EXEPTION_MSG,
                };
            }
        }

        public async Task<IserviceResult> GetAccounByIdAsync(Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    return new ServiceResult
                    {
                        StatusCode = Const.ERROR_NOT_FOUND_CODE,
                        Message = Const.ERROR_NOT_FOUND_MSG,
                    };
                }
                var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
                if (account == null)
                {
                    return new ServiceResult
                    {
                        StatusCode = Const.FAIL_READ_CODE,
                        Message = Const.FAIL_READ_MSG,
                    };
                }
                var accountDto = account.ToView();

                return new ServiceResult
                {
                    StatusCode = Const.SUCCESS_READ_CODE,
                    Message = Const.SUCCESS_READ_MSG,
                    Data = accountDto
                };
            }
            catch (Exception)
            {

                return new ServiceResult
                {
                    StatusCode = Const.ERROR_EXEPTION_CODE,
                    Message = Const.ERROR_NOT_FOUND_MSG,
                };
            }
        }

        public async Task<IserviceResult> GetAllAccountsAsync()
        {
            try
            {
                var account = _unitOfWork.AccountRepository.GetAllAccount();
                if (account == null)
                {
                    return new ServiceResult
                    {
                        StatusCode = Const.FAIL_READ_CODE,
                        Message = Const.FAIL_READ_MSG,
                    };
                }
                var accountDto = new List<GetAccountDto>();
                accountDto.AddRange(account.Result.Select(a => a.ToView()));
                return new ServiceResult
                {
                    StatusCode = Const.SUCCESS_READ_CODE,
                    Message = Const.SUCCESS_READ_MSG,
                    Data = accountDto
                };
            }
            catch (Exception)
            {

                return new ServiceResult
                {
                    StatusCode = Const.ERROR_EXEPTION_CODE,
                    Message = Const.ERROR_EXEPTION_MSG,
                };
            }
        }

        public async Task<IserviceResult> UpdateAccountAsync(Guid id, UpdateAccountDto account)
        {
            try
            {
                if (account == null || account.account_id == Guid.Empty)
                {
                    return new ServiceResult
                    {
                        StatusCode = Const.ERROR_NOT_FOUND_CODE,
                        Message = Const.ERROR_EXEPTION_MSG,
                    };
                }
                var existingAccount = await _unitOfWork.AccountRepository.GetByIdAsync(account.account_id);
                if (existingAccount == null)
                {
                    return new ServiceResult
                    {
                        StatusCode = Const.FAIL_READ_CODE,
                        Message = Const.FAIL_READ_MSG,
                    };
                }
                account.ToUpdate(existingAccount);
                await _unitOfWork.AccountRepository.UpdateAsync(existingAccount);

                return new ServiceResult
                {
                    StatusCode = Const.SUCCESS_UPDATE_CODE,
                    Message = Const.SUCCESS_UPDATE_MSG,
                    Data = existingAccount.ToView()
                };
            }
            catch (Exception)
            {

                return new ServiceResult
                {
                    StatusCode = Const.ERROR_EXEPTION_CODE,
                    Message = Const.ERROR_EXEPTION_MSG,
                };
            }
        }
    }
}
