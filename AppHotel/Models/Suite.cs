using System.Globalization;

namespace AppHotel.Models;

public sealed record Suite(string Nome, decimal ValorDiaria)
{
    public string DiariaFormatada => ValorDiaria.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
    public string Opcao => $"{Nome} · {DiariaFormatada}";
}
