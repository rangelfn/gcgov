using System;
using System.Collections.Generic;

namespace gcgov.Models;

public partial class VwContratosPagamento
{
    public int? UgCodigoId { get; set; }

    public string ProcessoSei { get; set; } = null!;

    public string Contratada { get; set; } = null!;

    public string Objeto { get; set; } = null!;

    public int? ModId { get; set; }

    public decimal? Valor { get; set; }

    public string NotaEmpenho { get; set; } = null!;

    public DateTime DataCadastro { get; set; }

    public string NotaLancamento { get; set; } = null!;

    public string PreparacaoPagamento { get; set; } = null!;

    public string OrdemBancaria { get; set; } = null!;

    public decimal ValorPagamento { get; set; }

    public DateTime DataPagamento { get; set; }

    public string Parcela { get; set; } = null!;
}
