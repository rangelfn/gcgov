using System;
using System.Collections.Generic;

namespace GCGov.Models;
public partial class DotacaoOrcamentaria
{
    public int NaturezaDespesa { get; set; }
    public int? FonteRecurso { get; set; }
    public int? ProgramaTrabalho { get; set; }
    public virtual ICollection<PgtosTipo> PgtosTipos { get; set; } = new List<PgtosTipo>();
}
