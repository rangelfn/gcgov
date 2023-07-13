namespace GCGov.Models;

public partial class Modalidade
{
    public int ModId { get; set; }
    public string ModNome { get; set; } = null!;
    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
