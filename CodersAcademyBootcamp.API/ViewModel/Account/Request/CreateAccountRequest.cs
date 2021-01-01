using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.API.ViewModel.Account.Request
{
    public class CreateAccountRequest
    {
        [Required(ErrorMessage = "Nome é um campo obrigátorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigátorio")]
        [EmailAddress(ErrorMessage = "Email não está em um formato correto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CPF é um campo obrigátorio")]
        [StringLength(11, ErrorMessage = "CPF é inválido ou não está em um formato correto")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigátorio")]
        [StringLength(20, ErrorMessage = "Senha deve ter no máximo 20 caracteres")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "A Senha deve ter no mínimo 8 caracteres, uma letra, um caracter especial e um número")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmacão de senha é um campo obrigátorio")]
        [Compare(nameof(Password), ErrorMessage = "Senha e Confirmação de Senha devem ser iguais")]
        public string ConfirmPassowrd { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
        public DateTime DateOfBirth { get; set; }



    }
}
