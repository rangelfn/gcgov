namespace GCGov.Models;

public partial class Servidor
{
    public int Matricula { get; set; }
    public string Nome { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public int? UgCodigoId { get; set; }
    public int? UgDpId { get; set; }
    public virtual ICollection<PortariaServidor> PortariasServidores { get; set; } = new List<PortariaServidor>();
    public virtual UnidadesGestora? UgCodigo { get; set; }
    public virtual UgDepartamento? UgDp { get; set; }
}