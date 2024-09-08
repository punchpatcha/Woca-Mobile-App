using MyWordlistPage.Model;
using MyWordlistPage.Services;

namespace MyWordlistPage.View;


public partial class AddNameWordlistPage : ContentPage
{
	public AddNameWordlistPage(string dictionaryName, string buttonId)
	{
		InitializeComponent();
        entryName.Text = dictionaryName;
        ButtonId = buttonId;
    }
    public string ButtonId { get; }


    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        string dictionaryName = entryName.Text;

        if (!string.IsNullOrWhiteSpace(dictionaryName))
        {
            NameWordlist newDictionary = new NameWordlist
            {
                Name = dictionaryName,
                ID = int.Parse(ButtonId) //convert str Id to int to keep ID (database)
            };

            await App.Database.SaveNoteAsync(newDictionary);
            await PrintDatabaseContent();
            await Navigation.PushAsync(new CreateWordPage(ButtonId)); // sending ID(str) parameter to CreateWordPage


        }
        else
        {
            await DisplayAlert("Error", "Please enter a dictionary name", "OK");
        }
        async Task PrintDatabaseContent()
        {
            var databasePrinter = new DatabasePrinter();
            await databasePrinter.PrintDatabaseContent();
        }
    }
}