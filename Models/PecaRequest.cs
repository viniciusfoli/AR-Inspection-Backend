namespace ARinspection.Models
{
    public record PecaRequest(Guid? id, string nome, double temperatura, double vibracao, string? instrucao, string historicoJson);
}
