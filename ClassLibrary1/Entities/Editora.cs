using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDDD.Domain.Entities
{
    public class Editora
    {   [Key]
        public int EditoraID { get; set; }

        [Required(ErrorMessage = "Preencha a descriçao")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres.")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
        //public IEnumerable<Livro> LivrosLst { get; set; }
        
        public bool EditoraAtiva(Editora _editora)
        {
            return _editora.Ativo;
        }

    }
}
