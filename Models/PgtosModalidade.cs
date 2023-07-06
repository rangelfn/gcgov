namespace GCGov.Models;

public partial class PgtosModalidade
{
    public int PgtoModId { get; set; }
    public string PgtoModNome { get; set; } = null!;
    public virtual ICollection<PgtosTipo> PgtosTipos { get; set; } = new List<PgtosTipo>();
}