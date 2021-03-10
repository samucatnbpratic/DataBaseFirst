using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseFirst.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            ProdutoFornecedor = new HashSet<ProdutoFornecedor>();
        }

        public int IdFornec { get; set; }
        public string NomeFornec { get; set; }

        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
    }
}
