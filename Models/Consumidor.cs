namespace BocaDeDrogasAPI.Models;

public class Consumidor {
	
	public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
	public decimal Divida { get; set; }
    public List<Venda> Vendas { get; set; } = [];
}
