using System.Collections.Generic;
using Aklai.ParsF;

namespace Aklai;

public class User
{
    public string Login;
    public string Password;
    public List<Sort> Stocks = new List<Sort>(){};

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public void AddStock(Sort stock)
    {
        Stocks.Add(stock);
    }
}