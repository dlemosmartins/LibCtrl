using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDDD.Domain.Entities
{
    public class Livro
    {
        public int LivroID { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }
        public int EditoraId { get; set; }
        public virtual Editora Editora { get; set; }
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }

        public bool LivroAtivo(Livro _livro) {

            return _livro.Ativo;
        }

    }
}
