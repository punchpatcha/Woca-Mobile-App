using MyWordlistPage.Model;
using System;
using System.Collections.ObjectModel;

namespace MyWordlistPage.View.Flashcard
{
    public partial class FlashcardMyWordlist : ContentPage
    {
        // ตัวแปรสำหรับเก็บรายการคำศัพท์
        public ObservableCollection<Word> Words { get; set; }
        private int currentIndex = 0;


        // ตัวแปรสำหรับเก็บจำนวนคำทั้งหมดในคลัง
        private int _totalWordsCount;
        public int TotalWordsCount
        {
            get { return _totalWordsCount; }
            set
            {
                _totalWordsCount = value;
                OnPropertyChanged(nameof(TotalWordsCount));
            }
        }

        // ตัวแปรสำหรับเก็บดัชนีปัจจุบันของคำศัพท์ที่แสดง
        private int _currentIndex;
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                _currentIndex = value;
                OnPropertyChanged(nameof(CurrentIndex));
            }
        }

        public FlashcardMyWordlist(ObservableCollection<Word> words)
        {
            InitializeComponent();

            // กำหนดค่าข้อมูลให้กับ ObservableCollection
            Words = words;

            // กำหนดค่าเริ่มต้นให้ CurrentIndex เป็น 0
            CurrentIndex = 0;

            // กำหนด DataContext เป็นตัวเอง
            this.BindingContext = this;

            // กำหนดจำนวนคำทั้งหมดในคลัง
            TotalWordsCount = Words.Count;

            // แสดงคำแรกที่ flashcard
            DisplayCurrentWord();
        }

        // แสดงคำแรกที่ flashcard
        private void DisplayCurrentWord()
        {
            if (currentIndex < Words.Count)
            {
                Word currentWord = Words[currentIndex];
                WordCard.Text = currentWord.WordText;
                meaningLabel.Text = "";
                TypeLabel.Text = "";
                CountLabel.Text = $" {currentIndex + 1} / {Words.Count}";
            }
        }

        private void ShowMeaning()
        {
            if (currentIndex < Words.Count)
            {
                Word currentWord = Words[currentIndex];
                meaningLabel.Text = currentWord.Meaning;
            }
        }

        private void ShowType()
        {
            if (currentIndex < Words.Count)
            {
                Word currentWord = Words[currentIndex];
                TypeLabel.Text = currentWord.Type;
            }
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            currentIndex++;
            if (currentIndex >= Words.Count)
            {
                currentIndex = 0;
            }
            DisplayCurrentWord();
        }

        private void pButton_Clicked(object sender, EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = Words.Count - 1;
            }
            DisplayCurrentWord();
        }

        private bool isWordDisplayed = false;
        private void Card_Clicked(object sender, EventArgs e)
        {
            if (isWordDisplayed)
            {
                WordCard.Text = "";
                ShowMeaning();
                ShowType();
            }
            else
            {
                DisplayCurrentWord();
            }

            isWordDisplayed = !isWordDisplayed;
        }

    }
}
