﻿using System.ComponentModel.DataAnnotations;

namespace GCGov.Models
{
    public partial class Contrato
    {
        public int ContratoId { get; set; }

        [Display(Name = "Extrato")]
        public string Extrato { get; set; } = null!;

        [Display(Name = "Contratante")]
        public string Contratante { get; set; } = null!;

        [Display(Name = "Contratada")]
        public string Contratada { get; set; } = null!;

        [Display(Name = "Objeto")]
        public string Objeto { get; set; } = null!;

        [Display(Name = "Vigência Dias")]
        public int Vigencia { get; set; }

        [Display(Name = "Início")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Processo SEI")]
        public string ProcessoSei { get; set; } = null!;

        [Display(Name = "Link")]
        public string LinkPublico { get; set; } = null!;

        [Display(Name = "Assinatura")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DataAssinatura { get; set; }

        [Display(Name = "Protocolo DIOF")]
        public string ProtocoloDiof { get; set; } = null!;

        [Display(Name = "Modalidade")]
        public int? ModId { get; set; }

        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }

        [Display(Name = "Unidade Gestora")]
        public int? UgCodigoId { get; set; }

        [Display(Name = "Departamento")]
        public int? UgDpId { get; set; }
		[Display(Name = "Complexidade")]
		public int? ComplexId { get; set; }
		[Display(Name = "Tipo")]
		public int? TipoId { get; set; }

		// Propriedades adicionadas para os campos de nome
		[Display(Name = "Modalidade")]
        public virtual Modalidade? Modalidade { get; set; }

        [Display(Name = "Unidade Gestora")]
        public virtual UnidadesGestora? UgCodigo { get; set; }

        [Display(Name = "Departamento")]
        public virtual UgDepartamento? UgDp { get; set; }
		[Display(Name = "Complexidade")]
		public virtual Complexidade? Complex { get; set; }
		[Display(Name = "Tipo")]
		public virtual Tipo? Tipo { get; set; }

		public virtual ICollection<Aditivo> Aditivos { get; set; } = new List<Aditivo>();
        public virtual ICollection<Apostilamento> Apostilamentos { get; set; } = new List<Apostilamento>();
        public virtual ICollection<Edital> Editais { get; set; } = new List<Edital>();
        public virtual ICollection<PgtosOrigem> PgtosOrigens { get; set; } = new List<PgtosOrigem>();
        public virtual ICollection<Portaria> Portaria { get; set; } = new List<Portaria>();
	}
}