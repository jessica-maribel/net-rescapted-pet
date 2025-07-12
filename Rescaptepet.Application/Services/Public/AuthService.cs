using Rescaptepet.Application.DTOs;
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescaptepet.Application.Services.Public
{
    public class AuthService(IUsuarioRepository _usuarioRepository) : IAuthService
    {
        public async Task<Usuario?> LoginAsync(LoginDTO dto)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios
                .FirstOrDefault(u => u.Correo == dto.Email && u.Contrasena == dto.Password && u.Activo == true);
        }

        public async Task<Usuario?> RegisterAsync(RegisterDTO dto)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            if (usuarios.Any(u => u.Correo == dto.Correo))
                return null;

            var newUser = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Contrasena = dto.Contrasena,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                IdRol = dto.IdRol,
                Activo = true
            };
            return await _usuarioRepository.AddAsync(newUser);
        }
    }
}
