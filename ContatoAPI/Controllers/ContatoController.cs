using ContatoAPI.Models;
using ContatoAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContatoAPI.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class ContatoController : ControllerBase
    {
        [HttpGet]
        [Route(template: "Contatos")]
        public async Task<IActionResult> GetAsync([FromServices] ContatoDbContext context)
        {
            var contatos = await context
                .Contatos
                .AsNoTracking()
                .ToListAsync();
            return Ok(contatos);
        }

        [HttpGet]
        [Route(template: "Contatos/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] ContatoDbContext context,
            [FromRoute] int id)
        {
            var contatos = await context
                .Contatos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return contatos == null ? NotFound() : Ok(contatos);
        }
        [HttpPost]
        [Route(template: "Contatos")]
        public async Task<IActionResult> PostAsync([FromServices] ContatoDbContext context, [FromBody] 
        CreateContatoViewModel contato)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var contatos = new Contato
            {
                Nome = contato.Nome,
                Email = contato.Email,
                NumeroContato = contato.NumeroContato

            };

            try
            {
                await context.Contatos.AddAsync(contatos);
                await context.SaveChangesAsync();
                return Created(uri: $"v1/Contatos/{contatos.Id}", contatos);
            }

            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route(template: "Contatos/{id}")]
        public async Task<IActionResult> PutAsync([FromServices] ContatoDbContext context,
            [FromBody] CreateContatoViewModel contato, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var contatos = await context.Contatos.FirstOrDefaultAsync(x => x.Id == id);
            if (contatos == null)
                return NotFound();

            try
            {
                contatos.Nome = contato.Nome;
                contato.Email = contato.Email;
                contato.NumeroContato = contato.NumeroContato;

                context.Contatos.Update(contatos);
                await context.SaveChangesAsync();

                return Ok(contatos);

            }

            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route(template: "Contatos/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] ContatoDbContext context,
            [FromBody] CreateContatoViewModel contato, [FromRoute] int id)
        {
            var contatos = await context.Contatos.FirstOrDefaultAsync(x => x.Id == id);

            try {
                context.Contatos.Remove(contatos);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
            
           
    }
}
