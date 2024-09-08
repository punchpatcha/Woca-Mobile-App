using MyWordlistPage.Model;
using MyWordlistPage.Services;
using System.Collections.ObjectModel;

namespace MyWordlistPage.View.Wordlist;


public partial class LevelAPage : ContentPage
{
    public Services.LevelAService wordService { get; set; } = new Services.LevelAService();
    private ObservableCollection<WordlistProvidedModel> allWords;
    private ObservableCollection<WordlistProvidedModel> filteredWords;
    private LevelAService levelAService;

    public LevelAPage()
    {
        InitializeComponent();
        levelAService = new LevelAService();
        allWords = new ObservableCollection<WordlistProvidedModel>();
        filteredWords = new ObservableCollection<WordlistProvidedModel>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        levelAService.LoadData();
        allWords = levelAService.pWords;

        LevelACollectionView.ItemsSource = allWords;
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
        LevelACollectionView.ItemsSource = filteredWords;
    }
}
