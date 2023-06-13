using System.Collections.Generic;
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
            $"SELECT * FROM \"public\".\"users\" AS u WHERE u.\"login\"=@{loginParam} AND u.\"password\"=@{passwordParam} LIMIT 1";

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
            $"INSERT INTO \"users\" (login, password) VALUES (@{loginParam}, @{passwordParam})";

        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(loginParam, login);
        command.Parameters.AddWithValue(passwordParam, password);

        conn.Open();

        var reader = command.ExecuteReader();
        return reader.HasRows;
    }

    public async Task<Stock> WriteStocks(Stock stock)
    {
        const string timeParm = "buy_time";
        const string nameParm = "stock_name";
        const string tickerParm = "ticker";
        const string priceParm = "price";
        const string volumeParm = "volume";

        const string sqlQuery =
            $"INSERT INTO \"stocks\" (buy_time, stock_name, ticker, price, volume) VALUES (@{timeParm}, @{nameParm}, @{tickerParm}, @{priceParm}, @{volumeParm})";

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
        return null; //reader.HasRows;
    }
    
    public async Task<int> GetUserID(string login)
    {
        const string loginParam = "login";
        const string sqlQuery =
            $"SELECT \"Stocks\" FROM \"users\" WHERE login = @{loginParam}";

        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(loginParam, login);

        conn.Open();

        var reader = command.ExecuteReader();
        
        
        var result = reader.GetValue(0);
        return -1;
    }

    public async Task<List<Stock>> GetAllStocks()
    {
        const string sqlQuery =
            $"SELECT * FROM \"public\".\"stocks\"";

        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;

        conn.Open();
        

        var reader = command.ExecuteReader();
        return null;
    }

    public async Task<List<Stock>> GetUsersStoks(int userId)
    {
        const string user_IDParam = "login";
        
        const string sqlQuery =
            $"SELECT \"stock_ticker\" FROM \"users_stocks\" WHERE user_id = \"@{user_IDParam}\"";
        
        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(user_IDParam, userId);

        conn.Open();
        

        var reader = command.ExecuteReader();
        return null; //reader.HasRows;
    }

    public async Task AddStockToBackpack(int userId, Stock stock)
    {
        const string user_IDParm = "login";
        const string tickerParm = "ticker";
        
        const string sqlQuery =
            $"INSERT INTO \"users_stocks\" (user_id, stock_ticker) VALUES (\"@{user_IDParm}\", \"@{tickerParm}\")";
        
        await using NpgsqlConnection conn = new(_connstr);
        await using var command = conn.CreateCommand();

        command.CommandText = sqlQuery;
        command.Parameters.AddWithValue(user_IDParm, userId);

        conn.Open();
        

        var reader = command.ExecuteReader();
        return; //reader.HasRows;
    }
}