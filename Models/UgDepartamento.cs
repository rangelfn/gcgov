﻿using System;
using System.Collections.Generic;

namespace gcgov.Models;
public partial class UgDepartamento
{
    public int UgDpId { get; set; }
    public string UgDpNome { get; set; } = null!;
    public int? UgCodigoId { get; set; }
    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    public virtual ICollection<Servidore> Servidores { get; set; } = new List<Servidore>();
    public virtual UnidadesGestora? UgCodigo { get; set; }
}
