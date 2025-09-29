using Microsoft.AspNetCore.Mvc;
using Timepiece.Common.DTOs.AccountDTOs;
using Timepiece.Common.Enum.ServiceResult;
using Timepiece.Services.InternalService.IServices.IAccountServies;

namespace Timepiece.APIService.Controllers.AccountController
{
    /// <summary>
    /// API quản lý tài khoản người dùng
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        /// <summary>
        /// Lấy thông tin người dùng
        /// </summary>
        /// <remarks>
        /// API cho phép Admin hoặc Manager lấy thông tin người dùng trong hệ thống.
        /// </remarks>
        /// <param name="dto">Thông tin người dùng cần lấy</param>
        /// <returns>Thông tin người dùng đã lấy</returns>
        /// <response code="200">Tạo người dùng thành công</response>
        /// <response code="400">Dữ liệu không hợp lệ</response>
        /// <response code="500">Lỗi hệ thống</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccount()
        {
            var result = await _accountService.GetAllAccountsAsync();
            if (result.Data == null)
            {
                return NotFound(new
                {
                    Message = Const.ERROR_NOT_FOUND_MSG,
                });
            }
            return Ok(new
            {
                Message = Const.SUCCESS_READ_MSG,
                Data = result.Data
            });
        }

        /// <summary>
        /// Tạo mới thông tin người dùng
        /// </summary>
        /// <remarks>
        /// API cho phép Admin hoặc Manager tạo mới thông tin người dùng trong hệ thống.
        /// </remarks>
        /// <param name="dto">Thông tin người dùng cần tạo</param>
        /// <returns>Thông tin người dùng đã tạo</returns>
        /// <response code="200">Tạo người dùng thành công</response>
        /// <response code="400">Dữ liệu không hợp lệ</response>
        /// <response code="500">Lỗi hệ thống</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = Const.ERROR_REQUIRED_MSG,
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                });
            }
            var result = await _accountService.CreateAccountAsync(dto);

            if (result.StatusCode != Const.SUCCESS_CREATE_CODE)

                return StatusCode(result.StatusCode, result.Message);

            return Ok(new
            {
                Message = Const.SUCCESS_CREATE_MSG,
                Data = result.Data
            });
        }

        /// <summary>
        /// Cập nhật mới thông tin người dùng
        /// </summary>
        /// <remarks>
        /// API cho phép Admin hoặc Manager cập nhật mới thông tin người dùng trong hệ thống.
        /// </remarks>
        /// <param name="dto">Thông tin người dùng cần cập nhật</param>
        /// <returns>Thông tin người dùng đã cập nhât</returns>
        /// <response code="200">Cập nhật người dùng thành công</response>
        /// <response code="400">Dữ liệu không hợp lệ</response>
        /// <response code="500">Lỗi hệ thống</response>

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateAccount([FromRoute] Guid id, [FromBody] UpdateAccountDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new
                {
                    Message = Const.ERROR_REQUIRED_MSG,
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                });
            }
            var result = await _accountService.UpdateAccountAsync(id, dto);

            if (result.StatusCode != Const.SUCCESS_UPDATE_CODE)
                return StatusCode(result.StatusCode, result.Message);
            return Ok(new
            {
                Message = Const.SUCCESS_UPDATE_MSG,
                Data = result.Data
            });

        }

        /// <summary>
        /// Xóa thông tin người dùng
        /// </summary>
        /// <remarks>
        /// API cho phép Admin hoặc Manager xóa thông tin người dùng trong hệ thống.
        /// </remarks>
        /// <param name="dto">Thông tin người dùng cần xóa </param>
        /// <returns>Thông tin người dùng đã xóa</returns>
        /// <response code="200">Xóa người dùng thành công</response>
        /// <response code="400">Dữ liệu không hợp lệ</response>
        /// <response code="500">Lỗi hệ thống</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteAccount([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new
                {
                    Message = Const.ERROR_REQUIRED_MSG,
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                });
            }
            var result = await _accountService.DeleteAccountAsync(id);
            if (result.StatusCode != Const.SUCCESS_DELETE_CODE)
                return StatusCode(result.StatusCode, result.Message);
            return Ok(new
            {
                Message = Const.SUCCESS_DELETE_MSG,
                Data = result.Data
            });

        }
    }
}
