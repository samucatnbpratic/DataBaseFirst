using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseFirst.Models
{
    public partial class Fornecedore
    {
        public Fornecedore()
        {
            ProdutosFornecedores = new HashSet<ProdutosFornecedore>();
        }

        public int IdFornec { get; set; }
        public string NomeFornec { get; set; }

        public virtual ICollection<ProdutosFornecedore> ProdutosFornecedores { get; set; }
    }
}
