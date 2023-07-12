using System.ComponentModel;

namespace GCGov.Models;

public partial class NaturezaDespesa
{
    public int NatDespId { get; set; }

    [DisplayName("Fonte")]
    public string? FonteRecurso { get; set; }

    [DisplayName("Programa")]
    public string? ProgramaTrabalho { get; set; }

    [DisplayName("Elemento")]
    public string? ElementoDespesa { get; set; }
    [DisplayName("Tipo de Pagamento")]
    public virtual ICollection<PgtosOrigem> PgtosOrigens { get; set; } = new List<PgtosOrigem>();

}