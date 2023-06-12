using System.Windows;
using System.Windows.Controls;
using Aklai.Data;

namespace Aklai
{
    public partial class login : Page
    {
        public MainWindow mainWindow;
        public string loginAuth;
        public login(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
            
        }
        

        // функция входа 
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length <= 0)
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (password.Password.Length <= 0)     
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            var db = new DBHelper();
            
            if (db.CanAuth(textBox_login.Text, password.Password).Result is false)   
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }
            MessageBox.Show("Пользователь авторизован! \n" +
                            "Идет подгрузка актуальных данных!");
            loginAuth = textBox_login.Text;
            mainWindow.OpenPage(MainWindow.pages.profil, loginAuth);
            
        }

        // функция открытия регистрации 
        private void regin_Click(object sender, RoutedEventArgs e) 
        {     
            mainWindow.OpenPage(MainWindow.pages.regin, null); 
        }
    }
}