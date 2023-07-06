namespace GCGov.Models;

public partial class ViewDespesasPorContrato
{
    public int? UgCodigoId { get; set; }
    public string ProcessoSei { get; set; } = null!;
    public string Contratada { get; set; } = null!;
    public string Objeto { get; set; } = null!;
    public int? ModId { get; set; }
    public decimal? Valor { get; set; }
    public string Programa { get; set; } = null!;
    public string Acao { get; set; } = null!;
    public string? Fonte { get; set; }
    public string? Natureza { get; set; }
    public string? Elemento { get; set; }
}