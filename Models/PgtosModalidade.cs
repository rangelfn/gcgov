using System.ComponentModel;

namespace GCGov.Models;

public partial class PgtosModalidade
{
    public int PgtoModId { get; set; }
    [DisplayName("Modalidade")]
    public string PgtoModNome { get; set; } = null!;
    public virtual ICollection<PgtosOrigem> PgtosOrigens { get; set; } = new List<PgtosOrigem>();
}