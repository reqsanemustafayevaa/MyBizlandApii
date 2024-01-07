using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.AccountDto;
using project.business.Exceptions;
using project.business.Services.Interfaces;
using System.Security.Authentication;

namespace MyBizLandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {
            try
            {
                await _accountService.RegisterAsync(registerDto);
            }
            catch (InvalidUserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidRegisterException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();



        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {
            string token = String.Empty;
            try
            {
                token = await _accountService.LoginAsync(loginDto);
            }
            catch (InvalidCredentialException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidLoginException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(token);
        }

    }
}
