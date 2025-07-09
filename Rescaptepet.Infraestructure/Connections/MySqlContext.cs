using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;
using Dapper;
using Rescaptepet.Exceptions;


namespace Rescaptepet.Infraestrucutre.DbContext;

public class MysqlContext(IConfiguration configuration) : IDapper
{
    public readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");

    public void ExecuteQuery(string query)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            conn.Query(query, commandType: CommandType.Text);
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public void ExecuteQuery(string query, object parameters)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            conn.Query(query, param: parameters, commandType: CommandType.Text);
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public async Task ExecuteQueryAsync(string query)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            await conn.QueryAsync(query, commandType: CommandType.Text);
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public async Task ExecuteQueryAsync(string query, object parameters)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            await conn.QueryAsync(query, param: parameters, commandType: CommandType.Text);
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public List<T> GetList<T>(string query)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn.Query<T>(query, commandType: CommandType.Text).ToList();
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public List<T> GetList<T>(string query, object parameters)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn.Query<T>(query, param: parameters, commandType: CommandType.Text).ToList();
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public List<object> GetList(string query, object parameters)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn.Query(query, param: parameters, commandType: CommandType.Text).ToList();
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public async Task<List<T>> GetListAsync<T>(string query)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            var result = await conn.QueryAsync<T>(query, commandType: CommandType.Text);
            return result.ToList();
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public async Task<List<T>> GetListAsync<T>(string query, object parameters)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            var result = await conn.QueryAsync<T>(query, param: parameters, commandType: CommandType.Text);
            return result.ToList();
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public T GetObject<T>(string query)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn.QueryFirstOrDefault<T>(query, commandType: CommandType.Text);
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public T GetObject<T>(string query, object parameters)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn.QueryFirstOrDefault<T>(query, param: parameters, commandType: CommandType.Text);
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public async Task<T?> GetObjectAsync<T>(string query)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.QuerySingleOrDefaultAsync<T>(query, commandType: CommandType.Text);
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }

    public async Task<T?> GetObjectAsync<T>(string query, object parameters)
    {
        using var conn = new MySqlConnection(_connectionString);
        try
        {
            if (conn.State == ConnectionState.Closed)
                await conn.OpenAsync();

            return await conn.QuerySingleOrDefaultAsync<T>(
                query, param: parameters, commandType: CommandType.Text
            );
        }
        catch (Exception ex)
        {
            throw new DbPsglException("Error executing SQL", ex);
        }
    }
}
