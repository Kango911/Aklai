using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aklai.Data;
using CsvHelper;
using CsvHelper.Configuration;
using HtmlAgilityPack;

namespace Aklai.ParsF;

public class Parser
{
    public static List<string> ParsTable(string url)
    {
        var res = new List<string>();
        
        try{
            using (HttpClientHandler hdl = new HttpClientHandler
                       {AllowAutoRedirect = false, AutomaticDecompression = DecompressionMethods.All})
            {
                using (HttpClient client = new HttpClient(hdl))
                {
                    using (HttpResponseMessage responce = client.GetAsync(url).Result)
                    {
                        if (responce.IsSuccessStatusCode)
                        {
                            var html = responce.Content.ReadAsStringAsync().Result;
                            if (!string.IsNullOrEmpty(html))
                            {
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(html);


                                var table = doc.DocumentNode.SelectSingleNode(
                                    "/html/body/div[1]/div/div[6]/div/div/div[2]");
                                if (table != null)
                                {

                                    var tbl = table.SelectSingleNode("//table");
                                    if (tbl != null)
                                    {
                                        var cells = table.SelectNodes("//td");
                                        {
                                            foreach (var cell in cells)
                                            {
                                                if (cell.InnerText != "Как выбрать брокера?" &&
                                                    cell.InnerText != "Рейтинг брокеров")
                                                    res.Add(cell.InnerText);
                                            }
                                        }
                                    }
                                }

                                return res;
                            }
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        return null;
    }

    public static List<Stock> CreareSort(List<string> input)
    {
        List<Stock> result = new List<Stock>();
        
        for (int i = 40; i < input.Count - 18; i+=20)
        {
            result.Add(new Stock(input[i],input[i+1],input[i+2],input[i+3],input[i+7], input[i+9]));
        }
    
        return result;
    }

    public async void WriteStocksToDB(List<Stock> input)
    {
        DBHelper dbHelper = new DBHelper();

        await Task.Run(() =>
        {
            foreach (var stock in input)
            {
                dbHelper.WriteStocks(stock);
            }
        });
    }

    public void WriteToCSV(List<Stock> tabel)
    {
        using (var writer = new StreamWriter("indexes.csv", false, Encoding.UTF8 ))
        {
            var csvConfig = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU")) {Delimiter = ";"};
            
            using (var csvWriter = new CsvWriter(writer, csvConfig))
            {
                csvWriter.WriteRecords(tabel);
            }
        }
    }
    
    
}