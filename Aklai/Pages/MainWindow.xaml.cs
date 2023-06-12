using System.Windows;
using Aklai.Pages;
using Npgsql;

namespace Aklai
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenPage(pages.login, null);
        }

        public enum pages
        {
            login,
            regin,
            profil
        }


        public void OpenPage(pages pages, string? loginAuth)
        {
            if (pages == pages.login)
            {
                frame.Navigate(new login(this));
            } else if (pages == pages.regin)
                frame.Navigate(new regin(this));
            else if (pages == pages.profil)
                frame.Navigate(new profil(this, loginAuth));
            
        }



        public NpgsqlDataReader Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            Npgsql.NpgsqlConnection connection = new NpgsqlConnection(@"");
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = selectSQL;
            NpgsqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}