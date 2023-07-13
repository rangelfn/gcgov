using System.ComponentModel.DataAnnotations;

namespace GCGov.Models;

public partial class PortariaServidor
{
    public int PortariasServidorID { get; set; }
	[Display(Name = "Função")]
	public string Funcao { get; set; } = null!;
	[Display(Name = "Resolução")]
	public string Resolucao { get; set; } = null!;
	[Display(Name = "Portaria")]
	public int? PortariaId { get; set; }
	[Display(Name = "Matricula")]
	public int? Matricula { get; set; }
	[Display(Name = "Matricula")]
	public virtual Servidor? MatriculaNavigation { get; set; }
    public virtual Portaria? Portaria { get; set; }
}