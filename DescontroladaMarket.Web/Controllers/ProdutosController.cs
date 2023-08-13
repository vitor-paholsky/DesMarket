using DescontroladaMarket.Domain.Contracts;
using DescontroladaMarket.Domain.Models;
using DescontroladaMarket.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DescontroladaMarket.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IRepositoryWrapper _context;
    public ProdutosController(IRepositoryWrapper context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProdutos()
    {
        try
        {
            var produtos = _context.Produtos.GetAllProdutos().ToList();
            return Ok(produtos);
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro ao registrar produto");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Produtos>> CreateProduto([FromBody] Produtos produto)
    {
        try
        {
            _context.Produtos.Create(produto);
            await _context.SaveAsync();

            return Ok(produto);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao registrar produto");
        }
    }
}