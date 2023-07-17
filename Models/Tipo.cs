namespace GCGov.Models;

public partial class Tipo
{
	public int TipoId { get; set; }
	public string TipoNome { get; set; } = null!;
	public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
