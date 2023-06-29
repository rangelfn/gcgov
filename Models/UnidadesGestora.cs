using System;
using System.Collections.Generic;

namespace GCGov.Models;

public partial class UnidadesGestora
{
    public int UgCodigoId { get; set; }
    public string UgNome { get; set; } = null!;
    public string UgCnpj { get; set; } = null!;
    public string UgContato { get; set; } = null!;
    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    public virtual ICollection<Servidor> Servidores { get; set; } = new List<Servidor>();
    public virtual ICollection<UgDepartamento> UgDepartamentos { get; set; } = new List<UgDepartamento>();
    public virtual ICollection<UgUsuario> UgUsuarios { get; set; } = new List<UgUsuario>();
}
