using System.ComponentModel;

namespace GCGov.Models
{
    public partial class Aditivo
    {
        public int AdtId { get; set; }

        [DisplayName("Número do Aditivo")]
        public string AdtNum { get; set; } = null!;

        [DisplayName("Descrição")]
        public string AdtDesc { get; set; } = null!;

        [DisplayName("Data do Aditivo")]
        public DateTime? AdtData { get; set; }

        [DisplayName("Valor")]
        public decimal AdtValor { get; set; }

        [DisplayName("Extrato do Contrato")]
        public int? ContratoId { get; set; }

        public virtual Contrato? Contrato { get; set; }
    }
}