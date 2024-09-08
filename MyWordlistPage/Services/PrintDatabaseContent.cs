using MyWordlistPage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWordlistPage.Services
{
    public class DatabasePrinter
    {
        public async Task PrintDatabaseContent()
        {
            var database = new Database();
            List<NameWordlist> dictionaries = await database.GetNamesAsync();
            List<Word> wordDataList = await database.GetWordDataAsync();

            Console.WriteLine("Dictionary Table Content:");
            if (dictionaries != null && dictionaries.Count > 0)
            {
                foreach (var dictionary in dictionaries)
                {
                    Console.WriteLine($"ID: {dictionary.ID}, Name: {dictionary.Name}");
                }
            }
            else
            {
                Console.WriteLine("The Dictionary table is empty.");
            }

            Console.WriteLine("\nWordData Table Content:");
            if (wordDataList != null && wordDataList.Count > 0)
            {
                foreach (var wordData in wordDataList)
                {
                    Console.WriteLine($"ID: {wordData.ID}, Word: {wordData.WordText}, Type: {wordData.Type}, Meaning: {wordData.Meaning}");
                }
            }
            else
            {
                Console.WriteLine("The WordData table is empty.");
            }
        }
    }
}
