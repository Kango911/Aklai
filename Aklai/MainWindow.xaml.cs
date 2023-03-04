using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using Aklai.Pages;
using Npgsql;

namespace Aklai
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenPage(pages.login);
        }

        public enum pages
        {
            login,
            regin,
            profil
        }


        public void OpenPage(pages pages)
        {
            if (pages == pages.login)
            {
                frame.Navigate(new login(this));
            } else if (pages == pages.regin)
                frame.Navigate(new regin(this));
            else if (pages == pages.profil)
                frame.Navigate(new profil(this));
            
        }



        public NpgsqlDataReader Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            Npgsql.NpgsqlConnection connection = new NpgsqlConnection(@"Host=kashin.db.elephantsql.com; Username=cnmdgcki; Password=YEp_z36TiQMoE0Hb1Kfo_rNxmM0ly5OM; Database=cnmdgcki");
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = selectSQL;
            NpgsqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}