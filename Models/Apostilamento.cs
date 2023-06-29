using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GCGov.Models
{
    public partial class Apostilamento
    {
        public int AptId { get; set; }
        [Display(Name = "Número")]
        public string AptNum { get; set; } = null!;
        [Display(Name = "Descrição")]
        public string AptDesc { get; set; } = null!;
        [Display(Name = "Data")]
        public DateTime? AptData { get; set; }
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
        [Display(Name = "Contrato")]
        public int? ContratoId { get; set; }
        [Display(Name = "Contrato")]
        public virtual Contrato? Contrato { get; set; }
        [Display(Name = "Extrato")]
        public virtual string ExtratoContrato => Contrato?.Extrato;
    }
}
