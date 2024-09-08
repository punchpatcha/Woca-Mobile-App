using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyWordlistPage.Model
{
    public class ShowWordData : INotifyPropertyChanged
    {
        private string _exampleProperty;
        private ObservableCollection<Word> _words;

        public string ExampleProperty
        {
            get { return _exampleProperty; }
            set
            {
                if (_exampleProperty != value)
                {
                    _exampleProperty = value;
                    OnPropertyChanged(nameof(ExampleProperty));
                }
            }
        }

        public ObservableCollection<Word> Words
        {
            get { return _words; }
            set
            {
                if (_words != value)
                {
                    _words = value;
                    OnPropertyChanged(nameof(Words));
                }
            }
        }
        // ฟังก์ชันเรียกใช้เมื่อต้องการแสดงข้อความเริ่มต้น
        public void SetInitialMessage(string message)
        {
            ExampleProperty = message;
        }

        // ฟังก์ชันเรียกใช้เมื่อต้องการล้างข้อความ
        public void ClearMessage()
        {
            ExampleProperty = "";
        }

        public async Task LoadWordsByDictionaryIdAsync(string dictionaryId)
        {
            var words = await App.Database.GetWordsByDictionaryIdAsync(dictionaryId);
            Words = new ObservableCollection<Word>(words);

            if (Words.Count == 0)
            {
                SetInitialMessage("        กดปุ่ม +\nเพื่อสร้างคำศัพท์ใหม่");
            }
            else
            {
                ClearMessage();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
