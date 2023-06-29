using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class PgtosTipo
{
    public int PgtoTipoId { get; set; }
    public string NotaEmpenho { get; set; } = null!;
    public DateTime DataCadastro { get; set; }
    public int? PgtoModId { get; set; }
    public int? ContratoId { get; set; }
    public int? NaturezaDespesa { get; set; }
    public virtual Contrato? Contrato { get; set; }
    public virtual DotacaoOrcamentaria? NaturezaDespesaNavigation { get; set; }
    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    public virtual PgtosModalidade? PgtoMod { get; set; }
}
