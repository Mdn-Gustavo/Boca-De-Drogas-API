namespace BocaDeDrogasAPI.Models;

public class Venda{

	public int Id { get; set; }
	
	public int ConsumidorId { get; set; }
	
	public int DrogaId { get; set; }
	
	public int Quantidade { get; set; }
	
	public decimal ValorTotal { get; set; }
	
	public Consumidor? Consumidor { get; set; }
	
	public Droga? Droga { get; set; }
}
