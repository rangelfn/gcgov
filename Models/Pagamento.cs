using System.ComponentModel;

namespace GCGov.Models;

public partial class Pagamento
{
    public int PgtoId { get; set; }
    [DisplayName("Nota Lançamento")]
    public string NotaLancamento { get; set; } = null!;
    [DisplayName("Preparação de Pagamento")]
    public string PreparacaoPagamento { get; set; } = null!;
    [DisplayName("Ordem Bancária")]
    public string OrdemBancaria { get; set; } = null!;
    [DisplayName("Valor")]
    public decimal Valor { get; set; }
    [DisplayName("Data")]
    public DateTime DataPagamento { get; set; }
    [DisplayName("Parcela")]
    public string Parcela { get; set; } = null!;
    [DisplayName("Nota Empenho")]
    public int? PgtoOrigemId { get; set; }
    public virtual PgtosOrigem? PgtosOrigens { get; set; }
}