namespace BocaDeDrogasAPI.Models;

public class Droga{

public int Id { get; set;}

public string Nome { get; set;} = string.Empty;

public decimal Preco { get; set;}

public int Estoque { get; set;}

public List<Venda> Vendas { get; set; } = [];
}

