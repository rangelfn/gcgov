using System.ComponentModel;

namespace GCGov.Models;

public partial class PgtosModalidade
{
    public int PgtoModId { get; set; }
    [DisplayName("Mod. Pagamento")]
    public string PgtoModNome { get; set; } = null!;
    [DisplayName("Nota empenho")]
    public virtual ICollection<PgtosOrigem> PgtosOrigens { get; set; } = new List<PgtosOrigem>();
}