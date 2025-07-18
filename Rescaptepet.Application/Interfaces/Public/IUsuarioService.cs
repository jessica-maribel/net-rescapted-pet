﻿using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.Application.Interfaces.Public
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> AddAsync(Usuario usuario);
        Task<Usuario?> UpdateAsync(Usuario usuario);
        Task<Usuario> ChangeStateAsync(Usuario usuario);
    }
}
