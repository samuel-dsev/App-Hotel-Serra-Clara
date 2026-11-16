
namespace AppHotel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        UserAppTheme = AppTheme.Light;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var navigation = new NavigationPage(new MainPage());
        var janela = new Window(navigation) { Title = "App Hotel · Serra Clara" };
#if WINDOWS
        var tela = DeviceDisplay.Current.MainDisplayInfo;
        janela.Width = Math.Min(1120, tela.Width / tela.Density - 32);
        janela.Height = Math.Min(740, tela.Height / tela.Density - 64);
#endif
        return janela;
    }
}
