using System;
using System.Collections.Generic;

namespace gcgov.Models;
public partial class UgUsuario
{
    public int UgUsuariosId { get; set; }
    public int? UsuarioId { get; set; }
    public int? UgCodigoId { get; set; }
    public virtual UnidadesGestora? UgCodigo { get; set; }
    public virtual Usuario? Usuario { get; set; }
}
