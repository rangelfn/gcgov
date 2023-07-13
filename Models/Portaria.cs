using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GCGov.Models;

public partial class Portaria
{
    public int PortariaId { get; set; }
    [Display(Name = "Número")]
    public string PortariaNumero { get; set; } = null!;
    [Display(Name = "Protocolo")]
    public string ProtocoloDiof { get; set; } = null!;
    [Display(Name = "Data Publicacao")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
    public DateTime? DataPublicacao { get; set; }
    [Display(Name = "Data Inicio")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
    public DateTime? DataInicio { get; set; }
    [DisplayName("Extrato do Contrato")]
    public int? ContratoId { get; set; }
    [DisplayName("Extrato do Contrato")]
    public virtual Contrato? Contrato { get; set; }
    public virtual ICollection<PortariaServidor> PortariasServidores { get; set; } = new List<PortariaServidor>();
}