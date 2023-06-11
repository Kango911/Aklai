using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Npgsql;

namespace Aklai.Data;

public class DBHelper
{
    private const string DefaultConnStr =
        "Host=kashin.db.elephantsql.com; Username=cnmdgcki; Password=YEp_z36TiQMoE0Hb1Kfo_rNxmM0ly5OM; Database=cnmdgcki";

    private readonly string _connstr;

    public DBHelper(string? connstr = null)
    {
        _connstr = connstr ?? DefaultConnStr;
    }

    public async Task<bool> CanAuth(string login, string password)
    {
        const string loginParam = "login";
        const string passwordParam = "password";
        const string sqlQuery =
            $"SELECT * FROM \"public\".\"Users\" AS u WHERE u.\"login\"=@{loginParam} AND u.\"password\"=@{passwordParam} LIMIT 1";
        ;

        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(loginParam, login);
        command.Parameters.AddWithValue(passwordParam, password);

        conn.Open();

        var reader = command.ExecuteReader();
        return reader.HasRows;
    }

    

    public async Task<bool> CanReg(string login, string password)
    {
        const string loginParam = "login";
        const string passwordParam = "password";
        const string sqlQuery =
            $"INSERT INTO \"public\".\"Users\" AS u WHERE u.\"login\"=@{loginParam} AND u.\"password\"=@{passwordParam} LIMIT 1";
        ;

        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(loginParam, login);
        command.Parameters.AddWithValue(passwordParam, password);

        conn.Open();

        var reader = command.ExecuteReader();
        return reader.HasRows;
    }
}