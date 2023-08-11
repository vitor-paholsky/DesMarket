using DescontroladaMarket.Domain.Contracts;
using DescontroladaMarket.Domain.Models;
using DescontroladaMarket.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DescontroladaMarket.Web.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutosController : ControllerBase
{
    private IRepositoryWrapper _context;
    public ProdutosController(IRepositoryWrapper context)
    {
        _context = context;
    }

    // GET: api/Produtos
    [HttpGet("api/produtos")]
    public IActionResult GetProdutos()
    {
        return Ok(_context.Produtos.FindAll());
    }

    // GET: api/Produtos/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduto(int id)
    {
        var produto = _context.Produtos.FindByCondition(x => x.Id == id).FirstOrDefault();

        if (produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    // POST: api/Produtos
    [HttpPost("Create")]
    public async Task<ActionResult> CreateProduto([FromBody] Produtos produto)
    {
        try
        {
            _context.Produtos.Create(produto);

            if (_context == null)
            {
                return NotFound(HttpStatusCode.NoContent);
            }

            _context.Save();

            return Ok(HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/Produtos/5
    [HttpPut("{id}/Update")]
    public async Task<ActionResult> UpdateProduto([FromBody] Produtos produto)
    {
        try
        {
            var produtoUpload = _context.Produtos.GetProdutoByName(produto.Nome);

            produtoUpload.Nome = produto.Nome;
            produtoUpload.Descricao = produto.Descricao;
            produtoUpload.PrecoVenda = produto.PrecoVenda;
            produtoUpload.Quantidade = produto.Quantidade;

            _context.Produtos.UpdateProdutos(produtoUpload);

            if (_context == null)
            {
                return NotFound(HttpStatusCode.NoContent);
            }

            _context.Save();

            return Ok(HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

    // DELETE: api/Produtos/5
//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteProduto(int id)
//    {
//        var produto = await _context.Produtos.Delete(x => x.Id == id).FirstOrDefault();
//        if (produto == null)
//        {
//            return NotFound();
//        }

//        _context.Produtos.Remove(produto);

//        return Ok(produto);
//    }
//}