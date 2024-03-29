﻿using System.ComponentModel;
using CsvHelper.Configuration.Attributes;

namespace Aklai.ParsF;

public class Stock 
{
    [Name("ID")]
    public string number { get; set; }
    [Name("Время")]
    public string time { get; set; }
    [Name("Имя")]
    public string name { get; set; }
    [Name("Тикер")]
    public string ticker { get; set; }
    [Name("Цена")]
    public string price { get; set; }
    [Name("Объём, млн. рублей")]
    public string volume { get; set; }
    
    public Stock(string _number, string _time, string _name, string _ticker, string _price, string _volume)
    {
        number = _number;
        time = _time;
        name = _name;
        ticker = _ticker;
        price = _price;
        volume = _volume;
    }

}