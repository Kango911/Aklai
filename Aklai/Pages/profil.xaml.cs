using System.Windows;
using System.Windows.Controls;
using Aklai.FIlters;

namespace Aklai.Pages;

public partial class profil : Page
{
    public MainWindow mainWindow;

    public profil(MainWindow _mainWindow)
    {
        InitializeComponent();

        mainWindow = _mainWindow;
    }
    
    private void ex_Click(object sender, RoutedEventArgs e)
    {     
        mainWindow.OpenPage(MainWindow.pages.login);
        Session.CloseSession();
    }
    
}