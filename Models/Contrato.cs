using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class Contrato
{
    public int ContratoId { get; set; }

    public string Extrato { get; set; } = null!;

    public string Contratante { get; set; } = null!;

    public string Contratada { get; set; } = null!;

    public string Objeto { get; set; } = null!;

    public int Vigencia { get; set; }

    public DateTime DataInicio { get; set; }

    public string ProcessoSei { get; set; } = null!;

    public string LinkPublico { get; set; } = null!;

    public DateTime DataAssinatura { get; set; }

    public string ProtocoloDiof { get; set; } = null!;

    public int? ModLicitacaoId { get; set; }

    public decimal? Valor { get; set; }

    public int? UgCodigoId { get; set; }

    public int? UgDpId { get; set; }

    public virtual ICollection<Aditivo> Aditivos { get; set; } = new List<Aditivo>();

    public virtual ICollection<Apostilamento> Apostilamentos { get; set; } = new List<Apostilamento>();

    public virtual ICollection<Editai> Editais { get; set; } = new List<Editai>();

    public virtual ModLicitacao? ModLicitacao { get; set; }

    public virtual ICollection<PgtosTipo> PgtosTipos { get; set; } = new List<PgtosTipo>();

    public virtual ICollection<Portaria> Portaria { get; set; } = new List<Portaria>();

    public virtual UnidadesGestora? UgCodigo { get; set; }

    public virtual UgDepartamento? UgDp { get; set; }
}
