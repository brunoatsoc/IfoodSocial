namespace IfoodSocial.Core;

public class Cidade
{
    public int Cod_Cidade { get; set; }
    public string? Dcr_Cidade { get; set; }

    public virtual ICollection<Bairro>? Bairros { get; set; }
}