using System.ComponentModel.Design;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Aklai.Data;
using Aklai.Extra;
using Aklai.Model.Services;


namespace Aklai.ViewModel;

public class LoginVM: ViewModel
{
    private LocalDataService Service = new LocalDataService();
    private string _login;
    private PasswordBox _password;

    public string Login
    {
        get => _login;
        set => SetField(ref _login, value);
    }
    
    public PasswordBox Password
    {
        get => _password;
        set => SetField(ref _password, value);
    }

    public ICommand Autorize =>
        new CommandDelegate(parameters =>
        {
            _ = Task.Run(async () =>
            {
                var result = await Service.Autorize(Login, Password);
            });
        });
}