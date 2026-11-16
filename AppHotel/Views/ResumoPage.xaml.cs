
using AppHotel.Models;

namespace AppHotel.Views;

public partial class ResumoPage : ContentPage
{
    public ResumoPage(ResumoEstadia resumo)
    {
        InitializeComponent();
        BindingContext = resumo;
    }

    private async void Voltar(object? sender, EventArgs e) => await Navigation.PopAsync();
}
