using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContatoAPI.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o login de acesso ")]
        [StringLength(100)]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha de acesso")]
        public string Senha { get; set; }
    }
}
