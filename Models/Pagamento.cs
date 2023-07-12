using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime DataPagamento { get; set; }
    [DisplayName("Parcela")]
    public string Parcela { get; set; } = null!;
    [DisplayName("Nota Empenho")]
    public int? PgtoOrigemId { get; set; }
    [DisplayName("Nota Empenho")]
    public virtual PgtosOrigem? PgtosOrigens { get; set; }
}