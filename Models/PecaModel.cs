namespace ARinspection.Models
{
    public class PecaModel
    {
        public PecaModel(string nome)
        {
            Nome = nome;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; init; }
        public string Nome { get; private set; }

        public void changeName(string novoNome)
        {
            Nome = novoNome;
        }
        public void SetInactive()
        {
            Nome = "Inativo";
        }
    }
}
