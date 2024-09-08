using MyWordlistPage.Model;
using MyWordlistPage.Services;

namespace MyWordlistPage.View.Flashcard;

    public partial class FlashcardWordlist : ContentPage
    {
        private LevelService lservice;

    public FlashcardWordlist(LevelService service)
    {
        InitializeComponent();

        lservice = service;
        UpdateCurrentWord(); // Display the initial word

        BindingContext = service;
        WordCard.Text = service.GetCurrentWord().Word;
    }

    void NextButton_Clicked(object sender, EventArgs e)
        {
            lservice.NextWord(); // Move to the next word
            UpdateCurrentWord(); // Update the displayed word

            WordCard.Text = "";
            WordCard.BackgroundColor = Colors.LightGray;
            WordCard.BackgroundColor = Colors.White;
            WordCard.Text = lservice.GetCurrentWord().Word;
            TypeLabel.Text = "";
            meaningLabel.Text = "";
        }

        void pButton_Clicked(object sender, EventArgs e)
        {
            lservice.PreWord(); 
            UpdateCurrentWord(); // Update the displayed word

            WordCard.Text = "";
            WordCard.BackgroundColor = Colors.LightGray;
            WordCard.BackgroundColor = Colors.White;
            WordCard.Text = lservice.GetCurrentWord().Word;
            TypeLabel.Text = "";
            meaningLabel.Text = "";
        }

        private void UpdateCurrentWord()
        {
            CountLabel.Text = lservice.getCurrentIndex().ToString() + "/" + lservice.getMax().ToString(); 
        }

        private bool isWordDisplayed = true;
        private void Card_Clicked(System.Object sender, System.EventArgs e)
        {
            if (isWordDisplayed)
            {
                WordCard.Text = "";
                meaningLabel.Text = lservice.GetCurrentWord().Meaning;
                TypeLabel.Text = lservice.GetCurrentWord().Type + ".";
            }
            else
            {
                WordCard.Text = lservice.GetCurrentWord().Word ;
                meaningLabel.Text = "";
                TypeLabel.Text = "";
            }
            isWordDisplayed = !isWordDisplayed;
        }



    }
