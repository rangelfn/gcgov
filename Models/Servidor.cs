using System.ComponentModel.DataAnnotations;

namespace GCGov.Models;

public partial class Servidor
{
	[Display(Name = "Matrícula")]
	public int Matricula { get; set; }
	[Display(Name = "Nome")]
	public string Nome { get; set; } = null!;
	[Display(Name = "CPF")]
	public string Cpf { get; set; } = null!;
	[Display(Name = "Unidade Gestora")]
	public int? UgCodigoId { get; set; }
	[Display(Name = "Departamento")]
	public int? UgDpId { get; set; }
    public virtual ICollection<PortariaServidor> PortariasServidores { get; set; } = new List<PortariaServidor>();
	[Display(Name = "Unidade Gestora")] 
	public virtual UnidadesGestora? UgCodigo { get; set; }
	[Display(Name = "Departamento")]
	public virtual UgDepartamento? UgDp { get; set; }
}