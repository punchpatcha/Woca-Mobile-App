using SQLite;

namespace MyWordlistPage.Model
{
    public class Word
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string WordText { get; set; }
        public string Type { get; set; }
        public string Meaning { get; set; }
        public int DictionaryID { get; set; } // เพิ่มฟิลด์เพื่อระบุคำศัพท์อยู่ในคลังไหน
    }
}
