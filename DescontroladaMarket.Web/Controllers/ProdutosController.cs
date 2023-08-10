using DescontroladaMarket.Domain.Contracts;
using DescontroladaMarket.Domain.Models;
using DescontroladaMarket.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    [HttpGet]
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
    [HttpPost]
    public async Task<IActionResult> CreateProduto([FromBody] Produtos produto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Produtos.Create(produto);

       

        return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
    }

    // PUT: api/Produtos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto(int id, [FromBody] Produtos produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }

        _context.Produtos.Update(produto);

        try
        {

        }
        catch
        {
            //if (!_con(e => e.Id == id))
            //{
            //    return NotFound();
            //}
            //throw;
        }

        return NoContent();
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