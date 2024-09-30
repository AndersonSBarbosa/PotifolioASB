using System.ComponentModel.DataAnnotations;

namespace PotifolioASB.Service.ViewModels.Ocorrencia
{
    public class UpdateOcorrenciaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A Data da Ocorrencia é obrigatoria.")]
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O Responsavel da Abertura não pode ser vazio.")]
        public int ResponsavelAbertura { get; set; }
        [Required(ErrorMessage = "O Responsavel da Ocorrencia não pode ser vazio.")]
        public int ResponsavelOcorrencia { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser vazio.")]
        [MinLength(11, ErrorMessage = "O CPF deve ter no mínimo 11 caracteres.")]
        [MaxLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
        public string Conclusao { get; set; }
        [Required(ErrorMessage = "o Fluxo não pode ser vazio.")]
        public int FluxoId { get; set; }
    }
}
