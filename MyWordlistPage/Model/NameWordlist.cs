using SQLite;

namespace MyWordlistPage.Model
{
    public class NameWordlist
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class DictionaryWordData // middle Tabke between Wordlist and NameofWordlist
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int DictionaryID { get; set; }
        public int WordDataID { get; set; }
    }

}
