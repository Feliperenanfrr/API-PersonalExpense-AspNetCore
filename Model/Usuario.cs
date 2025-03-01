namespace API_PersonalExpense_AspNetCore.Model;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public DateTime DataCadastro { get; set; }

    //Relacionamentos
    public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
    public ICollection<MetaGasto> Metas { get; set; } = new List<MetaGasto>();
}