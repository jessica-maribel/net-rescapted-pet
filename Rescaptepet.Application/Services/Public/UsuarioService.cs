using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;
using Rescaptepet.Infraestructure.Repositories.Public;

namespace Rescaptepet.Application.Services.Public
{
    public class UsuarioService(IUsuarioRepository _usuarioRepository) : IUsuarioService
    {
        public Task<Usuario> AddAsync(Usuario usuario)
        {
            return _usuarioRepository.AddAsync(usuario);
        }

        public Task<Usuario> ChangeStateAsync(Usuario usuario)
        {
            return _usuarioRepository.ChangeStateAsync(usuario);    
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return _usuarioRepository.GetAllAsync();
        }

        public Task<Usuario?> GetByIdAsync(int id)
        {
            return _usuarioRepository.GetByIdAsync(id);
        }

        public Task<Usuario?> UpdateAsync(Usuario usuario)
        {
            return _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
