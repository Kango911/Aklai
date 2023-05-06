using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Aklai.Filters;


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
        sort.Add(new Sort("Облигация", "ОФЗ 26242", "1000", "29-08-2029", "13.81 руб"));

        LoadSort(sort); // выводим данные на экран
    }
    
    private void Exite_Click(object sender, RoutedEventArgs e) 
    {     
        mainWindow.OpenPage(MainWindow.pages.login); 
        Session.CloseSession();
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
    
    public List<Sort> sort = new List<Sort>();
    
    public void LoadSort(List<Sort> _sort)
    {
        sortList.Items.Clear(); // очищаем лист с элементами
    
        for (int i = 0; i < _sort.Count; i++) // перебираем элементы
        {
            sortList.Items.Add(_sort[i]); // добавляем элементы в ListBox
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
