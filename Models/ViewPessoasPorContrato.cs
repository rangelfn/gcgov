using System;
using System.Collections.Generic;

namespace GCGov.Models;

public partial class ViewPessoasPorContrato
{
    public int? UgCodigoId { get; set; }
    public string ProcessoSei { get; set; } = null!;
    public string Contratada { get; set; } = null!;
    public string Objeto { get; set; } = null!;
    public int? ModId { get; set; }
    public decimal? Valor { get; set; }
    public string Matricula { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Funcao { get; set; } = null!;
    public string Tipo { get; set; } = null!;
}
