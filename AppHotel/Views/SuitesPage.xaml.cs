using AppHotel.Models;
using AppHotel.ViewModels;

namespace AppHotel.Views;

public partial class SuitesPage : ContentPage
{
    private readonly EstadiaViewModel _estadia;

    public SuitesPage(EstadiaViewModel estadia)
    {
        InitializeComponent();
        _estadia = estadia;
        BindingContext = estadia;
    }

    private async void Selecionar(object? sender, EventArgs e)
    {
        if (sender is Button { CommandParameter: Suite suite })
        {
            _estadia.SuiteSelecionada = suite;
            await Navigation.PopAsync();
        }
    }

    private async void Voltar(object? sender, EventArgs e) => await Navigation.PopAsync();
}
