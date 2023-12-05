using Npgsql;

namespace BookShelf.Data.Base;

public abstract class BaseAdoRepository
{
    protected async Task<List<T>> ExecuteQuery<T>(NpgsqlConnection connection, string sqlQuery, object? parameters = null)
    {
        var command = new NpgsqlCommand(sqlQuery, connection);
        InternalAddParametersIntoCommand(command, parameters);
        

        var tType = typeof(T);
        var props = tType.GetProperties();
        var result = new List<T>();
        
        var reader = await command.ExecuteReaderAsync();
        var columns = reader.GetColumnSchema().ToDictionary(c => c.ColumnName.ToLower());

        try
        {
            while (await reader.ReadAsync())
            {
                var obj = (T)Activator.CreateInstance(tType)!;
                result.Add(obj);
                foreach (var p in props)
                {
                    if (p.CanWrite && columns.ContainsKey(p.Name.ToLower()))
                        p.SetValue(obj, reader[p.Name]);
                }
            }
        }
        finally
        {
            await reader.CloseAsync();
        }

        return result;
    }
    
    protected Task<int> ExecuteNonQuery(NpgsqlConnection connection, string sqlCommand, object? parameters)
    {
        var command = new NpgsqlCommand(sqlCommand, connection);
        InternalAddParametersIntoCommand(command, parameters);
        
        return command.ExecuteNonQueryAsync();
    }

    private void InternalAddParametersIntoCommand(NpgsqlCommand command, object? parameters)
    {
        if (parameters is null)
            return;

        var props = parameters.GetType().GetProperties();

        foreach (var p in props)
        {
            object? value = p.GetValue(parameters);
            
            if (value is not null)
                command.Parameters.AddWithValue($"@{p.Name}", value);
        }
            
    }
}