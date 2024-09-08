using Microsoft.Maui.Controls;
using MyWordlistPage.Model;
using System;

namespace MyWordlistPage.View
{
    public partial class CreateWordPage : ContentPage
{
    private readonly string _buttonId;
    private readonly ShowWordData _viewModel;

    public CreateWordPage(string buttonId)
    {
        InitializeComponent();
        _buttonId = buttonId;
        _viewModel = new ShowWordData();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadWords();
    }

    private async Task LoadWords()
    {
        await _viewModel.LoadWordsByDictionaryIdAsync(_buttonId);
    }

    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddWordPage(_buttonId)); // sending ID(str) => which wordlist

    }
}
}
