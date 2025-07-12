using Rescaptepet.Application.DTOs;
using Rescaptepet.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescaptepet.Application.Interfaces.Public
{
    public interface IAuthService
    {
        Task<Usuario?> RegisterAsync(RegisterDTO dto);
        Task<Usuario?> LoginAsync(LoginDTO dto);
    }
}
