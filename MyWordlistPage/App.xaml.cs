using MyWordlistPage.Services;
using MyWordlistPage.View;

namespace MyWordlistPage
{
    public partial class App : Application
    {
        public static Database Database { get; private set; }
        public App()
        {
            InitializeComponent();

            Database = new Database();
            MainPage = new WelcomPage();
        }
    }
}
