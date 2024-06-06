using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorAlunos.Entities
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor preencher o campo com um valor válido")]
        [MinLength(10, ErrorMessage = "O campo deve ter no mínimo 10 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Favor informar um e-mail válido")]
        public string? Email { get; set; }

        public int Idade { get; set; }
    }
}