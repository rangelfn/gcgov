using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class Edital
{
    public int EdtId { get; set; }

    public string EdtNum { get; set; } = null!;

    public string EdtTipo { get; set; } = null!;

    public string EdtLink { get; set; } = null!;

    public DateTime EdtData { get; set; }

    public int? ContratoId { get; set; }

    public virtual Contrato? Contrato { get; set; }
}
