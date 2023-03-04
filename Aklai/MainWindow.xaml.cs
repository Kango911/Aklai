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
        }



        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase"); // создаём таблицу в приложении
            // подключаемся к базе данных
            SqlConnection sqlConnection =
                new SqlConnection(@"Host=kashin.db.elephantsql.com; Username=cnmdgcki; Password=YEp_z36TiQMoE0Hb1Kfo_rNxmM0ly5OM; Database=cnmdgcki");
            sqlConnection.Open(); // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand(); // создаём команду
            sqlCommand.CommandText = selectSQL; // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable); // возращаем таблицу с результатом
            
            return dataTable;
        }
    }

    
    public class SqlDataAdapter
    {
        public SqlDataAdapter(SqlCommand sqlCommand)
        {
            throw new NotImplementedException();
        }

        public void Fill(DataTable dataTable)
        {
            throw new NotImplementedException();
        }
    }

    public class SqlCommand
    {
        public string CommandText { get; set; }
    }

    public class SqlConnection
    {
        public SqlConnection(string serverDesktopTdhc1kgSqlexpressDatabaseMasterTrustedConnectionTrue)
        {
            throw new NotImplementedException();
        }

        public SqlCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }
    }
}