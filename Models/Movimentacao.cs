namespace Models
{
    public class Movimentacao
    {
        public int MovimentacaoId { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public string Descricao { get; set; }

        public string DataMovimentacao { get; set; }
    }
}