using MyWordlistPage.Model;
using MyWordlistPage.Services;
using System.Collections.ObjectModel;

namespace MyWordlistPage.View.Wordlist;


public partial class LevelBPage : ContentPage
{
    private ObservableCollection<WordlistProvidedModel> allWords;
    private ObservableCollection<WordlistProvidedModel> filteredWords;
    private LevelBService levelBService;
    public LevelBPage()
	{
		InitializeComponent();
        levelBService = new LevelBService();
        allWords = new ObservableCollection<WordlistProvidedModel>();
        filteredWords = new ObservableCollection<WordlistProvidedModel>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        levelBService.LoadData();
        allWords = levelBService.pWords;

        LevelBCollectionView.ItemsSource = allWords;
    }

    void TypePickerChanged(System.Object sender, System.EventArgs e)
    {
        string selectedType = TypePicker.SelectedItem.ToString();

        // Clear the existing filtered words
        filteredWords.Clear();

        // Filter the words based on the selected type
        foreach (var word in allWords)
        {
            if (word.Type == selectedType)
            {
                filteredWords.Add(word);
            }
        }

        // Update the CollectionView's ItemsSource with the filtered words
        LevelBCollectionView.ItemsSource = filteredWords;
    }
}
