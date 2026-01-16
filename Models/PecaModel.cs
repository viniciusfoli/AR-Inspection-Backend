namespace ARinspection.Models
{
    public class PecaModel
    {
        // 1. Construtor vazio para o Entity Framework (Obrigatório em muitos casos)
        public PecaModel() { }

        // 2. Seu construtor atual para criar novas peças
        public PecaModel(string nome, double temperatura, double vibracao, string instrucao, string historicoJson, Guid? Id = null)
        {
            Nome = nome;
            Temperatura = temperatura;
            this.Id = Id ?? Guid.NewGuid();
            Vibracao = vibracao;
            Instrucao = instrucao;
            HistoricoJson = historicoJson;
        }

        // Use 'set' em vez de 'init' para facilitar o trabalho do EF com construtor vazio
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Temperatura { get; set; }
        public double Vibracao { get; set; }      // Adicionado
        public string? Instrucao { get; set; }    // Adicionado
        public string HistoricoJson { get; set; } // Adicionado

        public void changeName(string novoNome, double novoTemperarura, double vibracao, string instrucao, string historicoJson)
        {
            Nome = novoNome;
            Temperatura = novoTemperarura;
            Vibracao = vibracao;
            Instrucao = instrucao;
            HistoricoJson = historicoJson;
        }

        public void SetInactive()
        {
            Nome = "Inativo";
        }
    }
}
