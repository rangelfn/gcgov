using System.ComponentModel.DataAnnotations;

namespace GCGov.Models;

public partial class Portaria
{
    public int PortariaId { get; set; }
    public string PortariaNumero { get; set; } = null!;
    public string ProtocoloDiof { get; set; } = null!;
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
    public DateTime? DataPublicacao { get; set; }

	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
    public DateTime? DataInicio { get; set; }
    public int? ContratoId { get; set; }
    public virtual Contrato? Contrato { get; set; }
    public virtual ICollection<PortariaServidor> PortariasServidores { get; set; } = new List<PortariaServidor>();
}