namespace Aklai.FIlters;

public class Session
{
    private int id;
    private string login;
    private static bool sessionValid; // = false??

    public string Login
    {
        get
        {
            return login;
        }
        private set
        {
            login = Login;
        }
    }

    public static bool SessionValid
    {
        get
        {
            return sessionValid;
        }
        set
        {
            sessionValid = SessionValid;
        }
    }

    public Session(string login)
    {
        Login = login;
        SessionValid = true;
    }

    public string GetCurrentSession()
    {
        return Login;
    }

    static public void CloseSession()
    {
        SessionValid = false;
    }
}