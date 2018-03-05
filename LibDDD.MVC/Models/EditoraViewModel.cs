using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibDDD.MVC.Models
{
    public class EditoraViewModel
    {
        [Key]
        public int EditoraID { get; set; }

        [Required(ErrorMessage = "Preencha a descriçao")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres.")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}