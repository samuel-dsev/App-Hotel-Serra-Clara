using System.Globalization;

namespace AppHotel.Models;

public sealed class Suite(string nome, string descricao, decimal tarifaAdulto, decimal tarifaCrianca)
{
    public string Nome { get; } = nome;
    public string Descricao { get; } = descricao;
    public decimal TarifaAdulto { get; } = tarifaAdulto;
    public decimal TarifaCrianca { get; } = tarifaCrianca;
    public string TarifaAdultoFormatada => TarifaAdulto.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
    public string TarifaCriancaFormatada => TarifaCrianca.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

    public decimal CalcularDiaria(int adultos, int criancas) =>
        adultos * TarifaAdulto + criancas * TarifaCrianca;
}
