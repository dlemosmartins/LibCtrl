using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDDD.Domain.Entities
{
    public class Autor
    {
        public int AutorID { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        //public IEnumerable<Editora> EditorasLst { get; set; }
        //public IEnumerable<Livro> LivrosLst { get; set; }

        public bool EditoraAtiva(Autor _autor)
        {
            return _autor.Ativo;
        }
    }
}
