using System.Windows.Controls;
using System.Windows;

namespace Aklai
{
    public partial class regin : Page
    {
        public MainWindow mainWindow;
        
        public regin(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;
        }
        
        //Возвращаемся назад
        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.login);
        }
        
        //Регистрация
        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length > 0) // проверяем логин
            {
                string[] dataLogin = textBox_login.Text.Split('@'); // делим строку на две части
                if (dataLogin.Length == 2) // проверяем если у нас две части
                {
                    string[] data2Login = dataLogin[1].Split('.'); // делим вторую часть ещё на две части
                    if (data2Login.Length == 2)
                    {

                    } else MessageBox.Show("Укажите логин в форме х@x.x");
                } else MessageBox.Show("Укажите логин в форме х@x.x");
                
                
                if (password.Password.Length > 0) // проверяем пароль
                {
                    if (password.Password.Length >= 6)
                    {
                        bool en = true; // английская раскладка
                        bool symbol = false; // символ
                        bool number = false; // цифра

                        for(int i=0; i<password.Password.Length; i ++) // перебираем символы
                        {
                            if (password.Password[i] >= 'А' && password.Password[i] <= 'Я') en = false; // если русская раскладка
                            if (password.Password[i] >= '0' && password.Password[i] <= '9') number = true; // если цифры
                            if (password.Password[i] == '_' || password.Password[i] == '-' || password.Password[i] == '!') symbol = true; // если символ
                        }

                        if (!en) 
                            MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                        else if (!symbol) 
                            MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                        else if (!number) 
                            MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                        if(en && symbol && number) // проверяем соответствие
                        {
                        }
                    } else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                    
                    if (password_Copy.Password.Length > 0) // проверяем второй пароль
                    {
                        if (password.Password == password_Copy.Password) // проверка на совпадение паролей
                        {
                            MessageBox.Show("Пользователь зарегистрирован");
                        }else MessageBox.Show("Пароли не совподают");

                    } else MessageBox.Show("Повторите пароль");
                } else MessageBox.Show("Укажите пароль");
            } else MessageBox.Show("Укажите логин");
        }
    }
}
