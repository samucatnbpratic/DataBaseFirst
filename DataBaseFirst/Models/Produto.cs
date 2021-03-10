using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseFirst.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutoFornecedor = new HashSet<ProdutoFornecedor>();
        }

        public int IdProduto { get; set; }
        public string NomeProd { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? PrecoVenda { get; set; }
        public decimal? PrecoCusto { get; set; }
        public string Unidade { get; set; }

        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
    }
}
