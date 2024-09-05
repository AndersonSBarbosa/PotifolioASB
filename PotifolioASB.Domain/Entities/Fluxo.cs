namespace PotifolioASB.Domain.Entities
{
    public class Fluxo : Base
    {
        public Fluxo(decimal valorLancamento, string descricao, bool entrada)
        {
            ValorLancamento=valorLancamento;
            Descricao=descricao;
            Entrada=entrada;
        }

        protected Fluxo() { }

        public decimal ValorLancamento { get; set; }
        public string Descricao { get; set; }
        public bool Entrada { get; set; } 

    }
}
