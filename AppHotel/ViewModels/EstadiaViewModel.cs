using System.ComponentModel;
using System.Runtime.CompilerServices;
using AppHotel.Models;

namespace AppHotel.ViewModels;

public sealed class EstadiaViewModel : INotifyPropertyChanged
{
    private double _adultos = 1;
    private double _criancas;
    private DateTime? _entrada;
    private DateTime? _saida;
    private Suite? _suiteSelecionada;

    public EstadiaViewModel() : this(DateTime.Today)
    {
    }

    internal EstadiaViewModel(DateTime hoje)
    {
        DataMinimaEntrada = hoje.Date;
        _entrada = DataMinimaEntrada;
        _saida = DataMinimaSaida;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public Suite[] Suites { get; } =
    [
        new("Suíte Jardim", "No térreo, com varanda voltada para o jardim.", 130m, 65m),
        new("Suíte Vista da Serra", "Janelas amplas com vista da Mantiqueira.", 180m, 90m),
        new("Suíte Mirante", "No andar superior, com terraço privativo.", 260m, 130m)
    ];

    public DateTime DataMinimaEntrada { get; }
    public DateTime DataMaximaEntrada => DataMinimaEntrada.AddMonths(1);
    public DateTime DataMinimaSaida => (Entrada ?? DataMinimaEntrada).AddDays(1);
    public DateTime DataMaximaSaida => (Entrada ?? DataMinimaEntrada).AddMonths(6);

    public DateTime? Entrada
    {
        get => _entrada;
        set
        {
            var entrada = value?.Date;
            if (_entrada == entrada)
                return;

            _entrada = entrada;
            var saidaAnterior = _saida;
            if (_saida < DataMinimaSaida)
                _saida = DataMinimaSaida;
            else if (_saida > DataMaximaSaida)
                _saida = DataMaximaSaida;

            Notificar(nameof(DataMinimaSaida));
            Notificar(nameof(DataMaximaSaida));
            if (_saida != saidaAnterior)
                Notificar(nameof(Saida));
            Notificar();
        }
    }

    public DateTime? Saida
    {
        get => _saida;
        set => _saida = value?.Date;
    }

    public Suite? SuiteSelecionada
    {
        get => _suiteSelecionada;
        set
        {
            if (_suiteSelecionada == value)
                return;

            _suiteSelecionada = value;
            Notificar();
        }
    }

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

        if (entrada < DataMinimaEntrada || entrada > DataMaximaEntrada)
            return (null, $"Selecione um check-in entre {DataMinimaEntrada:dd/MM/yyyy} e {DataMaximaEntrada:dd/MM/yyyy}.");

        if (saida < DataMinimaSaida || saida > DataMaximaSaida)
            return (null, $"Selecione um check-out entre {DataMinimaSaida:dd/MM/yyyy} e {DataMaximaSaida:dd/MM/yyyy}.");

        return (new ResumoEstadia(suite, (int)Adultos, (int)Criancas, entrada, saida), null);
    }

    private void AtualizarQuantidade(ref double quantidade, double valor, [CallerMemberName] string? propriedade = null)
    {
        if (quantidade == valor)
            return;

        quantidade = valor;
        Notificar(propriedade);
    }

    private void Notificar([CallerMemberName] string? propriedade = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
}
