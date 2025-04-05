using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Product.Data.DataAccess;

    public class SqlDataAccess : ISqlDataAccess
    {
       private readonly IConfiguration _config;

       public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
    public async Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "conn")
    {
        var connectionString = _config.GetConnectionString(connectionId)?? throw new ArgumentNullException(nameof(connectionId));
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        try
        {
            return await connection.QueryAsync<T>(spName,parameters,commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task SaveData<T>(string spName, T parameters, string connectionId = "conn")
    {
        var connectionString = _config.GetConnectionString(connectionId)?? throw new ArgumentNullException(nameof(connectionId));
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        try
        {
            await connection.ExecuteAsync(spName,parameters,commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}
