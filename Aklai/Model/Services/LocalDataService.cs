using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using Aklai.Data;
using Aklai.Model.Data;
using Npgsql;

namespace Aklai.Model.Services;

public class LocalDataService
{
    public async Task<bool> Autorize(string login, PasswordBox password)
    {
        var db = new DBHelper();
        
        const string loginParam = "login";
        const string passwordParam = "password";
        const string sqlQuery = $"SELECT * FROM \"public\".\"Users\" AS u WHERE u.\"login\"=@{loginParam} AND u.\"password\"=@{passwordParam} LIMIT 1";;
        
        await using NpgsqlConnection conn = new(db._connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(loginParam, login);
        command.Parameters.AddWithValue(passwordParam, password);
        
        conn.Open();
        
        var reader = command.ExecuteReader();
        return reader.HasRows;
    }

}