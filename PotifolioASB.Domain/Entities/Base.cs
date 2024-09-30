namespace PotifolioASB.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

    }
}
