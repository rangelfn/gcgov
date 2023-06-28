using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class Servidore
{
    public int Matricula { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public int? UgCodigoId { get; set; }

    public int? UgDpId { get; set; }

    public virtual ICollection<PortariasServidore> PortariasServidores { get; set; } = new List<PortariasServidore>();

    public virtual UnidadesGestora? UgCodigo { get; set; }

    public virtual UgDepartamento? UgDp { get; set; }
}
