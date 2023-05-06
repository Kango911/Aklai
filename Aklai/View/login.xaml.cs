using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Aklai.Data;
using Aklai.Filters;
using Npgsql;

namespace Aklai
{
    public partial class login : Page
    {
        public MainWindow mainWindow;
        public login(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }

        public PasswordBox GetPasswordBox()
        {
            return password;
        }

        // функция входа 
        private void Enter_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Пользователя не найден");
                return;
            }
            MessageBox.Show("Пользователь авторизовался");
            mainWindow.OpenPage(MainWindow.pages.profil);
            
            Session currentSession = new Session(textBox_login.Text);
            MainWindow.session = currentSession;
            
        }

        // функция открытия регистрации 
        private void Regin_Click(object sender, RoutedEventArgs e) 
        {     
            mainWindow.OpenPage(MainWindow.pages.regin); 
        }
    }
}