using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class ModLicitacao
{
    public int ModLicitacaoId { get; set; }

    public string ModNome { get; set; } = null!;

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
