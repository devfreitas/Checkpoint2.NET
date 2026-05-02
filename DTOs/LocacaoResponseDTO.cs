namespace CP2.DTOs;

public class LocacaoResponseDTO
{
    public string Carro { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal ValorDiaria { get; set; }
    public decimal Subtotal { get; set; }
    public string Desconto { get; set; } = string.Empty;
    public decimal ValorFinal { get; set; }

}