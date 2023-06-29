using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class Portaria
{
    public int PortariaId { get; set; }
    public string PortariaNumero { get; set; } = null!;
    public string ProtocoloDiof { get; set; } = null!;
    public DateTime? DataPublicacao { get; set; }
    public DateTime? DataInicio { get; set; }
    public int? ContratoId { get; set; }
    public virtual Contrato? Contrato { get; set; }
    public virtual ICollection<PortariasServidore> PortariasServidores { get; set; } = new List<PortariasServidore>();
}
