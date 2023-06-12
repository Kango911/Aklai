using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Aklai.ParsF;
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
            $"INSERT INTO \"Users\" (login, password) VALUES (@{loginParam}, @{passwordParam})";        ;

        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(loginParam, login);
        command.Parameters.AddWithValue(passwordParam, password);

        conn.Open();

        var reader = command.ExecuteReader();
        return reader.HasRows;
    }

    public async Task<bool> WriteStocks(Sort stock)
    {
        const string timeParm = "time";
        const string nameParm = "name";
        const string tickerParm = "ticker";
        const string priceParm = "price";
        const string volumeParm = "volume";

        const string sqlQuery =
            $"INSERT INTO \"Stocks\" (time, name, ticker, price, value) VALUES (@{timeParm}, @{nameParm}, @{tickerParm}, @{priceParm}, @{volumeParm})";

        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();
        
        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(timeParm, stock.time);
        command.Parameters.AddWithValue(nameParm, stock.name);
        command.Parameters.AddWithValue(tickerParm, stock.ticker);
        command.Parameters.AddWithValue(priceParm, stock.price);
        command.Parameters.AddWithValue(volumeParm, stock.volume);

        conn.Open();

        var reader = command.ExecuteReader();
        return reader.HasRows;
    }
    
    public async Task<User> FindUser(string login)
    {
        const string loginParam = "login";
        const string sqlQuery =
            $"SELECT \"Stocks\" FROM \"Users\" WHERE login = @{loginParam}";

        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(loginParam, login);

        conn.Open();

        var reader = command.ExecuteReader();
        
        
        var result = reader.GetValue(0);
        return null;
    }
}