using System.Globalization;

namespace AppHotel.Models;

public sealed record ResumoEstadia(Suite Suite, int Adultos, int Criancas, DateTime Entrada, DateTime Saida)
{
    public int Noites => (Saida.Date - Entrada.Date).Days;
    public decimal Total => Suite.ValorDiaria * Noites;
    public string Duracao => Noites == 1 ? "1 noite" : $"{Noites} noites";
    public string TotalFormatado => Total.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
}
