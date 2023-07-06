namespace GCGov.Models;

public partial class ViewPagamentosTotalPorContrato
{
    public int? UgCodigoId { get; set; }
    public string ProcessoSei { get; set; } = null!;
    public string Contratada { get; set; } = null!;
    public string Objeto { get; set; } = null!;
    public int? ModId { get; set; }
    public decimal? Valor { get; set; }
    public string? NotasLancamento { get; set; }
    public decimal? ValorTotalPagamentos { get; set; }
}