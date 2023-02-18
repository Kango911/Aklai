using System;
using System.Collections.Generic;
using System.Data;
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

namespace Aklai
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-TDHC1KG\SQLEXPRESS;Database=master;Trusted_Connection=True;"); 
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }
    }

    public class SqlConnection
    {
        public SqlConnection(string serverDesktopNbh5jf2TrustedConnectionYesDatabaseTest)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public SqlCommand CreateCommand()
        {
            throw new NotImplementedException();
        }
    }

    public class SqlCommand
    {
        public string CommandText { get; set; }
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
}