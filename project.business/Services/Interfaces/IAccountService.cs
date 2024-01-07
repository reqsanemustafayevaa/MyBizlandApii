using Microsoft.AspNetCore.Mvc;
using project.business.DTOs.AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync([FromForm] RegisterDto registerDto);
        Task<string> LoginAsync([FromForm] LoginDto loginDto);
    }
}
