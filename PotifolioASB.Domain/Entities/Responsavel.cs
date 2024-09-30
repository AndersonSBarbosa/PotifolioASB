namespace PotifolioASB.Domain.Entities
{
    public class Responsavel : Base
    {
        public Responsavel(string nome, string email, string telefone, string endereco, string cpf)
        {
            Nome=nome;
            Email=email;
            Telefone=telefone;
            Endereco=endereco;
            Cpf=cpf;
        }

        protected Responsavel() { }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
    }
}
