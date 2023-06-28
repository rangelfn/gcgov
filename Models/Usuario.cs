using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nome { get; set; } = null!;

    public string LoginCpf { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual ICollection<UgUsuario> UgUsuarios { get; set; } = new List<UgUsuario>();
}
