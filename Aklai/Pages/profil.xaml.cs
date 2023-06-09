using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
using Microsoft.Win32;


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

        List<Sort> Dates = ReadCSV("D:\\JetBrains\\Aklai\\Aklai\\indexes.csv").ToList();
        
        LoadSort(Dates); // выводим данные на экран
    }
    
    private void ex_Click(object sender, RoutedEventArgs e) 
    {     
        mainWindow.OpenPage(MainWindow.pages.login); 
    }

    public class Sort
    {
        public string type { get; set; }
        public string name { get; set; }
        public string nome { get; set; }
        public string age { get; set; }
        public string nkd { get; set; }
    
        public Sort(string _type, string _name, string _nome, string _age, string _nkd)
        {
            this.type = _type;
            this.name = _name;
            this.nome = _nome;
            this.age = _age;
            this.nkd = _nkd;
        }
    }
    
    public IEnumerable<Sort> ReadCSV(string fileName)
    {
        // TODO: Error checking.
        string[] lines = File.ReadAllLines(fileName);
 
 
        return lines.Select(line =>
        {
            string[] data = line.Split(';');
            return new Sort(data[0], data[1], data[2], data[3], data[4]);
            
        });
    }
    
    public List<Sort> sort = new List<Sort>();
    
    public void LoadSort(List<Sort> _sort)
    {
    
        for (int i = 1; i < _sort.Count; i++)
        {
            sortList.Items.Add(_sort[i]);
        }
    }
    
    
    private void ActiveFilter(object sender, RoutedEventArgs e)
    {
        List<Sort> newSort = new List<Sort>();
        newSort = sort;
    
        if (typeFilter.SelectedIndex == 0)
            newSort = sort.FindAll(x => x.type == "Акция");
        else
            newSort = sort.FindAll(x => x.type == "Облигация");
    
        LoadSort(newSort);
        newSort = newSort.FindAll(x => x.name.Contains(nameFilter.Text));
    }
}
