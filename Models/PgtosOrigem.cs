using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GCGov.Models;

public partial class PgtosOrigem
{
    public int PgtoOrigemId { get; set; }
    [DisplayName("Nota Empenho")]
    public string NotaEmpenho { get; set; } = null!;
    [DisplayName("Data")]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
    public DateTime DataCadastro { get; set; }
    
    [DisplayName("Modalidade")]
    public int? PgtoModId { get; set; }
    [DisplayName("Extrato Contrato")]
    public int? ContratoId { get; set; }
    [DisplayName("Natureza Despesa")]
    public int? NatDespId { get; set; }
    
    
    [DisplayName("Extrato Contrato")]
    public virtual Contrato? Contrato { get; set; }
    [DisplayName("Natureza Despesa")]
    public virtual NaturezaDespesa? NatDesp { get; set; }
    [DisplayName("Mod. Pagamento")]
    public virtual PgtosModalidade? PgtoMod { get; set; }
    
    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();


}