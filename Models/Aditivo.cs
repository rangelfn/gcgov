using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class Aditivo
{
    public int AdtId { get; set; }

    public string AdtNum { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public DateTime? AdtData { get; set; }

    public decimal Valor { get; set; }

    public int? ContratoId { get; set; }

    public virtual Contrato? Contrato { get; set; }
}
