using System.ComponentModel;

namespace GCGov.Models;

public partial class PgtosOrigem
{
    public int PgtoOrigemId { get; set; }
    [DisplayName("Nota Empenho")]
    public string NotaEmpenho { get; set; } = null!;
    [DisplayName("Data")]
    public DateTime DataCadastro { get; set; }
    [DisplayName("Modalidade")]
    public int? PgtoModId { get; set; }
    [DisplayName("Extrato Contrato")]
    public int? ContratoId { get; set; }
    [DisplayName("Natureza Despesa")]
    public int? NatDespId { get; set; }
    public virtual Contrato? Contrato { get; set; }
    public virtual NaturezaDespesa? NatDesp { get; set; }
    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    public virtual PgtosModalidade? PgtoMod { get; set; }
}