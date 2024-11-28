using IfoodSocial.Core;
using IfoodSocial.Core.Dto;
using IfoodSocial.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IfoodSocial.API;

[ApiController]
[Route("api/[controller]")]
public class CidadeController : ControllerBase
{
    private readonly ICidadeRepository _cidadeCRUD;

    public CidadeController(ICidadeRepository cidadeCRUD)
    {
        _cidadeCRUD = cidadeCRUD;
    }

    [HttpPost(Name = "CreateCidade")]
    public IActionResult Post([FromBody] CidadeRequestPost cidade)
    {
        if(cidade == null)
        {
            return BadRequest();
        }

        var cdd = _cidadeCRUD.Create(cidade);
        return CreatedAtAction(nameof(Get), new { id = cdd.Cod_Cidade }, cidade);
    }

    [HttpGet(Name = "GetCidades")]
    public IEnumerable<CidadeRequest> Get()
    {
        return _cidadeCRUD.ReadAll();
    }

    [HttpGet("{id}", Name = "GetCidade")]
    public ActionResult<Cidade> Get(int id)
    {
        try
        {
            var cidade = _cidadeCRUD.ReadById(id);
            if (cidade == null)
            {
                return NotFound($"Cidade with ID {id} not found.");
            }
            return Ok(cidade);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateCidade")]
    public void Update(Cidade cidade)
    {
        _cidadeCRUD.Update(cidade);

    }

    [HttpDelete(Name = "DeleteCidade")]
    public void Delete(CidadeRequest cidade)
    {
        _cidadeCRUD.Delete(cidade);
    }

    [HttpPost("{cidadeId}/bairro", Name = "CreateCidadeBairro")]
    public IActionResult PostBairro([FromBody] Bairro bairro, int cidadeId)
    {
        if (bairro == null)
        {
            return BadRequest();
        }

        _cidadeCRUD.CreateBairro(cidadeId, bairro);

        return Created();
    }
}