using System.Collections.Generic;
using Aklai.ParsF;

namespace Aklai;

public class User
{
    public string Login;
    public string Password;
    public List<Stock> Stocks = new List<Stock>(){};

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public void AddStock(Stock stock)
    {
        Stocks.Add(stock);
    }
    
    public void RemoveStock(Stock stock)
    {
        Stocks.Remove(stock);
    }
}