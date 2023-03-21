namespace Aklai.FIlters;

public class Session
{
    private string Login;

    private bool SessionValid
    {
        get { return SessionValid; }
        set { SessionValid = CloseSession(); }
    }

    public Session(string login)
    {
        Login = login;
        SessionValid = true;
    }

    static public bool CloseSession()
    {
        return false;
    }
}