using MyWordlistPage.Model;
using SQLite;

namespace MyWordlistPage.Services
{
    public class FlashcardServices
    {
        private SQLiteConnection database;

        public FlashcardServices(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Word>();
        }

        public List<Word> GetWordsByDictionaryID(int dictionaryID)
        {
            return database.Table<Word>().Where(w => w.DictionaryID == dictionaryID).ToList();
        }
    }
}
