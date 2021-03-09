using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseFirst.Models
{
    public partial class ProdutosFornecedore
    {
        public int IdProduto { get; set; }
        public int IdFornec { get; set; }
        public string FornecCodProd { get; set; }
        public string FornecEanTrib { get; set; }

        public virtual Fornecedore IdFornecNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}
