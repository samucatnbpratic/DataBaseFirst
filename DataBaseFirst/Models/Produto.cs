using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseFirst.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutosFornecedores = new HashSet<ProdutosFornecedore>();
        }

        public int IdProduto { get; set; }
        public string NomeProd { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? PrecoVenda { get; set; }
        public decimal? PrecoCusto { get; set; }

        public virtual ICollection<ProdutosFornecedore> ProdutosFornecedores { get; set; }
    }
}
