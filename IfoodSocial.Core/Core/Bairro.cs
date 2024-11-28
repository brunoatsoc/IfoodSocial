namespace IfoodSocial.Core;

public class Bairro
{
    public int Cod_Bairro { get; set; }
    public string? Dcr_Bairro { get; set; }

    public int Cod_Cidade { get; set; }
    public virtual Cidade? Cidade { get; set; }

    public virtual ICollection<Localidade>? Localidades { get; set; }
}