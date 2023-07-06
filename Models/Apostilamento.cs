using System.ComponentModel;
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
        public decimal AptValor { get; set; }

        [DisplayName("Extrato do Contrato")]
        public int? ContratoId { get; set; }

        public virtual Contrato? Contrato { get; set; }
    }
}