using System;
using System.Collections.Generic;

namespace gcgov.Models;
public partial class Apostilamento
{
    public int AptId { get; set; }
    public string AptNum { get; set; } = null!;
    public string AptDesc { get; set; } = null!;
    public DateTime? AptData { get; set; }
    public decimal Valor { get; set; }
    public int? ContratoId { get; set; }
    public virtual Contrato? Contrato { get; set; }
}
