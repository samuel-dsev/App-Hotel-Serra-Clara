
namespace AppHotel;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        return MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => fonts.AddFont("DMSerifText-Regular.ttf", "HotelSerif"))
            .Build();
    }
}
