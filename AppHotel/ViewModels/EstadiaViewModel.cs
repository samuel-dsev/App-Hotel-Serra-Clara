using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppHotel.Models;

namespace AppHotel.ViewModels;

public sealed class EstadiaViewModel : INotifyPropertyChanged
{
    private double _adultos = 1;
    private double _criancas;

    public event PropertyChangedEventHandler? PropertyChanged;

    public Suite[] Suites { get; } =
    [
        new("Suíte Jardim", 240m),
        new("Suíte Vista da Serra", 360m),
        new("Suíte Mirante", 520m)
    ];

    public DateTime? DataMinima => DateTime.Today;
    public DateTime? Entrada { get; set; } = DateTime.Today;
    public DateTime? Saida { get; set; } = DateTime.Today.AddDays(1);
    public Suite? SuiteSelecionada { get; set; }

    public double Adultos
    {
        get => _adultos;
        set => AtualizarQuantidade(ref _adultos, value);
    }

    public double Criancas
    {
        get => _criancas;
        set => AtualizarQuantidade(ref _criancas, value);
    }

    public (ResumoEstadia? Resumo, string? Erro) Calcular()
    {
        if (SuiteSelecionada is not { } suite)
            return (null, "Selecione uma suíte para calcular a estadia.");

        if (Entrada is not { } entrada || Saida is not { } saida)
            return (null, "Selecione as datas de check-in e check-out.");

        if (entrada.Date < DateTime.Today)
            return (null, "Selecione uma data de check-in a partir de hoje.");

        if (saida.Date <= entrada.Date)
            return (null, "O check-out precisa ser posterior ao check-in.");

        return (new ResumoEstadia(suite, (int)Adultos, (int)Criancas, entrada, saida), null);
    }

    private void AtualizarQuantidade(ref double quantidade, double valor, [CallerMemberName] string? propriedade = null)
    {
        if (quantidade == valor)
            return;

        quantidade = valor;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
    }
}
