using System;
using System.Collections.Generic;

namespace gcgov.Models;
public partial class ViewEditaisPorContrato
{
    public int? UgCodigoId { get; set; }
    public string ProcessoSei { get; set; } = null!;
    public string Contratada { get; set; } = null!;
    public string Objeto { get; set; } = null!;
    public int? ModId { get; set; }
    public decimal? Valor { get; set; }
    public string EdtNum { get; set; } = null!;
    public string EdtTipo { get; set; } = null!;
    public DateTime EdtData { get; set; }
}
