using Microsoft.EntityFrameworkCore;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;
using Rescaptepet.Infraestructure.Connections;

namespace Rescaptepet.Infraestructure.Repositories.Public
{
    public class UsuarioRepository(MySqlDbContext _context) : IUsuarioRepository
    {
        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> ChangeStateAsync(Usuario usuario)
        {
            Usuario finded = await _context.Usuarios
                .FirstAsync(u => u.IdUsuario == usuario.IdUsuario); 

            finded.Activo = usuario.Activo;

            await _context.SaveChangesAsync();
            return finded;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<Usuario?> UpdateAsync(Usuario usuario)
        {
            var existing = await _context.Usuarios.FindAsync(usuario.IdUsuario);
            if (existing == null) return null;
            _context.Entry(usuario).CurrentValues.SetValues(usuario);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
