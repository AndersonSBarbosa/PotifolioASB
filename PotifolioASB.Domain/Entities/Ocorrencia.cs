namespace PotifolioASB.Domain.Entities
{
    public class Ocorrencia : Base
    {
        public Ocorrencia(DateTime dataOcorrencia, string descricao, int responsavelAbertura, int responsavelOcorrencia, string conclusao, int fluxoId)
        {
            DataOcorrencia=dataOcorrencia;
            Descricao=descricao;
            ResponsavelAbertura=responsavelAbertura;
            ResponsavelOcorrencia=responsavelOcorrencia;
            Conclusao=conclusao;
            FluxoId=fluxoId;
        }

        protected Ocorrencia() { }

        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public int ResponsavelAbertura { get; set; }
        public int ResponsavelOcorrencia { get; set; }
        public string Conclusao { get; set; }
        public int FluxoId { get; set; }

    }
}
