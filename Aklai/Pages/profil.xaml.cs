using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aklai.ParsF;

namespace Aklai.Pages;

public partial class profil : Page
{
    public MainWindow mainWindow;
    public User authUser;
    private List<Sort> Dates;
    
    public profil(MainWindow _mainWindow, User user)
    {

        InitializeComponent();

        authUser = user;
        
        mainWindow = _mainWindow;
        authUser = user;

        log.Content = authUser.Login;

        // Добавляем данные

        string standartUrl = "https://smart-lab.ru/";

        Parser parser = new Parser();
            
        List<string> parsedTabele = Parser.ParsTable("https://smart-lab.ru/q/shares/");
        
        List<Sort> elementList = Parser.CreareSort(parsedTabele);

        parser.WriteStocksToDB(elementList);
        parser.WriteToCSV(elementList);

        Dates = ReadCSV("indexes.csv").ToList();
        
        // выводим данные на экран
        LoadSort(Dates);
        
    }

    public void AddStock(object sender, RoutedEventArgs e)
    {
        authUser.AddStock(Dates[sortList.SelectedIndex]);
        MessageBox.Show("Акция добавлена в портфель");
    }

    public void GoBack(object sender, RoutedEventArgs e)
    {
        LoadSort(Dates);
    }

    private void ex_Click(object sender, RoutedEventArgs e) 
    {     
        mainWindow.OpenPage(MainWindow.pages.login, null); 
    }

    public IEnumerable<Sort> ReadCSV(string fileName)
    {
        // TODO: Error checking.
        string[] lines = File.ReadAllLines(fileName);
 
 
        return lines.Select(line =>
        {
            string[] data = line.Split(';');
            return new Sort(data[0], data[1], data[2], data[3], data[4], data[5]);
            
        });
    }

    public void ShowYourStocks(object sender, RoutedEventArgs e)
    {
        LoadSort(authUser.Stocks);
    }
    
    
    public void LoadSort(List<Sort> _sort)
    {
        sortList.Items.Clear();
    
        for (int i = 0; i < _sort.Count; i++)
        {
            sortList.Items.Add(_sort[i]);
        }
    }
    
}