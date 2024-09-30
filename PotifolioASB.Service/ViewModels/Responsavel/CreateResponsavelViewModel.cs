using System.ComponentModel.DataAnnotations;

namespace PotifolioASB.Service.ViewModels.Responsavel
{
    public class CreateResponsavelViewModel
    {

        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email não pode ser vazio.")]
        [MinLength(10, ErrorMessage = "O email deve ter no mínimo 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O email deve ter no máximo 180 caracteres.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O PhoneMobile não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O PhoneMobile deve ter no mínimo 3 caracteres.")]
        [MaxLength(15, ErrorMessage = "O PhoneMobile deve ter no máximo 15 caracteres.")]
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser vazio.")]
        [MinLength(11, ErrorMessage = "O CPF deve ter no mínimo 11 caracteres.")]
        [MaxLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
        public string Cpf { get; set; }
    }
}
