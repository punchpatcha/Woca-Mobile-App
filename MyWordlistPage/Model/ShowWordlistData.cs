using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyWordlistPage.Model
{
    //Create Button Name - Name of Wordlist
    public class ShowWordlistData : INotifyPropertyChanged
    {
        public string ButtonText1 { get; private set; }
        public string ButtonText2 { get; private set; }
        public string ButtonText3 { get; private set; }
        public string ButtonText4 { get; private set; }

        public Color ButtonColor1 { get; private set; }
        public Color ButtonColor2 { get; private set; }
        public Color ButtonColor3 { get; private set; }
        public Color ButtonColor4 { get; private set; }


        // Constructor และ properties ที่มีการ Binding ไปยังปุ่มในหน้า UI
        public ShowWordlistData()
        {
            InitializeButtonProperties();
        }

        private void InitializeButtonProperties()
        {
            ButtonText1 = "";
            ButtonText2 = "";
            ButtonText3 = "";
            ButtonText4 = "";

            ButtonColor1 = Color.FromRgb(217, 217, 217);
            ButtonColor2 = Color.FromRgb(217, 217, 217);
            ButtonColor3 = Color.FromRgb(217, 217, 217);
            ButtonColor4 = Color.FromRgb(217, 217, 217);

        }

        // Method สำหรับอัปเดตข้อมูลใน ViewModel
        public async Task UpdateButtonTextAndColorAsync(string buttonId)
        {
            // ลูปเกี่ยวกับปุ่มและสีที่เกี่ยวข้อง
            for (int i = 1; i <= 4; i++)
            {
                if (buttonId == i.ToString())
                {
                    // อัปเดตข้อมูล ButtonText และ ButtonColor ตาม buttonId
                    var buttonText = await GetButtonTextAsync(buttonId);
                    var buttonColor = await GetButtonColorAsync(buttonId);

                    // ใช้ Reflection เพื่ออัปเดตสมบัติของ ViewModel ด้วยชื่อสมบัติและค่าใหม่
                    GetType().GetProperty($"ButtonText{i}").SetValue(this, buttonText);
                    GetType().GetProperty($"ButtonColor{i}").SetValue(this, buttonColor);

                    // อัปเดตการแจ้งเตือนให้สมบูรณ์
                    OnPropertyChanged($"ButtonText{i}");
                    OnPropertyChanged($"ButtonColor{i}");

                    // หยุดการวนลูป
                    break;
                }
            }
        }

        private async Task<Color> GetButtonColorAsync(string buttonId)
        {
            var dictionary = await App.Database.GetIDNameAsync(int.Parse(buttonId));
            return dictionary != null ? Color.FromRgb(32, 138, 224) : Color.FromRgb(217, 217, 217);
        }


        // Method สำหรับดึงข้อมูลชื่อจากฐานข้อมูล
        private async Task<string> GetButtonTextAsync(string buttonId)
        {
            // เรียกใช้ฐานข้อมูลเพื่อดึงข้อมูลชื่อตาม ID จากฐานข้อมูล
            var dictionary = await App.Database.GetIDNameAsync(int.Parse(buttonId));

            // ถ้าพบชื่อในฐานข้อมูลให้คืนค่าชื่อนั้น ไม่พบให้คืนค่าว่าง
            return dictionary != null ? dictionary.Name : "";
        }

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task<bool> HasNameAsync(string buttonId)
        {
            var dictionary = await App.Database.GetIDNameAsync(int.Parse(buttonId));
            return dictionary != null;
        }

    }
}

