using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class Pagamento
{
    public int PgtoId { get; set; }

    public string NotaLancamento { get; set; } = null!;

    public string PreparacaoPagamento { get; set; } = null!;

    public string OrdemBancaria { get; set; } = null!;

    public decimal Valor { get; set; }

    public DateTime DataPagamento { get; set; }

    public string Parcela { get; set; } = null!;

    public int? PgtoTipoId { get; set; }

    public virtual PgtosTipo? PgtoTipo { get; set; }
}
