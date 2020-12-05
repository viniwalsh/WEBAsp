using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class HeroiViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Nome { get; set; }
        public string Codinome { get; set; }
        [DataType(DataType.Date)]
        public DateTime Lancamento { get; set; }

        public List<PoderViewModel> Poderes { get; set; }

        public string HeroiNomeCompleto => $"({Id}) {Nome} {Codinome}";
    }
}
