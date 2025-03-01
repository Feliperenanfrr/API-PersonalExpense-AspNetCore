namespace API_PersonalExpense_AspNetCore.Model;

public class MetaGasto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal ValorMaximo { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    
    //Relacionamentos
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}