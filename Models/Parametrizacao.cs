namespace GarageManagerAPI.Models
{
    public class Parametrizacao
    {
        public int Id = 1;
        public bool HomologacaoDireta {  get; set; }
        public int IdadeMinimaCadastro {  get; set; }
        public int IdadeMaximaCadastro {  get; set; }
        public int DescontoPagamentoVista {  get; set; }
        public int MargemPecas { get; set; }
        public decimal MaoDeObra { get; set; }


    }
}
