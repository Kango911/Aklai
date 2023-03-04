using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Aklai.Data;
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
                MessageBox.Show("Пользователя не найден");
                return;
            }
            MessageBox.Show("Пользователь авторизовался");
            mainWindow.OpenPage(MainWindow.pages.profil);
        }

        // функция открытия регистрации 
        private void regin_Click(object sender, RoutedEventArgs e) 
        {     
            mainWindow.OpenPage(MainWindow.pages.regin); 
        }
    }
}