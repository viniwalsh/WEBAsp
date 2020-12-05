using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class HeroiEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codinome { get; set; }
        public DateTime Lancamento { get; set; }

        public List<PoderEntity> Poderes { get; set; }
    }
}
