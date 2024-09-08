using MyWordlistPage.Model;
using MyWordlistPage.Services;
using MyWordlistPage.View.Flashcard;
using System.Collections.ObjectModel;

namespace MyWordlistPage.View;

public partial class FlashCardPage : ContentPage
{

    private LevelAService levelAService;
    private LevelBService levelBService;
    private LevelCService levelCService;

    private LevelService selectedService;

    public FlashCardPage()
	{
		InitializeComponent();

        levelAService = new LevelAService();
        levelBService = new LevelBService();
        levelCService = new LevelCService();

        LoadWordlists();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadWordlists(); // เรียกเมธอดที่โหลดข้อมูลคลังคำศัพท์
    }

    private async void LoadWordlists()
    {
        var database = new Database();
        var wordlists = await database.GetNamesAsync();

        int buttonIndex = 1; // ใช้สำหรับกำหนด AutomationId และการจัดตำแหน่งของปุ่ม
        foreach (var wordlist in wordlists)
        {
            if (!string.IsNullOrEmpty(wordlist.Name))
            {
                var button = new Button
                {
                    Text = wordlist.Name,
                    AutomationId = buttonIndex.ToString(),
                    BackgroundColor = Color.FromRgb(32, 138, 224) // ตั้งสีพื้นหลังเป็นสีฟ้า
                };
                button.Clicked += OnDictionaryButtonClicked;
                WordlistContainer.Children.Add(button);
                buttonIndex++; // เพิ่มค่า index สำหรับปุ่มถัดไป
            }
        }

        // ลบปุ่มที่ไม่มีชื่อออกจากหน้า UI
        for (int i = WordlistContainer.Children.Count - 1; i >= 0; i--)
        {
            var child = WordlistContainer.Children[i];
            if (child is Button button && string.IsNullOrEmpty(button.Text))
            {
                WordlistContainer.Children.Remove(child);
            }
        }
    }


    private async void OnDictionaryButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string buttonId = button.AutomationId;

        // สร้าง instance ของคลาส Database
        var database = new Database();

        // เรียกใช้เมธอด GetWordsByDictionaryIdAsync เพื่อดึงคำศัพท์ตาม ID ของคลังคำศัพท์
        var words = await database.GetWordsByDictionaryIdAsync(buttonId);

        // แปลง List<MyWordlistPage.Model.Word> เป็น ObservableCollection<MyWordlistPage.Model.Word>
        var observableWords = new ObservableCollection<MyWordlistPage.Model.Word>(words);

        // สร้างหน้า FlashcardMyWordlist พร้อมส่งคำศัพท์ที่ดึงมาจากฐานข้อมูลไปด้วย
        var flashcardMyWordlistPage = new FlashcardMyWordlist(observableWords);

        // เปิดหน้า FlashcardMyWordlist โดยใช้ Navigation
        await Navigation.PushAsync(flashcardMyWordlistPage);
    }


    void OnImageButtonClicked(object sender, EventArgs e)
    {
        ImageButton clickedImageButton = (ImageButton)sender;
        string imageName = clickedImageButton.Source.ToString();

        selectedService = null;
        if (imageName.EndsWith("a_btn.png"))
        {
            selectedService = levelAService;
        }
        else if (imageName.EndsWith("b_btn.png"))
        {
            selectedService = levelBService;
        }
        else if (imageName.EndsWith("c_btn.png"))
        {
            selectedService = levelCService;
        }

        selectedService.LoadData();
        Navigation.PushAsync(new FlashcardWordlist(selectedService));
    }
}