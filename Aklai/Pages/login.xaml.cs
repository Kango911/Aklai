using System.Data;
using System.Windows;
using System.Windows.Controls;

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
            if (textBox_login.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными         
                    DataTable dt_user = mainWindow.Select("SELECT * FROM [Users] WHERE [login] = '" + textBox_login.Text + "' AND [password] = '" + password.Password + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует       
                    {
                        MessageBox.Show("Пользователь авторизовался"); // говорим, что авторизовался  
                        mainWindow.OpenPage(MainWindow.pages.profil); // открываем страницу профиль 
                    } else MessageBox.Show("Пользователя не найден"); // выводим ошибку  
                } else MessageBox.Show("Введите пароль"); // выводим ошибку    
            } else MessageBox.Show("Введите логин"); // выводим ошибку 
        }

        // функция открытия регистрации 
        private void regin_Click(object sender, RoutedEventArgs e) 
        {     
            mainWindow.OpenPage(MainWindow.pages.regin); 
        }
    }
}