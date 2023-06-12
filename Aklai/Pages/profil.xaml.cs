using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Aklai.ParsF;
using HtmlAgilityPack;
using CsvHelper;



namespace Aklai.Pages;



public partial class profil : Page
{
    public MainWindow mainWindow;
    
    public profil(MainWindow _mainWindow)
    {
        InitializeComponent();
        
        mainWindow = _mainWindow;
        
        InitializeComponent();
        

        // Добавляем данные

        
        
        
        
        string standartUrl = "https://smart-lab.ru/";
            
        List<string> parsedTabele = Parser.ParsTable("https://smart-lab.ru/q/shares/");
        
        List<Sort> elementList = Parser.CreareSort(parsedTabele);
            
        Parser.WriteToCSV(elementList);
        
        
        List<Sort> Dates = ReadCSV("indexes.csv").ToList();
        
        LoadSort(Dates); // выводим данные на экран
        
        
    }
    
    private void ex_Click(object sender, RoutedEventArgs e) 
    {     
        mainWindow.OpenPage(MainWindow.pages.login); 
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
    
    
    public void LoadSort(List<Sort> _sort)
    {
    
        for (int i = 2; i < _sort.Count; i++)
        {
            sortList.Items.Add(_sort[i]);
        }
    }
}
