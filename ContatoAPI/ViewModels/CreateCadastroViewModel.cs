using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContatoAPI.ViewModels
{
    public class CreateCadastroViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha{ get; set; }
    }
}
