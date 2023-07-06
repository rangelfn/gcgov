using System.ComponentModel;

namespace GCGov.Models;

public partial class DotacaoOrcamentaria
{
    [DisplayName("Natureza")] 
    public int NaturezaDespesa { get; set; }

    [DisplayName("Fonte")] 
    public int? FonteRecurso { get; set; }

    [DisplayName("Programa")] 
    public int? ProgramaTrabalho { get; set; }
    
    [DisplayName("Tipo de Pagamento")]
    public virtual ICollection<PgtosTipo> PgtosTipos { get; set; } = new List<PgtosTipo>();

}