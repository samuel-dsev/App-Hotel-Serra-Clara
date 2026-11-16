
using AppHotel.ViewModels;
using AppHotel.Views;

namespace AppHotel;

public partial class MainPage : ContentPage
{
    private readonly EstadiaViewModel _estadia = new();
    private bool _layoutAmplo;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = _estadia;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        bool layoutAmplo = width >= 840;
        if (_layoutAmplo == layoutAmplo)
            return;

        _layoutAmplo = layoutAmplo;
        Painel.ColumnDefinitions[0].Width = layoutAmplo ? GridLength.Star : new GridLength(0);
        Painel.ColumnSpacing = layoutAmplo ? 22 : 0;
        Grid.SetColumnSpan(Capa, layoutAmplo ? 1 : 2);
        Grid.SetRow(Formulario, layoutAmplo ? 0 : 1);
        Capa.HeightRequest = layoutAmplo ? 510 : 236;
        Marca.Padding = layoutAmplo ? new Thickness(30, 26) : new Thickness(24, 20);
        NomeHotel.FontSize = layoutAmplo ? 40 : 34;
        TituloPagina.FontSize = layoutAmplo ? 38 : 31;
    }

    private async void CalcularEstadia(object? sender, EventArgs e)
    {
        var (resumo, erro) = _estadia.Calcular();
        if (resumo is null)
        {
            await DisplayAlertAsync("Confira a estadia", erro, "Entendi");
            return;
        }

        await AbrirPagina((Button)sender!, new ResumoPage(resumo));
    }

    private async void AbrirSobre(object? sender, EventArgs e) =>
        await AbrirPagina((Button)sender!, new SobrePage());

    private async Task AbrirPagina(Button botao, Page pagina)
    {
        botao.IsEnabled = false;
        try
        {
            await Navigation.PushAsync(pagina);
        }
        finally
        {
            botao.IsEnabled = true;
        }
    }
}
