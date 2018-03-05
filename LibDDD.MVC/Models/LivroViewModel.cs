using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibDDD.MVC.Models
{
    public class LivroViewModel
    {
        [Key]
        public int LivroID { get; set; }

        [Required(ErrorMessage ="Preencha a descriçao")]
        [MaxLength(150,ErrorMessage ="Maximo {0} caracteres.")]
        [MinLength(2,ErrorMessage = "Minimo {0} caracteres.")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public string Observacao { get; set; } 
        public bool Ativo { get; set; }
        public int EditoraId { get; set; }
        public virtual EditoraViewModel Editora { get; set; }
        public int AutorId { get; set; }
        public virtual AutorViewModel Autor { get; set; }
    }
}