using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GCGov.Models
{
    public partial class Aditivo
    {
        public int AdtId { get; set; }

        [DisplayName("Número do Aditivo")]
        public string AdtNum { get; set; } = null!;

        [DisplayName("Descrição")]
        public string Descricao { get; set; } = null!;

        [DisplayName("Data do Aditivo")]
        public DateTime? AdtData { get; set; }

        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        [DisplayName("Extrato do Contrato")]
        public int? ContratoId { get; set; }

        public virtual Contrato? Contrato { get; set; }
    }
}
