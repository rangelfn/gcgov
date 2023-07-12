using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GCGov.Models;

public partial class Edital
{
    public int EdtId { get; set; }
    [DisplayName("Numero")] 
    public string EdtNum { get; set; } = null!;
    [DisplayName("Tipo")]
    public string EdtTipo { get; set; } = null!;
    [DisplayName("Link")]
    public string EdtLink { get; set; } = null!;
    [DisplayName("Data Publicação")]
	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime EdtData { get; set; }

    [DisplayName("Extrato do Contrato")]
    public int? ContratoId { get; set; }
    public virtual Contrato? Contrato { get; set; }
}