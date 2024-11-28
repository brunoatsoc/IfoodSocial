namespace IfoodSocial.Core.Dto;

public record CidadeRequest(string Dcr_Cidade, ICollection<BairroRequest>? Bairros)
{
    public CidadeRequest() : this(string.Empty, new List<BairroRequest>())
    {
    }
}