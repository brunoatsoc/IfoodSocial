using System.Linq;
using System.Security.Cryptography.X509Certificates;
using IfoodSocial.Core;
using IfoodSocial.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace IfoodSocial.Service;

public class CidadeRepository : ICidadeRepository
{
    private IfoodSocialDBContext _context;

    public CidadeRepository(IfoodSocialDBContext context)
    {
        _context = context;
    }

    public Cidade Create(CidadeRequestPost entity)
    {
        var cidade = new Cidade {
            Dcr_Cidade = entity.Dcr_Cidade,
            Bairros = new List<Bairro>()
        };

        _context.Cidades.Add(cidade);
        _context.SaveChanges();

        return cidade;
    }

    public void Delete(CidadeRequest cidadeRequest)
    {
        // Busca a entidade no banco de dados com base no Cod_Cidade.
        var cidade = _context.Cidades
            .Include(c => c.Bairros) // Inclui relacionamentos, se necessário.
            .FirstOrDefault(c => c.Dcr_Cidade == cidadeRequest.Dcr_Cidade); // Critério de busca.

        // Verifica se a entidade foi encontrada.
        if (cidade is not null)
        {
            // Remove a entidade do contexto.
            _context.Cidades.Remove(cidade);

            // Salva as alterações no banco de dados.
            _context.SaveChanges();
        }
    }


    public IEnumerable<CidadeRequest> ReadAll()
    {
        return _context.Cidades
            .Include(x => x.Bairros)
            .ThenInclude(b => b.Localidades)
            .Select(CidadeFactory.Create);
    }


    public CidadeRequest? ReadById(int id)
    {
        // Busca a cidade no banco de dados, incluindo os relacionamentos necessários.
        var cidade = _context.Cidades
            .Include(c => c.Bairros)
            .ThenInclude(b => b.Localidades) // Inclui localidades, se necessário.
            .FirstOrDefault(c => c.Cod_Cidade == id);

        // Se a cidade não for encontrada, retorna null.
        if (cidade == null) return null;

        // Transforma a entidade em um DTO.
        return CidadeFactory.Create(cidade);
    }


    public void Update(Cidade entity)
    {
        var cidade = this.Find(entity.Cod_Cidade);

        if(cidade is not null)
        {
            cidade.Dcr_Cidade = entity.Dcr_Cidade;
            _context.SaveChanges();
        }
    }

    public Cidade? CreateBairro(int cidadeId, Bairro bairro)
    {
        var cidade = this.Find(cidadeId);

        if(cidade is not null)
        {
            if(cidade.Bairros is null)
            {
                cidade.Bairros = new List<Bairro>();
            }
            cidade.Bairros.Add(bairro);
            _context.SaveChanges();
        }
        return cidade;
    }

    private Cidade? Find(int id)
    {
        return _context.Cidades.Include(s => s.Bairros).FirstOrDefault(x => x.Cod_Cidade == id);
    }
}