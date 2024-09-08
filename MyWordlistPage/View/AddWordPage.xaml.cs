using Microsoft.Maui.Controls;
using MyWordlistPage.Model;
using MyWordlistPage.Services;

namespace MyWordlistPage.View
{
    public partial class AddWordPage : ContentPage
    {
        private readonly string _buttonId;

        public AddWordPage(string buttonId)
        {
            InitializeComponent();
            _buttonId = buttonId;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //  Entries
            string word = wordEntry.Text;
            string type = typeEntry.Text;
            string translation = translationEntry.Text;

            // to generate ID of Word 
            int newId = await App.Database.GetNextWordIdAsync();

            //  WordData
            Word newWord = new Word
            {
                ID = newId, 
                WordText = word,
                Type = type,
                Meaning = translation,
                DictionaryID = int.Parse(_buttonId) // to know that you pressed which wordlist
            };

            // 
            await App.Database.SaveWordAsync(newWord);

            //CreateWordPage
            await Navigation.PopAsync();
        }
    }
}
