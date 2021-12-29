using ContatoAPI.Models;
using ContatoAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContatoAPI.Controllers
{
    [ApiController]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        [Route(template: "Cadastro")]
        public async Task<IActionResult> PostAsync([FromServices] ContatoDbContext context, [FromBody]
        CreateCadastroViewModel cadastro)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cadastros= new Cadastro
            {
                Login = cadastro.Login,
                Senha = cadastro.Senha,


            };

            try
            {
                await context.Logins.AddAsync(cadastros);
                await context.SaveChangesAsync();
                return Created(uri: $"v1/Logins/{cadastros.Id}", cadastro);
            }

            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
