using System.ComponentModel;

namespace GCGov.Models;

public partial class Complexidade
	{
		public int ComplexId { get; set; }

		public string ComplexNome { get; set; } = null!;

		public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
	}