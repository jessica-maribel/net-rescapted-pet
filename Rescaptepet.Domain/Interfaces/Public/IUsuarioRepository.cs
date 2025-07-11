using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.Domain.Interfaces.Public
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> AddAsync(Usuario usuario);
        Task<Usuario?> UpdateAsync(Usuario usuario);
        Task<Usuario> ChangeStateAsync(Usuario usuario);
    }
}
