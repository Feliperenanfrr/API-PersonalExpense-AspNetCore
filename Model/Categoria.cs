namespace API_PersonalExpense_AspNetCore.Model;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    
    //Relacionamentos
    public ICollection<Gasto> Gastos { get; set; }
}