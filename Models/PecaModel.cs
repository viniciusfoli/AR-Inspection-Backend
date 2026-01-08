namespace ARinspection.Models
{
    public class PecaModel
    {
        // 1. Construtor vazio para o Entity Framework (Obrigatório em muitos casos)
        public PecaModel() { }

        // 2. Seu construtor atual para criar novas peças
        public PecaModel(string nome, double temperatura, Guid? Id = null)
        {
            Nome = nome;
            Temperatura = temperatura;
            this.Id = Id ?? Guid.NewGuid();
        }

        // Use 'set' em vez de 'init' para facilitar o trabalho do EF com construtor vazio
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Temperatura { get; set; }

        public void changeName(string novoNome, double novoTemperarura)
        {
            Nome = novoNome;
            Temperatura = novoTemperarura;
        }

        public void SetInactive()
        {
            Nome = "Inativo";
        }
    }
}
