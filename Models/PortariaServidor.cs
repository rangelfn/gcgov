using System;
using System.Collections.Generic;

namespace gcgov.Models;
public partial class PortariaServidor
{
    public int PortariasPessoasId { get; set; }
    public string Funcao { get; set; } = null!;
    public string Resolucao { get; set; } = null!;
    public int? PortariaId { get; set; }
    public int? Matricula { get; set; }
    public virtual Servidor? MatriculaNavigation { get; set; }
    public virtual Portaria? Portaria { get; set; }
}
