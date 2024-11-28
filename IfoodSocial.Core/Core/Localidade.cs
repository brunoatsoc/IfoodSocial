namespace IfoodSocial.Core;

public class Localidade
{
    public int Cod_Localidade { get; set; }
    public string? Dcr_Localidade { get; set; }

    public int Cod_Bairro { get; set; }
    public virtual Bairro? Bairro { get; set; }

    //public int Localidade_Cod_Localidade { get; set; }
    //public virtual Localidade? Localidade { get; set; }
}