using IfoodSocial.Core;
using IfoodSocial.Core.Dto;

namespace IfoodSocial.Service;

public class CidadeFactory
{
    public static CidadeRequest Create(Cidade cidade)
    {
        return new CidadeRequest(
            cidade.Dcr_Cidade ?? string.Empty,
            cidade.Bairros?.Select(b => new BairroRequest(
                b.Dcr_Bairro ?? string.Empty,
                b.Localidades?.ToList() ?? new List<Localidade>()
            )).ToList() ?? new List<BairroRequest>()
        );
    }
}
