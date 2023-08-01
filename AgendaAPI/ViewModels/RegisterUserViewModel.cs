using System.ComponentModel.DataAnnotations;

namespace AgendaAPI.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "O Campo {0} e obrigatorio")]
        [EmailAddress(ErrorMessage = "O campo {0} esta em formato invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} e obrigatorio")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas nao conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
