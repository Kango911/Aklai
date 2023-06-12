using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Aklai.Data;
using Aklai.ParsF;

namespace Aklai.Pages;

public partial class pack : Page
{
    public MainWindow mainWindow;
    public string loginAuth;
    
    public pack(MainWindow _mainWindow)
    {
        InitializeComponent();
        DBHelper help = new DBHelper();
        help.FindUser("1");
        
        mainWindow = _mainWindow;
        this.loginAuth = loginAuth;

        log.Content = this.loginAuth;
        
        List<Sort> Dates = ReadCSV("indexes.csv").ToList();
        
        LoadSort(Dates); // выводим данные на экран
        
    }
    
    
    public IEnumerable<Sort> ReadCSV(string fileName)
    {
        // TODO: Error checking.
        string[] lines = File.ReadAllLines(fileName);
 
 
        return lines.Select(line =>
        {
            string[] data = line.Split(';');
            return new Sort(data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
            
        });
    }
    
    
    public void LoadSort(List<Sort> _sort)
    {
    
        for (int i = 2; i < _sort.Count; i++)
        {
            sortList.Items.Add(_sort[i]);
        }
    }
    
    
    
    
    private void ex_Click(object sender, RoutedEventArgs e) 
    {     
        mainWindow.OpenPage(MainWindow.pages.profil, loginAuth); 
    }
}