using DescontroladaMarket.Domain.Contracts;
using DescontroladaMarket.Domain.Models;
using DescontroladaMarket.Domain.Services;
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
    private readonly IProdutoService _produtoService;
    public ProdutosController(IRepositoryWrapper context, IProdutoService produtoService)
    {
        _produtoService = produtoService;
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
            return StatusCode(500, "Erro ao buscar produto");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Produtos>> CreateProduto([FromBody] Produtos produto)
    {
        try
        {
            var produtoAdicionado = await _produtoService.AdicionarProduto(produto);
            _context.Produtos.Create(produto);
            await _context.SaveAsync();

            return Ok(produto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new 
            { 
                message = ex.Message 
            });
        }
    }
}