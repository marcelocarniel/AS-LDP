namespace GerenciamentoAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; } = "Pendente";
        public string Descricao { get; set; } = string.Empty;
    }
}