namespace GarageManagerAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Grupo { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string? Fabricante { get; set; }
        public string? Fornecedor { get; set; }
        public decimal Preco { get; set; }
        public int? Garantia { get; set; }


    }
}
