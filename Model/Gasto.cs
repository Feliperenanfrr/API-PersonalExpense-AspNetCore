namespace API_PersonalExpense_AspNetCore.Model;

public class Gasto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    
    //Relacionametos
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}