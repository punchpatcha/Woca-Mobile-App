using Microsoft.Extensions.Logging;

namespace MyWordlistPage
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Prompt-Regular.ttf", "Prompt-Regular");
                    fonts.AddFont("Prompt-Bold.ttf", "Prompt-Bold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
