using System;
using System.Collections.Generic;

namespace GCGov.Models;

public partial class ViewPortariasPorContrato
{
    public int? UgCodigoId { get; set; }

    public string ProcessoSei { get; set; } = null!;

    public string Contratada { get; set; } = null!;

    public string Objeto { get; set; } = null!;

    public int? ModId { get; set; }

    public decimal? Valor { get; set; }

    public string PortariaNumero { get; set; } = null!;

    public string ProtocoloDiof { get; set; } = null!;

    public DateTime? DataPublicacao { get; set; }
}
