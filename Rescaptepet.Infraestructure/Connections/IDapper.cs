using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescaptepet.Infraestrucutre.DbContext
{
    public interface IDapper
    {
        void ExecuteQuery(string query);
        void ExecuteQuery(string query, Object parameters);
        Task ExecuteQueryAsync(string query);
        Task ExecuteQueryAsync(string query, Object parameters);
        List<T> GetList<T>(string query);
        List<T> GetList<T>(string query, Object parameters);
        List<object> GetList(string query, Object parameters);
        Task<List<T>> GetListAsync<T>(string query);
        Task<List<T>> GetListAsync<T>(string query, Object parameters);
        T GetObject<T>(string query);
        T GetObject<T>(string query, object parameters);
        Task<T?> GetObjectAsync<T>(string query);
        Task<T?> GetObjectAsync<T>(string query, object parameters);
    }
}


