namespace MyWordlistPage.View;

public partial class WelcomPage : ContentPage
{
	public WelcomPage()
	{
		InitializeComponent();
	}

    void StartButtonClicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Woca();
    }
}