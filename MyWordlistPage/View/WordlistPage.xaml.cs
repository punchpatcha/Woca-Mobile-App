using MyWordlistPage.Model;
using MyWordlistPage.Services;
using MyWordlistPage.View.Wordlist;
using System.Collections.ObjectModel;

namespace MyWordlistPage.View;

public partial class WordlistPage : ContentPage
{
    async void LevelAButtonClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new LevelAPage());
    }

    async void LevelBButtonClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new LevelBPage());
    }

    async void LevelCButtonClicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new LevelBPage());
    }

    private ShowWordlistData _viewModel;
    public WordlistPage()
	{
		InitializeComponent();
        _viewModel = new ShowWordlistData(); // instance MainViewModel
        BindingContext = _viewModel; 
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await UpdateButtonStatesAsync();

    }

    private async Task UpdateButtonStatesAsync()
    {
        await _viewModel.UpdateButtonTextAndColorAsync("1");
        await _viewModel.UpdateButtonTextAndColorAsync("2");
        await _viewModel.UpdateButtonTextAndColorAsync("3");
        await _viewModel.UpdateButtonTextAndColorAsync("4");
        BindingContext = null;
        BindingContext = _viewModel;
    }
    async private void OnDictionaryButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string buttonId = button.AutomationId; 


        bool hasName = await _viewModel.HasNameAsync(buttonId);

        if (hasName)
        {
            await Navigation.PushAsync(new CreateWordPage(buttonId));
            await PrintDatabaseContent();

        }

        else
        {
        
            await Navigation.PushAsync(new AddNameWordlistPage(button.Text, buttonId));
            await PrintDatabaseContent();
        }
        async Task PrintDatabaseContent()
        {
            var databasePrinter = new DatabasePrinter();
            await databasePrinter.PrintDatabaseContent();
        }
    }
}