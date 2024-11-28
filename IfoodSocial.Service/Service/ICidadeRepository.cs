using IfoodSocial.Core;
using IfoodSocial.Core.Dto;

namespace IfoodSocial.Service;

public interface ICidadeRepository : IBaseRepository<CidadeRequestPost, CidadeRequest, Cidade>
{
    public Cidade? CreateBairro(int cidadeId, Bairro bairro);
}