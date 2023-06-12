using System.Collections.Generic;
using Aklai.ParsF;

namespace Aklai;

public class User
{
    public string Login;
    public string Password;
    public List<Sort>? Stocks;

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }
}