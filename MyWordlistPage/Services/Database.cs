using MyWordlistPage.Model;
using SQLite;
using System.Collections.ObjectModel;

namespace MyWordlistPage.Services
{
    public class Database
    {
        SQLiteAsyncConnection _database;

        async Task Init()
        {
            if (_database is not null)
                return;
            _database = new SQLiteAsyncConnection(
                Constants.DatabasePath,
                Constants.Flags);
            await _database.CreateTableAsync<NameWordlist>(); // generate Wordlist Table if not have
            await _database.CreateTableAsync<Word>(); //  generate Getword Wordlist Table if not have
        }

        public async Task<List<NameWordlist>> GetNamesAsync()
        {
            await Init();
            return await _database.Table<NameWordlist>().ToListAsync();
        }

        public async Task<NameWordlist> GetIDNameAsync(int pID)
        {
            await Init();
            return await _database.Table<NameWordlist>().Where(n => n.ID == pID).FirstOrDefaultAsync();
        }

        public async Task<int> SaveNoteAsync(NameWordlist pName)
        {
            await Init();

            // ใช้คำสั่ง SQL เพื่อ INSERT หรือ REPLACE ข้อมูล
            return await _database.ExecuteAsync("INSERT OR REPLACE INTO NameWordlist (ID, Name) VALUES (?, ?)", pName.ID, pName.Name);
        }
        public async Task<List<Word>> GetWordDataAsync()
        {
            await Init();
            return await _database.Table<Word>().ToListAsync();
        }


        public async Task<int> SaveWordAsync(Word word)
        {
            await Init();
            return await _database.InsertOrReplaceAsync(word);
        }

        public async Task<int> GetNextWordIdAsync()
        {
            await Init();
            var maxIdWord = await _database.Table<Word>().OrderByDescending(w => w.ID).FirstOrDefaultAsync();
            if (maxIdWord == null)
                return 1;
            else
                return maxIdWord.ID + 1;
        }

        public async Task<List<Word>> GetWordsByDictionaryIdAsync(string dictionaryId)
        {
            await Init();
            if (int.TryParse(dictionaryId, out int id))
            {
                return await _database.Table<Word>().Where(w => w.DictionaryID == id).ToListAsync();
            }
            else
            {
                // not convert to integer
                return new List<Word>();
            }
        }

        public async Task<List<NameWordlist>> GetWordlistsAsync()
        {
            await Init();
            return await _database.Table<NameWordlist>().ToListAsync();
        }








    }
}