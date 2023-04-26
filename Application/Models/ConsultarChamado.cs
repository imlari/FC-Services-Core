namespace Models;

public class ConsultaChamado
{
    public string idChamado { get; set; }
    public string Nome { get; set; }
    public DateTime DataRelato { get; set; }
    public string Descricao { get; set; }
    public string Img { get; set; }
    public string Prioridade { get; set; } 
    public string HorarioAbertura { get; set; }
    public string HorarioUltimaAtualizacao { get; set; }
    public string Tipo { get; set; }
    public string Status { get; set; }
    public string TempoDescorrido { get; set; }
    
}